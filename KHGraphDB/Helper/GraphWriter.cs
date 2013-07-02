using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;
using System.IO;
using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Helper
{
    public class GraphWriter
    {
        /// <summary>
        /// 获取Writer所绑定的图
        /// </summary>
        public Graph Graph { get { return _graph ; } }
        private Graph _graph;

        /// <summary>
        /// 获取和设置数据库存储的位置
        /// </summary>
        public String Path { get; set; }

        public GraphWriter(Graph g)
        {
            _graph = g;
            Path = "KHGDB";
        }

        public bool Write()
        {
            using (StreamWriter sr = new StreamWriter(Path + "_Type.gdbt"))
            {
                WriteTypes(sr);
            }

            using (StreamWriter sr = new StreamWriter(Path + "_Vertex.gdbt"))
            {
                WriteVertexs(sr);
            }
            using (StreamWriter sr = new StreamWriter(Path + "_Edge.gdbt"))
            {
                WriteEdges(sr);
            }
            using (StreamWriter sr = new StreamWriter(Path + ".gdbf"))
            {
                WriteGraphs(sr);
            }
            return true;
        }

        public void WriteTypes(StreamWriter sr)
        {
            string str = "";
            foreach (var t in Graph.Types)
            {
                //IEnumerable<IVertex> iv = this._graph.Vertices.Except(t.Vertices);
                //iv = iv.Except(t);

                str = t.KHID + " \'" + t.Name + "\' " + t.Attributes.Count.ToString() + " ";
                foreach (var key in t.Attributes.Keys)
                {
                    if (t[key] == null)
                        str += key + " " + "*" + " ";
                    else
                        str += key + " " + ((t[key].GetType().Equals("".GetType())) ? "'" + t[key].ToString() + "'" : t[key].ToString()) + " ";
                }
                str += t.Vertices.Count().ToString() + " ";
                foreach (var v in t.Vertices)
                {
                    str += v.KHID + " ";
                }
                str += "\n";
                sr.WriteLine(str);
            }
        }

        public void WriteVertexs(StreamWriter sr)
        {
            string str = "";
            foreach (var t in Graph.Vertices)
            {
                str = t.KHID + " " + t.Attributes.Count.ToString() + " ";
                foreach (var key in t.Attributes.Keys)
                {
                    if (t[key] == null)
                        str += key + " " + "*" + " ";
                    else
                        str += key + " " + ((t[key].GetType().Equals("".GetType())) ? "'" + t[key].ToString() + "'" : t[key].ToString()) + " ";
                }
                str += "\n";
                sr.WriteLine(str);
            }
            
        }
        public void WriteEdges(StreamWriter sr)
        {
            string str = "";
            foreach (var t in Graph.Edges)
            {
                str = t.KHID + " " + t.Source.KHID + " " + t.Target.KHID + " " + t.Attributes.Count + " ";
                foreach (var key in t.Attributes.Keys)
                {
                    if (t[key] == null)
                        str += key + " " + "*" + " ";
                    else
                        str += key + " " + ((t[key].GetType().Equals("".GetType())) ? "'" + t[key].ToString() +"'" : t[key].ToString()) + " ";
                }
                str += "\n";
                sr.WriteLine(str);
            }
        }
        public void WriteGraphs(StreamWriter sr)
        {
            string str = "";
            str += Path + "_Type.gdbt" + "\n";
            str += "  " + Path + "_Vertex.gdbt" + "\n";
            str += "  " + Path + "_Edge.gdbt" + "\n";
            sr.Write(str);
        }
    }
}
