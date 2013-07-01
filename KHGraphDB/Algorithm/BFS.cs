using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Algorithm
{
    public class BFS:Algorithm,IAlgorithm
    {
        #region Construct
        protected enum Color
        {
            GREEN, RED, WHITE
        }
        /// <summary>
        /// Attribute key .. Used to store state of the vertex
        /// </summary>
        protected String COLOR_ATTRIBUTE_KEY;
        /// <summary>
        /// Attribute key .. used to store the distance of the vertex
        /// </summary>
        protected String DISTANCE_ATTRIBUTE_KEY;

        /// <summary>
        /// Attribute key .. Used to store the reference to the predecessor at a vertex
        /// </summary>
        protected String PREDECESSOR_ATTRIBUTE_KEY;
        #endregion

        #region IAlgorithm
        public void BeginAlgorithm(IGraph theGraph)
        {
            COLOR_ATTRIBUTE_KEY = KHID + "__color";
            DISTANCE_ATTRIBUTE_KEY = KHID + "__dist";
            PREDECESSOR_ATTRIBUTE_KEY = KHID + "__pred";

            Parallel.ForEach<IVertex>(theGraph.Vertices, v =>
            {
                v.AlgorithmObjs[COLOR_ATTRIBUTE_KEY] = Color.WHITE;
                v.AlgorithmObjs[PREDECESSOR_ATTRIBUTE_KEY] = null;
                v.AlgorithmObjs[DISTANCE_ATTRIBUTE_KEY] = Int32.MaxValue;
            });
        }

        public void EndAlgorithm(IGraph theGraph)
        {
            Parallel.ForEach<IVertex>(theGraph.Vertices, v =>
            {
                v.RemoveAlgorithmObj(COLOR_ATTRIBUTE_KEY);
                v.RemoveAlgorithmObj(DISTANCE_ATTRIBUTE_KEY);
                v.RemoveAlgorithmObj(PREDECESSOR_ATTRIBUTE_KEY);
            });
        }
        #endregion

        public List<IVertex> SearchNearby(IGraph theGraph, IVertex theSource, Double range, String type)
        {
            #region init
            this.BeginAlgorithm(theGraph);

            List<IVertex> result = new List<IVertex>();//return list

            var queue = new Queue<IVertex>();
            IVertex u = null;
            #endregion

            Double weight;
            theSource.AlgorithmObjs[DISTANCE_ATTRIBUTE_KEY] = (Double)0;
            queue.Enqueue(theSource);

            while (queue.Count > 0)
            {
                Console.WriteLine("queue");
                u = queue.Dequeue();
                foreach (var outEdge in u.OutgoingEdges)
                {
                    if (outEdge.Attributes.Keys.Contains(type))//if contains "String type"
                    {
                        Console.WriteLine("1");
                        var v = outEdge.Target;
                        var color = (Color)v.AlgorithmObjs[COLOR_ATTRIBUTE_KEY];
                        if (color == Color.WHITE)
                        {
                            v.AlgorithmObjs[COLOR_ATTRIBUTE_KEY] = Color.RED;
                            v.AlgorithmObjs[PREDECESSOR_ATTRIBUTE_KEY] = u;

                            try
                            {
                                weight = Convert.ToDouble(outEdge[type]);
                            }
                            catch
                            {
                                weight = 1;
                            }
                            v.AlgorithmObjs[DISTANCE_ATTRIBUTE_KEY] = (Double)(u.AlgorithmObjs[DISTANCE_ATTRIBUTE_KEY]) + weight;

                            if ((Double)(v.AlgorithmObjs[DISTANCE_ATTRIBUTE_KEY]) <= range)//in the range
                            {
                                queue.Enqueue(v);
                                result.Add(v);//add to result list
                            }
                        }
                    }
                }
            }
            this.EndAlgorithm(theGraph);
            return result;
        }
    }
}
