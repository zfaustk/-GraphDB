using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDB.Structure.Interface
{
    /// <summary>
    /// root interface for describing a graph.
    /// </summary>
    public interface IGraph : IDBObject
    {
        #region Properties

        /// <summary>
        /// Return true if the graph is directed
        /// </summary>
        bool IsDirected { get; }

        /// <summary>
        /// Vertices
        /// </summary>
        IEnumerable<IVertex> Vertices { get; }

        /// <summary>
        /// Edges
        /// </summary>
        IEnumerable<IEdge> Edges { get; }

        /// <summary>
        /// Types
        /// </summary>
        IEnumerable<IType> Types { get; }

        /// <summary>
        /// Get number of vertices
        /// </summary>
        Int64 VertexCount { get; }

        /// <summary>
        /// Get number of edges
        /// </summary>
        Int64 EdgeCount { get; }

        #endregion

        #region Methods

        #region Type

        #region Add

        IType AddType(IDictionary<string, object> attributes);

        bool AddType(IType theType);

        /// <returns>The vertices which were not added</returns>
        IEnumerable<IType> AddTypes(IEnumerable<IType> types);

        #endregion

        #region Remove

        /// <summary>
        /// Removes a type from the graph if it exists.
        /// </summary>
        bool RemoveType(IType theType);

        /// <returns>Types which were been removed</returns>
        IEnumerable<IType> RemoveTypes(IEnumerable<IType> types);

        #endregion

        #endregion

        #region Vertices

        #region Add

        IVertex AddVertex(IDictionary<string, object> Attributes);

        IVertex AddVertex(IDictionary<string, object> attributes, IType theType);

        bool AddVertex(IVertex theVertex);

        bool AddVertex(IVertex theVertex, IType theType);

        /// <returns>The vertices which were not added</returns>
        IEnumerable<IVertex> AddVertices(IEnumerable<IVertex> Vertices);

        IEnumerable<IVertex> AddVertices(IEnumerable<IVertex> vertices, IType theType);

        #endregion

        #region Remove

        /// <summary>
        /// Removes a vertex from the graph if it exists.
        /// </summary>
        bool RemoveVertex(IVertex theVertex);

        /// <returns>The vertices which were been removed</returns>
        IEnumerable<IVertex> RemoveVertices(IEnumerable<IVertex> Vertices);

        #endregion

        #region Degree

        Int64 VertexDegree(IVertex theVertex);

        Int64 VertexInDegree(IVertex theVertex);

        Int64 VertexOutDegree(IVertex theVertex);

        #endregion

        #region Relative Edges

        IEnumerable<IEdge> VertexOutgoingEdges(IVertex theVertex);

        IEnumerable<IEdge> VertexIncomingEdges(IVertex theVertex);

        #endregion

        #endregion

        #region Edges

        #region Add

        bool AddEdge(IEdge theEdge);

        IEnumerable<IEdge> AddEdges(IEnumerable<IEdge> theEdges);

        IEdge AddEdge(IVertex theSource, IVertex theTarget);

        IEdge AddEdge(IVertex theSource, IVertex theTarget, IDictionary<string, object> theAttributes);
      
        #endregion

        #region Remove

        bool RemoveEdge(IEdge theEdge);

        IEnumerable<IEdge> RemoveEdges(IEnumerable<IEdge> theEdges);

        #endregion

        #endregion

        #endregion

    }
}
