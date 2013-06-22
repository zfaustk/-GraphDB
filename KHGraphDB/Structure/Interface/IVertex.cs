using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDB.Structure.Interface
{
    public interface IVertex : IDBObject
    {
        #region used for benchmarks

        Boolean IsVisited { get; set; }

        Int32   Distance { get; set; }

        IVertex Predecessor { get; set; }

        #endregion

        #region Graph

        /// <summary>
        /// Connect to the corresponding graph.
        /// </summary>
        IGraph Graph { get; set; }

        #endregion

        #region Type

        IType Type { get; set; }

        #endregion

        #region Degree

        /// <summary>
        /// Get the total number of edges.
        /// </summary>
        Int64 Degree { get; }
        /// <summary>
        /// Get the number of incoming edges.
        /// </summary>
        Int64 InDegree { get; }
        /// <summary>
        /// Get the number of outgoing edges.
        /// </summary>
        Int64 OutDegree { get; }

        #endregion

        #region Relative Edges

        /// <summary>
        /// Get all outgoing edges.
        /// </summary>
        IEnumerable<IEdge> OutgoingEdges { get; }

        /// <summary>
        /// Get all incoming edges.
        /// </summary>
        IEnumerable<IEdge> IncomingEdges { get; }

        

        #endregion
    }
}
