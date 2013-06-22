using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDB.Structure.Interface
{
    public interface IType : IDBObject
    {

        /// <summary>
        /// Connect to the corresponding graph.
        /// </summary>
        IGraph Graph { get; set; }

        /// <summary>
        /// Get all vertices
        /// </summary>
        IEnumerable<IVertex> Vertices { get; }

        #region Add

        bool AddVertex(IVertex theVertex);

        /// <returns>The vertices which were not added</returns>
        IEnumerable<IVertex> AddVertices(IEnumerable<IVertex> Vertices);

        #endregion

        #region Remove

        /// <summary>
        /// Removes a vertex from the graph if it exists.
        /// </summary>
        bool RemoveVertex(IVertex theVertex);

        void ClearVertex();
        /// <returns>The vertices which were been removed</returns>
        IEnumerable<IVertex> RemoveVertices(IEnumerable<IVertex> Vertices);

        #endregion

    }
}
