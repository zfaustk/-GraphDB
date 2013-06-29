using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Structure
{
    public class Graph : DBObject, IGraph
    {
        #region EventHandler
        public delegate void GraphVertexEventHandler(object sender, IVertex v);
        public event GraphVertexEventHandler OnAddVertex = new GraphVertexEventHandler(GraphVertexEvent);
        public event GraphVertexEventHandler OnRemoveVertex = new GraphVertexEventHandler(GraphVertexEvent);
        public delegate void GraphEdgeEventHandler(object sender, IEdge e);
        public event GraphEdgeEventHandler OnAddEdge = new GraphEdgeEventHandler(GraphEdgeEvent);
        public event GraphEdgeEventHandler OnRemoveEdge = new GraphEdgeEventHandler(GraphEdgeEvent);
        public delegate void GraphTypeEventHandler(object sender, IType t);
        public event GraphTypeEventHandler OnAddType = new GraphTypeEventHandler(GraphTypeEvent);
        public event GraphTypeEventHandler OnRemoveType = new GraphTypeEventHandler(GraphTypeEvent);
        public static void GraphVertexEvent(object sender, IVertex v) { ; }
        public static void GraphEdgeEvent(object sender, IEdge v) { ; }
        public static void GraphTypeEvent(object sender, IType v) { ; }
        #endregion
        

        #region private members

        private HashSet<IVertex> _Vertices;

        private HashSet<IEdge> _Edges;

        private HashSet<IType> _Types;

        private Int64 _VertexCount;

        private Int64 _EdgeCount;

        private Int64 _TypeCount;

        private bool _IsDirected;

        #endregion

        #region constructors

        public Graph() : this(null,null){}

        public Graph(string ID)
        {
            InitDBObject(ID);
            InitGraph();
        }

        public Graph(IDictionary<string, object> theAttributes)
        {
            InitDBObject(theAttributes);
            InitGraph();
        }

        public Graph(string ID, IDictionary<string, object> theAttributes)
        {
            InitDBObject(ID, theAttributes);
            InitGraph();
        }

        private void InitGraph()
        {
            _Vertices = new HashSet<IVertex>();
            _Edges = new HashSet<IEdge>();
            _Types = new HashSet<IType>();

            _VertexCount = 0;
            _EdgeCount = 0;
            _TypeCount = 0;

            //Vertex vRoot = new Vertex(new Dictionary<string, object>() {
            //    {"root",true},{"Name","root"}
            //});
            //this.AddVertex(vRoot);

            //KHGraphDB.Structure.Type tUn = new KHGraphDB.Structure.Type(new Dictionary<string, object>() { 
            //    {"Name","UnTyped"}
            //});
            //this.AddType(tUn);

            _IsDirected = true;
        }
        #endregion

        #region IGraph

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

        public IEnumerable<IType> Types
        {
            get
            {
                foreach (var t in _Types)
                {
                    yield return t;
                }
            }
        }

        public IEnumerable<IEdge> Edges
        {
            get
            {
                foreach (var edge in _Edges)
                {
                    yield return edge;
                }
            }
        }

        public long VertexCount
        {
            get { return _VertexCount; }
        }

        public long EdgeCount
        {
            get { return _EdgeCount; }
        }

        public long TypeCount
        {
            get { return _TypeCount; }
        }

        public bool IsDirected
        {
            get
            {
                return _IsDirected;
            }
        }

        #region Vertices

        #region Add

        public IVertex AddVertex(IDictionary<string, object> attributes)
        {
            return AddVertex(attributes,null);
        }

        public IVertex AddVertex(IDictionary<string, object> attributes, IType theType)
        {
            var v = new Vertex(attributes);
            if (AddVertex(v, theType))
                return v;
            else
                return null;
        }


        public bool AddVertex(IVertex theVertex)
        {
            if (AddVertex(theVertex, null))
                return true;
            else
                return false;
        }

        public bool AddVertex(IVertex theVertex, IType theType)
        {
            if (theVertex == null) return false;

            IVertex v = Vertices.SingleOrDefault(m => m.KHID == theVertex.KHID);
            if (v != null && v != theVertex) return false;


            if (_Vertices.Contains(theVertex))
            {
                if (theType != null)
                    theType.AddVertex(theVertex);
                return true;
            }

            if (_Vertices.Add(theVertex))
            {
                theVertex.Graph = this;
                _VertexCount++;
                if(theType != null)
                    theType.AddVertex(theVertex);

                OnAddVertex(this, theVertex); //Event

                return true;
            }

            return false;
            
        }

        public IEnumerable<IVertex> AddVertices(IEnumerable<IVertex> vertices)
        {
            return AddVertices(vertices,null);
        }

        public IEnumerable<IVertex> AddVertices(IEnumerable<IVertex> vertices, IType theType)
        {
            var nonAddedVertices = new List<IVertex>();

            foreach (var vertex in vertices)
            {
                if (!AddVertex(vertex, theType))
                {
                    nonAddedVertices.Add(vertex);
                }
            }
            return nonAddedVertices;
        }

        #endregion

        #region Remove

        public bool RemoveVertex(IVertex theVertex)
        {
            if (theVertex == null) return false;
            if (_Vertices.Contains(theVertex))
            {
                List<IEdge> removeEdges = null;

                foreach (var edge in _Edges)
                {
                    removeEdges = new List<IEdge>();

                    if (edge.Source.Equals(theVertex) || edge.Target.Equals(theVertex))
                    {
                        removeEdges.Add(edge);
                        _EdgeCount--;
                    }

                    foreach (var remEdge in removeEdges)
                    {
                        _Edges.Remove(remEdge);
                    }
                }

                theVertex.Type.RemoveVertex(theVertex);
                _Vertices.Remove(theVertex);

                _VertexCount--;

                OnRemoveVertex(this, theVertex); //Event

                return true;
            }

            return false;
        }

        public IEnumerable<IVertex> RemoveVertices(IEnumerable<IVertex> theVertices)
        {
            var nonRemovedVertices = new List<IVertex>();

            foreach (var vertex in theVertices)
            {
                if (!RemoveVertex(vertex))
                {
                    nonRemovedVertices.Add(vertex);
                }
            }

            return nonRemovedVertices;
        }

        #endregion

        #region Degree

        public long VertexDegree(IVertex theVertex)
        {
            return VertexInDegree(theVertex) + VertexOutDegree(theVertex);
        }

        public long VertexInDegree(IVertex theVertex)
        {
            return (_Vertices.Contains(theVertex)) ? theVertex.InDegree : 0;
        }

        public long VertexOutDegree(IVertex theVertex)
        {
            return (_Vertices.Contains(theVertex)) ? theVertex.OutDegree : 0;
        }

        #endregion

        #region Relative Edges

        public IEnumerable<IEdge> VertexOutgoingEdges(IVertex theVertex)
        {
            return (_Vertices.Contains(theVertex)) ? theVertex.OutgoingEdges : null;
        }

        public IEnumerable<IEdge> VertexIncomingEdges(IVertex theVertex)
        {
            return (_Vertices.Contains(theVertex)) ? theVertex.IncomingEdges : null;
        }

        #endregion

        #endregion

        #region Types

        #region Add

        
        public bool AddType(IType theType)
        {
            if (theType == null) return false;

            IType t = Types.SingleOrDefault(m => m.KHID == theType.KHID);
            if (t != null && t != theType) return false;

            if(_Types.Contains(theType))return true;


            if (_Types.Add(theType))
            {
                theType.Graph = this;
                OnAddType(this, theType);
                return true;

            }
            return false;
        }

        public IType AddType(IDictionary<string, object> attributes)
        {
            Type t = new Type(attributes);
            return AddType(t) ? t : null ;
        }

        public IEnumerable<IType> AddTypes(IEnumerable<IType> types)
        {
            var nonAddedTypes = new List<IType>();
            foreach (var type in types)
            {
                if (!AddType(type))
                {
                    nonAddedTypes.Add(type);
                }
            }
            return nonAddedTypes;
        }

        #endregion

        #region Remove
        public bool RemoveType(IType theType)
        {
            if (theType == null) return false;
            if (_Types.Contains(theType))
            {
                foreach (var v in theType.Vertices)
                {
                    v.Type = null;
                }
                theType.ClearVertex();
                _Types.Remove(theType);
                OnRemoveType(this, theType);
                return true;
            }
            return false;
        }

        public IEnumerable<IType> RemoveTypes(IEnumerable<IType> types)
        {
            var nonRemovedTypes = new List<IType>();

            foreach (var t in types)
            {
                if (!RemoveType(t))
                {
                    nonRemovedTypes.Add(t);
                }

            }

            return nonRemovedTypes;
        }

        #endregion

        #endregion

        #region Edges

        #region Add

        public bool AddEdge(IEdge theEdge)
        {
            if (theEdge == null) return false;

            IEdge e = Edges.SingleOrDefault(m => m.KHID == theEdge.KHID);
            if (e != null && e != theEdge ) return false;

            if (!_Edges.Contains(theEdge)
                && _Vertices.Contains(theEdge.Source)
                && _Vertices.Contains(theEdge.Target))
            {
                var source = theEdge.Source as Vertex;
                var target = theEdge.Target as Vertex;

                var added = source.AddOutgoingEdge(theEdge);

                if (added)
                {
                    // use the same edge as incoming edge for target vertex
                    added = target.AddIncomingEdge(theEdge);
                    if (added)
                    {
                        if (_Edges.Add(theEdge))
                        {
                            theEdge.Graph = this;
                            _EdgeCount++;
                            OnAddEdge(this, theEdge);
                            return true;
                        }
                    }
                    else
                    {
                        source.RemoveOutgoingEdge(theEdge);
                    }
                }
                return false;
            }

            return true;
        }

        public IEnumerable<IEdge> AddEdges(IEnumerable<IEdge> theEdges)
        {
            var nonAddedEdges = new List<IEdge>();

            foreach (var edge in theEdges)
            {
                if (!AddEdge(edge))
                {
                    nonAddedEdges.Add(edge);
                }
            }

            return nonAddedEdges;
        }

        public IEdge AddEdge(IVertex theSource, IVertex theTarget)
        {
            return AddEdge(theSource, theTarget, null);
        }

        public IEdge AddEdge(IVertex theSource, IVertex theTarget, IDictionary<string, object> theAttributes)
        {
            var e = new Edge(theSource, theTarget, theAttributes);
            return (AddEdge(e)) ? e : null;
        }

        #endregion

        #region Remove

        public bool RemoveEdge(IEdge theEdge)
        {
            if (_Edges.Remove(theEdge))
            {
                _EdgeCount--;
                OnRemoveEdge(this, theEdge);
                return true;
            }
            return false;
        }

        public IEnumerable<IEdge> RemoveEdges(IEnumerable<IEdge> theEdges)
        {
            var nonRemovedEdges = new List<IEdge>();

            foreach (var edge in theEdges)
            {
                if (!RemoveEdge(edge))
                {
                    nonRemovedEdges.Add(edge);
                }
            }

            return nonRemovedEdges;
        }

        #endregion

        #endregion

        #endregion



    }
}
