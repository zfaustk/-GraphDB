using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Helper
{
    public class GraphReader
    {
        /// <summary>
        /// 获取Reader所绑定的图
        /// </summary>
        public Graph Graph { get { return _graph ; } }
        private Graph _graph;

        private GraphHelper gHelper;

        /// <summary>
        /// 获取和设置数据库存储的位置
        /// </summary>
        public String Path { get; set; }

        public GraphReader(Graph g)
        {
            _graph = g;
            Path = "Graph_lyf";
            gHelper = new GraphHelper(_graph);
        }

        public bool Read(bool Create = false)
        {
            using (StreamReader sr = File.OpenText(Path + "_Vertex.gdbt"))
            {
                ReadAllVertices(sr);
            }

            using (StreamReader sr = File.OpenText(Path + "_Type.gdbt"))
            {
                ReadAllTypes(sr);
            }
            using (StreamReader sr = File.OpenText(Path + "_Edge.gdbt"))
            {
                ReadAllEdges(sr);
            }
            using (StreamReader sr = File.OpenText("Graph_lyf_Graph.gdbt"))
            {
                ReadAllGraphs(sr);
            }
            return false;
        }


        public IEnumerable<IVertex> ReadAllVertices(StreamReader sr)
        {   //Need Vertices
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                string[] commands = str.Split(new char[] { ' ' });

                if (commands.Length < 2) continue;

                IVertex v = new KHGraphDB.Structure.Vertex(commands[0]);
                int iAttr = Convert.ToInt32(commands[1]);
                for (int i = 0; i < iAttr; i += 2)
                {
                    object o;
                    if (commands[i + 3][0] == '\'' && commands[i + 3][commands[i+3].Length - 1] == '\'')
                        o = commands[i + 3].Trim(new char[] { '\'' });
                    else if (commands[i + 3] == "*")
                    {
                        o = "*";
                    }
                    else if (commands[i + 3].Contains('.'))
                    {
                        o = Convert.ToDouble(commands[i + 3]);
                    }
                    else
                    {
                        o = Convert.ToInt32(commands[i + 3]);
                    }
                        
                    v.Attributes[(string)(commands[i + 2])] = o;
                }
                gHelper.AddVertex(v);
            }
            return null;
        }


        public IEnumerable<IType> ReadAllTypes(StreamReader sr)
        {   //Need Vertices
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                string[] commands = str.Split(new char[] { ' ' });

                if (commands.Length < 4) continue;

                IType t = new KHGraphDB.Structure.Type(commands[0]);
                t.Name = commands[1];
                int iAttr = Convert.ToInt32(commands[2]);
                for (int i = 0; i < iAttr; i += 2)
                {
                    object o;
                    if (commands[i + 4][0] == '\'' && commands[i + 4][commands[i + 4].Length - 1] == '\'')
                        o = commands[i + 4].Trim(new char[] { '\'' });
                    else if (commands[i + 4] == "*")
                    {
                        o = "*";
                    }
                    else if (commands[i + 4].Contains('.'))
                    {
                        o = Convert.ToDouble(commands[i + 4]);
                    }
                    else
                    {
                        o = Convert.ToInt32(commands[i + 4]);
                    }

                    t.Attributes[(string)(commands[i + 3])] = commands[i + 4];
                }
                int iVertex = Convert.ToInt32(commands[3 + iAttr * 2]);
                for (int i = 0; i < iVertex; i++)
                {
                    t.AddVertex(gHelper.SelectSingleVertex(commands[4 + iAttr * 2]));
                }

                gHelper.AddType(t);
            }
            return null;
        }
        public IEnumerable<IEdge> ReadAllEdges(StreamReader sr)
        {
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                string[] commands = str.Split(new char[] { ' ' });

                if (commands.Length < 4) continue;

                IEdge e = new KHGraphDB.Structure.Edge(commands[0], gHelper.SelectSingleVertex(commands[1]), gHelper.SelectSingleVertex(commands[2]));

                int iAttr = Convert.ToInt32(commands[3]);
                for (int i = 0; i < iAttr; i += 2)
                {
                    object o;
                    if (commands[i + 5][0] == '\'' && commands[i + 5][commands[i + 5].Length - 1] == '\'')
                        o = commands[i + 5].Trim(new char[] { '\'' });
                    else if (commands[i + 5] == "*")
                    {
                        o = "*";
                    }
                    else if (commands[i + 5].Contains('.'))
                    {
                        o = Convert.ToDouble(commands[i + 5]);
                    }
                    else
                    {
                        o = Convert.ToInt32(commands[i + 5]);
                    }

                    e.Attributes[(string)(commands[i + 4])] = o;
                }
                gHelper.AddEdge(e);
            }
            return null;
        }
        public IEnumerable<IGraph> ReadAllGraphs(StreamReader sr)
        {
            string str = sr.ReadLine();
            string[] commands = str.Split(new char[] { ' ' });
            return null;
        }
    }
}
