using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Helper;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;
using System.Windows.Forms;

namespace KHGraphDBMS.Grammar
{
    public class Grammar
    {   private enum wordtype { create,vertex,edge,type,alter,change,merge,delete,noexist}
        private string[] strArray;
        private int count;
        private int errortype;
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
        //消息处理函数
        private void fun(string result)
        {
            MessageBox.Show(result);
        }
        private string derror(int line,int type)
        {
            string error="";
            error = "错误在语句";
            error = error + line.ToString();
            switch(type){
                case 0:  error = error + "单词" + strArray[count] + "附近!";
                         break;
                case 1:  error = error + " merge语句属性值不对应";
                         break;
                case 2: error = error + " 删除的点没有找到";
                         break;
                case 3: error = error + " 删除的type没有找到";
                         break;
                case 4: error = error + " 没有找到相关边";
                         break;
                case 5: error = error + " type中没有该属性";
                         break;
                case 6: error = error + " 修改type时点属性已被占用";
                         break;
                         }
            return error;
        }
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
            if (str.ToLower() == "create")
                return wordtype.create;
            if (str.ToLower() == "vertex")
                return wordtype.vertex;
            if (str.ToLower() == "edge")
                return wordtype.edge;
            if (str.ToLower() == "type")
                return wordtype.type;
            if (str.ToLower() == "alter")
                return wordtype.alter;
            if (str.ToLower() == "change")
                return wordtype.change;
            if (str.ToLower() == "merge")
                return wordtype.merge;
            if (str.ToLower() == "delete")
                return wordtype.delete;

            return wordtype.noexist;
        }
        //语句开始
        private void statement()
        {
            count = 0;
            int line = 0;
            bool flag=true;
            errortype = 0;
            while (strArray[count] != "end")
            {
                if (settype(strArray[count]) == wordtype.create)
                {
                    line++;
                    count++;
                    if (!state_c())
                    {
                        /*错误处理函数添加于此*/
                        string error;
                        error = derror(line,errortype);
                        fun(error);
                        count = strArray.Length - 1;
                        flag = false;
                    }//错误处理
                }
                if (settype(strArray[count]) == wordtype.alter)
                {
                    line++;
                    count++;
                    if (!state_a())
                    {
                        /*错误处理函数添加于此*/
                        string error;
                        error = derror(line,errortype);
                        fun(error);
                        count = strArray.Length - 1;
                        flag = false;
                    }//错误处理
                }

            }
            if (flag == true)
            {
                string result;
                result = "成功执行";
                fun(result);
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
                                            count++;
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

            //type的create
            if(settype(strArray[count])==wordtype.type)
            {
                Dictionary<string, object> key_val = new Dictionary<string, object>();
                string typename;
                count++;
                if(strArray[count]=="{")
                {
                    count++;
                    if(strArray[count]=="name" &&strArray[count+1]==":")
                    {
                        count=count+2;
                        if(strArray[count]=="\"")
                        {
                            count++;
                            typename=strArray[count];
                            count++;
                            if(strArray[count]=="\"")
                            {
                                count++;
                                if(strArray[count]==",")
                                {
                                    count++;
                                    typekanv(key_val);
                                    if (strArray[count] == "}")
                                    {
                                        count++;
                                        gHelper.AddType(null,typename, key_val);
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
                                                gHelper.SelectSingleTypeName(typename).AddVertex(gHelper.AddVertex(key_val));
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
        //type的连续值的键值对生成｛val，val，val....} ||  {...}key:val
        private bool type_val(string typename, Dictionary<string, object> dic)
        {
            IType type = gHelper.SelectSingleTypeName(typename);
            object val;
            foreach (var t in type.Attributes.Keys)
            {
                val = valtype();
                if (strArray[count] == ",")
                {
                    if (strArray[count - 3] == "\"" && strArray[count - 1] != "\"")
                        return false;
                    count++;
                }
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
                dic[key] = null;
                    return true;
            }
        }
        //edge边的生成
        private void makeedge(Dictionary<string, object> dic, string keysrc, string keydest, object valsrc, object valdest, int type)
        {
            foreach (var v1 in gHelper.SelectVerteics(keysrc,valsrc))
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
        //type的create
        //type类型的键值生成
        private void typekanv(Dictionary<string, object> dic)
        {
            dic[strArray[count]] = null;
            count++;
            while (strArray[count] == ",")
            {
                count++;
                dic[strArray[count]] = null;
                count++;
            }
        }


        /*                       alter语句: alter                       */
        private bool state_a()
        {
            if(settype(strArray[count])==wordtype.vertex)
            {
                if (alvertex())
                    return true;
                else
                    return false;
            }
            if (settype(strArray[count]) == wordtype.delete)
            {
                if (aldelete())
                    return true;
                else
                    return false;
            }
            if (settype(strArray[count]) == wordtype.type)
            {
                if (altype())
                    return true;
                else
                    return false;
            }

            return false;

        }
        //alter vertex操作
        private bool alvertex()
        {
            Dictionary<string, object> key_val = new Dictionary<string, object>();
            count++;
            string vkey, typename;
            object vval;
            if (strArray[count]=="(")
            {
                count++;
                vkey = strArray[count];
                count++;
                if (strArray[count] == ":")
                {
                    count++;
                    vval = valtype();
                    if (strArray[count] == ")")
                    {
                        count++;
                        //type change
                        if (settype(strArray[count]) == wordtype.change)
                        {
                            count++;
                            if (strArray[count] == "{")
                            {
                                count++;
                                if (strArray[count] == "type")
                                {
                                    count++;
                                    if (strArray[count] == "(")
                                    {
                                        count++;
                                        if (strArray[count] == "name" && strArray[count + 1] == ":" && strArray[count + 2] == "\"")
                                        {
                                            count = count + 3;
                                            typename = strArray[count];
                                            count=count+2;
                                            if (strArray[count] == ")")
                                            {
                                                count++;
                                                if (strArray[count] == "{")
                                                {
                                                    count++;
                                                    if (type_val(typename, key_val))
                                                    {
                                                        count++;
                                                        if (strArray[count] == "}")
                                                        {
                                                            count++;
                                                            changetype(vkey, vval, typename, key_val);
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
                                {
                                    if (pandv(key_val))
                                    {
                                        while (strArray[count] == ",")
                                        {
                                            count++;
                                            if (!pandv(key_val))
                                                return false;
                                        }
                                        if (strArray[count] == "}")
                                        {
                                            count++;
                                            changevertex(vkey, vval, key_val);
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
                        //merge
                        if (settype(strArray[count]) == wordtype.merge)
                        {
                            count++;
                            if (strArray[count]=="{")
                            {
                                count++;
                                if (pandv(key_val))
                                {
                                    while (strArray[count] == ",")
                                    {
                                        count++;
                                        if (!pandv(key_val))
                                            return false;
                                    }
                                    if (strArray[count] == "}")
                                    {
                                        if (mergevertex(vkey, vval, key_val))
                                        {
                                            count++;
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
                        }
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
       //查询每个点并且将点加入type中
        private void changetype(string vkey,object vval, string typename, Dictionary<string, object> dic)
        {
            IType type = gHelper.SelectSingleTypeName(typename);
            foreach (var v in gHelper.SelectVerteics(vkey, vval))
            {
                v.Type = type;
                foreach (var key in dic.Keys)
                {
                    v[key] = dic[key];
                }
            }
        }
       //查询每个点并且改变值，merge 必须原有属性
        private bool mergevertex(string vkey, object vval, Dictionary<string, object> dic)
        {
            foreach (var v in gHelper.SelectVerteics(vkey, vval))
            {
                foreach (var key in dic.Keys)
                {
                    if (!v.Attributes.Keys.Contains(key))
                    {
                        errortype = 1;
                        return false;
                    }
                }
                foreach (var key in dic.Keys)
                {
                    v[key] = dic[key];
                }
            }
            return true;
        }
       //查询每个点并且改变值，change 没原属性则添加
        private void changevertex(string vkey, object vval, Dictionary<string, object> dic)
        {
            foreach (var v in gHelper.SelectVerteics(vkey, vval))
            {
                foreach (var key in dic.Keys)
                {
                    v[key] = dic[key];
                }
            }
        }
        //alter delete操作
        private bool aldelete()
        {
            count++;
            string vkey;
            object vval;
            string tkey="";
            object tval=null;
            Dictionary<string, object> keys = new Dictionary<string, object>();
            string id;
            //vertex
            if (settype(strArray[count]) == wordtype.vertex)
            {
                count++;
                if (strArray[count] == "(")
                {
                    count++;
                    if (strArray[count + 1] == ":")
                    {
                        vkey = strArray[count];
                        count = count + 2;
                        vval = valtype();
                        if (settype(strArray[count+1]) == wordtype.change)
                        {
                            count = count + 2;
                            if (vkey_list(keys))
                            {
                                if(deletevertex(vkey, vval, keys))
                                    return true;
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else
                        {
                            if (!deletevertex(vkey, vval))
                                return false;
                            if (strArray[count] == ")")
                            {
                                count++;
                                return true;
                            }
                            else
                                return false;
                        }
                    }
                    if (strArray[count + 1] == "-")
                    {
                        if ((id = getid()) != null)
                        {
                            count++;
                            deletevertex(id);
                        }
                        else
                            return false;
                        if (strArray[count] == ")")
                        {
                            count++;
                            return true;
                        }
                        else
                            return false;
                    }
                    return false;
                }
                else
                    return false;
            }
            //type
            if (settype(strArray[count]) == wordtype.type)
            {
                if (strArray[count + 1] == "(")
                {
                    if (strArray[count + 3] == "-")
                    {
                        count=count+2;
                        if ((id = getid()) != null)
                        {
                            count++;
                            deletetype(id);
                            return true;
                        }
                        else
                            return false;
                    }
                    if (strArray[count + 3] == ":")
                    {
                        count++;
                        if (typekey_val(ref tkey, ref tval))
                        {
                            if (deletetype(tkey, tval))
                                return true;
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
            //edge
            if (settype(strArray[count]) == wordtype.edge)
            {
                string v1key="", v2key="";
                object v1val=null, v2val=null;
                count++;
                if (strArray[count] == "(")
                {
                    count++;
                    vertex_key_val(ref v1key, ref v1val);
                    if (strArray[count] == ",")
                    {
                        count++;
                        vertex_key_val(ref v2key, ref v2val);
                        if (strArray[count] == ",")
                        {
                            count++;
                            ekey_list(keys);
                            if (strArray[count] == ")")
                            {
                                deleteedge(v1key, v1val, v2key, v2val, keys);
                                count++;
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



            return false;
        }
        //删除点（键值对)
        private bool deletevertex(string key,object val)
        {
            int i = 0;
            foreach (var v in gHelper.SelectVerteics(key, val))
            {
                i++;
                gHelper.RemoveVertex(v);
            }
            if (i == 0)
            {
                errortype = 2;
                return false;
            }
            return true;
        }
        //删除点(id)
        private bool deletevertex(string id)
        {
            if (gHelper.SelectSingleVertex(id) == null)
            {
                errortype = 2;
                return false;
            }
            gHelper.RemoveVertex(id);
            return true;
        }
        //删除点的属性
        private bool deletevertex(string key,object val,Dictionary<string,object> keys)
        {
            int i = 0;
            foreach (var v in gHelper.SelectVerteics(key, val))
            {
                i++;
                foreach (var k in keys.Keys)
                {
                    v.RemoveAttribute(k);
                }
            }
            if (i == 0)
            {
                errortype = 2;
                return false;
            }
            return true;
        }
        //获得string id
        private string getid()
        {
            string str="";
            while (strArray[count] != ")"||strArray[count]==",")
            {
                if (strArray[count] == "end")
                    return null;
                str = str + strArray[count];
                count++;
            }
            return str;
        }
        //删除type(id)
        private bool deletetype(string id)
        {
            if (gHelper.RemoveType(id))
                return true;
            else
            {
                errortype = 3;
                return false;
            }
        }
        //删除type（名字)
        private bool deletetype(string name,object val)
        {
            var t = gHelper.SelectSingleTypeName(val.ToString());
            if (t != null)
            {
                gHelper.RemoveType(t);
                return true;
            }
            else
            {
                errortype = 3;
                return false;
            }
        }
        //删除edge
        private bool deleteedge(string v1, object v1val, string v2, object v2val, Dictionary<string, object> keys)
        {
            int i = 0;
            foreach (var vsrc in gHelper.SelectVerteics(v1, v1val))
            {
                foreach (var vdest in gHelper.SelectVerteics(v2, v2val))
                {
                    foreach (var key in keys.Keys)
                    {
                        i++;
                        var edge=gHelper.SelectEdges(key, null, vsrc, vdest);
                        foreach (var e in edge)
                        {
                            gHelper.RemoveEdge(e);
                        }
                    }
                }
            }
            if (i == 0)
            {
                errortype = 4;
                return false;
            }
            else
                return true;
        }
        //alter type操作
        private bool altype()
        {
            count++;
            string typename="";
            object typeval=null;
            if (typekey_val(ref typename, ref typeval))
            {
                if (settype(strArray[count]) == wordtype.change)
                {
                    count++;
                    if (strArray[count] == "{")
                    {
                        count++;
                        if(strArray[count]=="\"")
                        {
                            string name;
                            count++;
                            name = strArray[count];
                            count++;
                            if (strArray[count] == "\"" && strArray[count + 1] == "}")
                            {
                                count = count + 2;
                                IType t = gHelper.SelectSingleTypeName(typeval.ToString());
                                t.Name = name;
                                return true;
                            }
                            else
                                return false;
                        }
                        if(strArray[count+1]==":")
                        {
                            string s1, s2;
                            s1 = strArray[count];
                            count = count + 2;
                            s2 = strArray[count];
                            count++;
                            if (strArray[count] == "}")
                            {
                                count++;
                                IType t = gHelper.SelectSingleTypeName(typeval.ToString());
                                if (t.Attributes.Keys.Contains(s1))
                                {
                                    t.RemoveAttribute(s1);
                                    t[s2] = null;
                                    foreach (var v in t.Vertices)
                                    {
                                        if (v.Attributes.Keys.Contains(s2))
                                        {
                                            errortype = 6;
                                            return false;
                                        }
                                    }
                                    foreach (var v in t.Vertices)
                                    {
                                        if (v.Attributes.Keys.Contains(s1))
                                        {
                                            v[s2] = v[s1];
                                            v.RemoveAttribute(s1);
                                        }
                                    }
                                    return true;
                                }
                                else
                                {
                                    errortype = 5;
                                    return false;
                                }
                            }
                            else
                                return false;
                        }
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













        public void Exert(string str)
        {
            str=setstr(str);
            str = str + " end ";
            strArray = str.Split(new Char[] { ' ','\n' }, StringSplitOptions.RemoveEmptyEntries);
            statement();
        }


        /*----------------------对句子的判断的提取------------------------------*/

        //{key,key,key....}
        private bool vkey_list(Dictionary<string,object> dic)
        {
            if(strArray[count]=="{")
            {
                count++;
                dic[strArray[count]] = null;
                count++;
                while (strArray[count] == ",")
                {
                    count++;
                    dic[strArray[count]] = null;
                    count++;
                }
                if (strArray[count] == "}")
                {
                    count++;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        //(name:"test1")     type(name:"test1")
        private bool typekey_val(ref string key, ref object val)
        {
            count++;
            key = strArray[count];
            count=count+2;
            val = valtype();
            if (strArray[count] == ")")
            {
                count++;
                return true;
            }
            else
                return false;
        }
        //vertex(key:val)
        private bool vertex_key_val(ref string key,ref object val)
        {
            if (settype(strArray[count]) == wordtype.vertex)
            {
                count++;
                if (strArray[count] == "(")
                {
                    count++;
                    key = strArray[count];
                    count++;
                    if (strArray[count] == ":")
                    {
                        count++;
                        val = valtype();
                        if(strArray[count]==")")
                        {
                            count++;
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
        //key,key,.....
        private bool ekey_list(Dictionary<string, object> dic)
        {
            dic[strArray[count]] = null;
            count++;
            while (strArray[count] == ",")
            {
                count++;
                dic[strArray[count]] = null;
            }
            return true;
        }



    }
}
