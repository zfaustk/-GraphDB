using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Algorithm
{
    public class BreadthFirstSearch : Algorithm , IAlgorithm
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
            COLOR_ATTRIBUTE_KEY         = KHID + "__color";
            DISTANCE_ATTRIBUTE_KEY      = KHID + "__dist";
            PREDECESSOR_ATTRIBUTE_KEY   = KHID + "__pred";
            
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

        #region Search

        public List<IVertex> Search(IGraph theGraph, IVertex theSource, IVertex theTarget, Func<IVertex, bool> theMatchingFunc = null)
        {
            return Search(theGraph, theSource, theTarget, true, theMatchingFunc);
        }

        /// <summary>
        /// BFS for st-connectivity
        /// </summary>
        /// <param name="theGraph"></param>
        /// <param name="theSource"></param>
        /// <param name="theTarget"></param>
        /// <param name="theMatchingFunc"></param>
        /// <returns></returns>
        public List<IVertex> Search(IGraph theGraph, IVertex theSource, IVertex theTarget, bool Reverted, Func<IVertex, bool> theMatchingFunc = null)
        {
            #region Init

            this.BeginAlgorithm(theGraph);

            theSource.AlgorithmObjs[COLOR_ATTRIBUTE_KEY] = Color.RED;
            theSource.AlgorithmObjs[PREDECESSOR_ATTRIBUTE_KEY] = null;
            theTarget.AlgorithmObjs[COLOR_ATTRIBUTE_KEY] = Color.GREEN;
            theTarget.AlgorithmObjs[PREDECESSOR_ATTRIBUTE_KEY] = null;

            // bool if matching function has to be called
            var doMatching = theMatchingFunc != null;

            // used to indicate that the target vertex has been found
            var done = false;

            // use Concurrent Queue for parallel access
            var queue = new Queue<IVertex>();

            IVertex u = null;

            #endregion

            #region BFS

            // enqueue the source vertex
            queue.Enqueue(theSource);

            while (queue.Count > 0 && !done)
            {
                u = queue.Dequeue();

                // process neighbours in parallel
                //Parallel.ForEach<IEdge>(u.OutgoingEdges, outEdge =>
                foreach (var outEdge in u.OutgoingEdges)
                {
                    // neighbour vertex
                    var v = outEdge.Target;
                    // get the color of that neighbour
                    var color = (Color)v.AlgorithmObjs[COLOR_ATTRIBUTE_KEY];

                    if (color == Color.WHITE) // not the target
                    {
                        // set as visited (Color.RED)
                        v.AlgorithmObjs[COLOR_ATTRIBUTE_KEY] = Color.RED;
                        // set the predecessor
                        v.AlgorithmObjs[PREDECESSOR_ATTRIBUTE_KEY] = u;
                        // and enqueue that vertex (if matching condition == true)
                        if (doMatching)
                        {
                            // matches condition?
                            if (theMatchingFunc(v))
                            {
                                // matches, enqueue
                                queue.Enqueue(v);
                            }
                            // do nothing
                        }
                        else
                        {
                            // no matching necessary
                            queue.Enqueue(v);
                        }
                    }
                    else if (color == Color.GREEN) // done
                    {
                        // finished
                        done = true;
                        // set the predecessor
                        v.SetAlgorithmObj(PREDECESSOR_ATTRIBUTE_KEY, u);
                    }
                }
                u.AlgorithmObjs[COLOR_ATTRIBUTE_KEY] = Color.RED;
            }

            #endregion

            if (done)
            {
                var path = new List<IVertex>();
                var tmp = theTarget;

                while (tmp != null)
                {
                    path.Add(tmp);
                    tmp = (IVertex)tmp.AlgorithmObjs[PREDECESSOR_ATTRIBUTE_KEY];
                }

                if (Reverted)
                {
                    path.Reverse();
                }
                this.EndAlgorithm(theGraph);

                return path;
            }

            this.EndAlgorithm(theGraph);
            return null;
        }

        #endregion

    }
}
