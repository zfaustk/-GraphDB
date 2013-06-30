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
    {   private enum wordtype { create,vertex,comma,colon,noexist}
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
            return str;
        }
        
        //返回单词类型
        private wordtype settype(string str)
        {
            if (str == "create")
                return wordtype.create;
            if (str == "vertex")
                return wordtype.vertex;
            if (str == ":")
                return wordtype.colon;

            return wordtype.noexist;
        }

        //语句开始
        private void statement()
        {
            count = 0;
            if (settype(strArray[count]) == wordtype.create)
            {
                count++;
                state_c();
            }
        }



        //create语句
        private bool state_c()
        {
            if (settype(strArray[count]) == wordtype.vertex)
            {
                count++;
                Dictionary <string,object> key_val = new Dictionary <string,object>();
                if (strArray[count]=="{")
                {
                    count++;
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
        //create语句分支 键值对属性确认
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
                dic[key] = val;
                return true;
            }
            else
                return false;
        }
        //值的类型判断
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









        public void Exert(string str)
        {
            str=setstr(str);
            strArray = str.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            statement();
        }


    }
}
