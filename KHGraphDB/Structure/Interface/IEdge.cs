using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDB.Structure.Interface
{
    public interface IEdge : IDBObject
    {
        #region Properties

        IGraph Graph { get; set; }

        IVertex Source { get; }

        IVertex Target { get; }

        #endregion
    }
}
