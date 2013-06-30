using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Helper;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;

namespace KHGraphDBMS.Grammar
{
    public class Grammar
    {   private enum wordtype { create,vertex,edge,noexist}
        private string[] strArray;
        private int count;

        /// <summary>
        /// 获取关联的图形数据库
        /// </summary>
        public IGraph Graph { get { return _graph; } }
        private IGraph _graph;

        /// <summary>
        /// 小帮手
        /// </summary>
        private GraphHelper gHelper;

        public Grammar(IGraph g)
        {
            _graph = g;
            gHelper = new GraphHelper(g);

        }

        public void Demo()
        {

            IVertex v1 = gHelper.AddVertex(new Dictionary<string, object>()
            {
                {"name","Peiming"} , {"age",20}
            });

            IVertex v2 = gHelper.AddVertex(new Dictionary<string, object>()
            {
                {"name","Yidong"}
            });

            gHelper.AddEdge(v1, v2, new Dictionary<string, object>()
            {
                {"distance",10}
            });
        }


        /*                     lpm                      */
        //划分词的准备
        private string setstr(string str)
        {
            str = str.Replace("{", " { ");
            str = str.Replace(":", " : ");
            str = str.Replace("\"", " \" ");
            str = str.Replace(",", " , ");
            str = str.Replace("}", " } ");
            str = str.Replace(".", " . ");
            str = str.Replace("(", " ( ");
            str = str.Replace(")", " ) ");
            str = str.Replace("-", " - ");
            str = str.Replace(">", " > ");
            str = str.Replace("[", " [ ");
            str = str.Replace("]", " ] ");
            return str;
        }
        //返回单词类型
        private wordtype settype(string str)
        {
            if (str == "create")
                return wordtype.create;
            if (str == "vertex")
                return wordtype.vertex;
            if (str == "edge")
                return wordtype.edge;

            return wordtype.noexist;
        }
        //语句开始
        private void statement()
        {
            count = 0;
            while (strArray[count] != "end")
            {
                if (settype(strArray[count]) == wordtype.create)
                {
                    count++;
                    if (!state_c())
                    {
                        /*错误处理函数添加于此*/
                        count = strArray.Length - 1;
                    }//错误处理
                }
            }
        }



        /*                        create语句：create                        */
        private bool state_c()
        {
            //点的Create
            if (settype(strArray[count]) == wordtype.vertex)
            {
                count++;
                if (strArray[count]=="{")
                {
                    count++;
                    if (strArray[count] != "type")
                    {
                        if (createv1())
                            return true;
                        else
                            return false;
                    }
                    if (strArray[count] == "type")
                    {
                        if (createv2())
                            return true;
                        else
                            return false;
                    }


                    return false;
                }
                else
                    return false;
            }

            //边的create
            if (settype(strArray[count]) == wordtype.edge)
            {
                string keysrc, keydest;
                object valsrc, valdest;
                int path;
                Dictionary<string, object> key_val = new Dictionary<string, object>();
                count++;
                if (settype(strArray[count]) == wordtype.vertex)
                {
                    count++;
                    if (strArray[count] == "(")
                    {
                        count++;
                        keysrc = strArray[count];
                        count++;
                        if (strArray[count] == ":")
                        {
                            count++;
                            valsrc = valtype();
                            if (strArray[count - 3] == "\"" && strArray[count - 1] != "\"")
                                return false;
                            if(strArray[count]==")")
                            {
                                count++;
                                if (strArray[count] == "-")
                                {
                                    count++;
                                    if (strArray[count] == "[")
                                    {
                                        count++;
                                        if(!edgekandv(key_val))
                                            return false;
                                        while (strArray[count] == ",")
                                        {
                                            if (!edgekandv(key_val))
                                                return false;
                                        }
                                        if (strArray[count] == "]")
                                        {
                                            count++;
                                            if (strArray[count] == "-")
                                            {
                                                count++;
                                                if (strArray[count] == ">")
                                                {
                                                    count++;
                                                    path = 1;
                                                }
                                                else
                                                    path = 2;
                                                if (settype(strArray[count])==wordtype.vertex)
                                                {
                                                    count++;
                                                    if (strArray[count] == "(")
                                                    {
                                                        count++;
                                                        keydest = strArray[count];
                                                        count++;
                                                        if (strArray[count] == ":")
                                                        {
                                                            count++;
                                                            valdest= valtype();
                                                            if (strArray[count - 3] == "\"" && strArray[count - 1] != "\"")
                                                                return false;
                                                            if (strArray[count] == ")")
                                                            {
                                                                count++;
                                                                makeedge(key_val, keysrc, keydest, valsrc, valdest, path);
                                                                return true;
                                                            }
                                                            else
                                                                return false;
                                                        }
                                                        else
                                                            return false;
                                                    }
                                                    else
                                                        return false;
                                                }
                                                else
                                                    return false;
                                            }
                                            else
                                                return false;
                                        }
                                        else
                                            return false;

                                    }
                                    else
                                        return false;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }
        //vertex的create
        //create句型一：create vertex {name:"peiming",game:"gal",age:22}
        private bool createv1()
        {
            Dictionary<string, object> key_val = new Dictionary<string, object>();
            if (!pandv(key_val))
                return false;
            while (strArray[count] == ",")
            {
                count++;
                if (!pandv(key_val))
                    return false;
            }
            if (strArray[count] == "}")
            {
                gHelper.AddVertex(key_val);
                count++;
                return true;
            }
            else
                return false;
        }
        //create句型二:create vertex  {type(name:"student"){"10001000","weidong",22}}||	{type(name:"student"){"10001000","yidong",22}, go:"20"}
        private bool createv2()
        {
            Dictionary<string, object> key_val = new Dictionary<string, object>();
            string typename;
            count++;
            if (strArray[count] == "(")
            {
                count++;
                if (strArray[count] == "name")
                {
                    count++;
                    if (strArray[count] == ":")
                    {
                        count++;
                        if (strArray[count] == "\"")
                        {
                            count++;
                            typename = strArray[count];
                            count++;
                            if (strArray[count] == "\"" && strArray[count + 1] == ")")
                            {
                                count = count + 2;
                                if (strArray[count] == "{")
                                {
                                    count++;
                                    if (strArray[count + 1] == ":")
                                    {
                                        if (!pandv(key_val))
                                            return false;
                                        while (strArray[count] == ",")
                                        {
                                            count++;
                                            if (!pandv(key_val))
                                                return false;
                                        }
                                        if (strArray[count] == "}"&& strArray[count+1] == "}")
                                        {
                                            count++; count++;
                                            gHelper.AddVertex(key_val).Type = gHelper.SelectSingleTypeName(typename);
                                            return true;
                                        }
                                        else
                                            return false;
                                    }
                                    else
                                    {
                                        if (type_val(typename, key_val))
                                        {
                                            count++;
                                            if (strArray[count] == "}")
                                            {
                                                count++;
                                                gHelper.AddVertex(key_val).Type = gHelper.SelectSingleTypeName(typename);
                                                return true;
                                            }
                                            else
                                                return false;
                                        }
                                        else
                                            return false;
                                    }
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }
        //type的连续值的键值对生辰｛val，val，val....} ||  {...}key:val
        private bool type_val(string typename, Dictionary<string, object> dic)
        {
            IType type = gHelper.SelectSingleTypeName(typename);
            object val;
            foreach (var t in type.Attributes.Keys)
            {
                val = valtype();
                if (strArray[count - 3] == "\"" && strArray[count - 1] != "\"")
                    return false;
                if (strArray[count] == ",")
                    count++;
                dic[t] = val;
            }
            if (strArray[count] == "}")
            {
                if (strArray[count + 1] == ",")
                {
                    count = count + 2;
                    pandv(dic);
                    count--;
                }
                else
                {
                    if(strArray[count+1] != "}")
                    return false;
                }
            }
            return true;
        }
        //键值对的生成｛ key：val ｝
        private bool pandv(Dictionary<string,object> dic)
        {
            string key;
            object val;
            key = strArray[count];
            count++;
            if (strArray[count] == ":")
            {
                count++;
                val=valtype();
                if (strArray[count - 3] == "\"" && strArray[count - 1] != "\"")
                    return false;
                dic[key] = val;
                return true;
            }
            else
                return false;
        }
        //值的类型判断｛字符串，整形，浮点型｝
        private object valtype()
        {    
            int inum;
            double fnum;
            if (strArray[count] == "\"")
            {
                string str;
                count++;
                str = strArray[count];
                count=count+2;
                return str;
            }
            if (int.TryParse(strArray[count], out inum))
            {
                count++;
                if (strArray[count] == ".")
                {
                    int length;
                    count++;
                    if (double.TryParse(strArray[count], out fnum))
                    {
                        count++;
                        length = strArray[count].Length;
                        fnum = inum + fnum * Math.Pow(0.1, length);
                        return fnum;
                    }
                    else
                        return inum;
                }
                else
                    return inum;
            }
            return null;
        }
        //edge的create
        //edge边键值的生成
        private bool edgekandv(Dictionary<string, object> dic)
        {
            string key;
            object val;
            key = strArray[count];
            count++;
            if (strArray[count] == ":")
            {
                count++;
                val = valtype();
                if (strArray[count - 3] == "\"" && strArray[count - 1] != "\"")
                    return false;
                dic[key] = val;
                return true;
            }
            else
            {
                    val = null;
                    return true;
            }
        }
        //edge边的生成
        private void makeedge(Dictionary<string, object> dic, string keysrc, string keydest, object valsrc, object valdest, int type)
        {
            var vvvv =gHelper.SelectVerteics(keysrc,valsrc);
            foreach (var v1 in vvvv)
            {
                foreach (var v2 in gHelper.SelectVerteics(keydest, valdest))
                {
                    if (type == 1)
                    {
                        gHelper.AddEdge(v1, v2, dic);
                    }
                    else
                    {
                        gHelper.AddEdge(v1, v2, dic);
                        gHelper.AddEdge(v2, v1, dic);
                    }
                }
            }
            object o = keysrc + valsrc;
        }










        public void Exert(string str)
        {
            str=setstr(str);
            str = str + " end ";
            strArray = str.Split(new Char[] { ' ','\n' }, StringSplitOptions.RemoveEmptyEntries);
            statement();
        }


    }
}
