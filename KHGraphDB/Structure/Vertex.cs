using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Structure
{
    public class Vertex : DBObject, IVertex
    {
        #region used for benchmarks

        public Boolean IsVisited { get; set; }

        public Int32 Distance { get; set; }

        public IVertex Predecessor { get; set; }

        #endregion

        #region Private Attributes

        private IGraph _Graph = null;

        private IType _Type = null;

        private HashSet<IEdge> _OutgoingEdges;

        private HashSet<IEdge> _IncomingEdges;

        #endregion

        #region Constructors

        public Vertex()
            : this(null, null) { }

        public Vertex(string ID)
            : this(ID, null) { }

        public Vertex(IDictionary<string, object> theAttributes)
            : this(null, theAttributes) { }

        public Vertex(string ID,IDictionary<string, object> theAttributes)
        {
            InitDBObject(theAttributes);
            InitVertex();
        }

        private void InitVertex()
        {
            _OutgoingEdges = new HashSet<IEdge>();
            _IncomingEdges = new HashSet<IEdge>();
        }

        #endregion

        #region Properties

        public IGraph Graph
        {
            get
            {
                return _Graph;
            }
            set
            {
                _Graph = value;
            }
        }

        public IType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        public IEnumerable<IEdge> OutgoingEdges
        {
            get
            {
                return _OutgoingEdges;
            }
        }

        public IEnumerable<IEdge> IncomingEdges
        {
            get
            {
                return _IncomingEdges;
            }
        }

        #endregion

        #region Degree

        public long Degree
        {
            get
            {
                return _OutgoingEdges.Count + _IncomingEdges.Count;
            }
        }

        public long InDegree
        {
            get
            {
                return _IncomingEdges.Count;
            }
        }

        public long OutDegree
        {
            get
            {
                return _OutgoingEdges.Count;
            }
        }

        #endregion

        #region Relative Edges

        public bool AddIncomingEdge(IEdge theEdge)
        {
            if (_IncomingEdges.Add(theEdge))
            {
                return true;
            }
            return false;
        }

        public bool RemoveIncomingEdge(IEdge theEdge)
        {
            if (_IncomingEdges.Remove(theEdge))
            {
                return true;
            }
            return false;
        }

        public bool AddOutgoingEdge(IEdge theEdge)
        {
            if (_OutgoingEdges.Add(theEdge))
            {
                return true;
            }
            return false;
        }

        public bool RemoveOutgoingEdge(IEdge theEdge)
        {
            if (_OutgoingEdges.Remove(theEdge))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region override
        public override string AttributesToString()
        {
            string s = base.AttributesToString();
            if (this.Type == null)
                s += "Type : null \n";
            else{
                if (Type["name"] != null)
                    s += "Type :" + Type["name"].ToString() + " \n";
                else
                    s += "Type :" + Type.KHID + " \n";
            }
            s += "InDegree : " + InDegree + " \n";
            s += "OutDegree : " + OutDegree + " \n";
            return s;
        }

        #endregion

    }
}
