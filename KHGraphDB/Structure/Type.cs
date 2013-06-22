using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Structure
{
    public class Type : DBObject , IType
    {

        #region Private Attributes

        private IGraph _Graph;

        private HashSet<IVertex> _Vertices;

        Int64 _VertexCount;

        #endregion


        public Type():
            this(null){
        }

        public Type(IDictionary<string, object> theAttributes)
        {
            InitDBObject(theAttributes);
            InitType();
        }

        private void InitType()
        {
            _Vertices = new HashSet<IVertex>();
            _VertexCount = 0;
        }

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

        public IEnumerable<IVertex> Vertices
        {
            get
            {
                foreach (var v in _Vertices)
                {
                    yield return v;
                }
            } 
        }

        public bool AddVertex(IVertex theVertex)
        {
            if (!theVertex.Graph.Equals(_Graph)) return false;
            if (_Vertices.Contains(theVertex))
            {
                return false;
            }

            if (_Vertices.Add(theVertex))
            {
                theVertex.Type = this;
                _VertexCount++;
            }

            return true;
        }

        public IEnumerable<IVertex> AddVertices(IEnumerable<IVertex> Vertices)
        {
            var nonAddedVertices = new List<IVertex>();
            foreach (var vertex in Vertices)
            {
                if (!AddVertex(vertex))
                {
                    nonAddedVertices.Add(vertex);
                }
            }
            return nonAddedVertices;
        }

        public bool RemoveVertex(IVertex theVertex)
        {
            if (_Vertices.Contains(theVertex))
            {
                if(_Vertices.Remove(theVertex))
                    _VertexCount--;
                return true;
            }
            return false;
        }

        public void ClearVertex()
        {
            _Vertices.Clear();
            _VertexCount = 0;
        }

        public IEnumerable<IVertex> RemoveVertices(IEnumerable<IVertex> Vertices)
        {
            var nonRemovedVertices = new List<IVertex>();

            foreach (var vertex in Vertices)
            {
                if (!RemoveVertex(vertex))
                {
                    nonRemovedVertices.Add(vertex);
                }
            }

            return nonRemovedVertices;
        }
    }
}
