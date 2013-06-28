using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Helper
{
    public class GraphHelper
    {
        /// <summary>
        /// 获取和设置相关联的图
        /// </summary>
        IGraph Graph { get { return _Graph; } set { _Graph = value; } }
        IGraph _Graph;

        public GraphHelper(IGraph g)
        {
            Graph = g;
        }

        #region Vertex

        #region Add

        public IVertex AddVertex(IVertex v, KHGraphDB.Structure.Type type = null)
        {
            if (v != null && Graph.Equals(v.Graph)) return v;

            if (Graph.AddVertex(v, type))
                return v;

            return null;
        }

        public IVertex AddVertex(IDictionary<string, object> theAttributes, KHGraphDB.Structure.Type type = null)
        {
            return AddVertex(null, theAttributes, type);
        }

        public IVertex AddVertex(string ID, IDictionary<string, object> theAttributes, KHGraphDB.Structure.Type type = null)
        {
            IVertex v = new Vertex(ID, theAttributes);
            return AddVertex(v, type);
        }

        #endregion

        #region Remove
        public bool RemoveVertex(string ID)
        {
            IVertex v = Graph.Vertices.SingleOrDefault(m => m.KHID == ID);
            return RemoveVertex(v);
        }

        public bool RemoveVertex(IVertex v)
        {
            return Graph.RemoveVertex(v);
        }
        #endregion

        #region select

        public IVertex SelectSingleVertex(string ID)
        {
            return Graph.Vertices.SingleOrDefault(m => m.KHID == ID);
        }

        public IVertex SelectSingleVertex(string key, object value)
        {
            return Graph.Vertices.SingleOrDefault(m => m[key] == value);
        }

        public IEnumerable<IVertex> SelectVerteics(string key, object value, string orderbyKey = null, IEnumerable<IVertex> vertics = null)
        {
            return from v in (null == vertics) ? Graph.Vertices : vertics
                   where v[key] == value
                   orderby (orderbyKey == null) ? null : v[orderbyKey]
                   select v;
        }

        public IEnumerable<IVertex> SelectVerteics(string key, object value, IType type,string orderbyKey = null)
        {
            if (null == type)
                return new HashSet<Vertex>();
            return from v in type.Vertices
                   where v[key] == value
                   orderby (orderbyKey == null) ? null : v[orderbyKey]
                   select v;
        }

        #endregion

        #endregion

        #region Edge

        #region Add

        public IEdge AddEdge(IEdge e)
        {
            if (e != null && Graph.Equals(e.Graph)) return e;
            if(Graph.AddEdge(e))
                return e;
            return null;
        }

        public IEdge AddEdge(IVertex vSource, IVertex vTarget, IDictionary<string, object> theAttributes = null)
        {
            return AddEdge(null, vSource, vTarget, theAttributes);
        }

        public IEdge AddEdge(string ID, IVertex vSource, IVertex vTarget, IDictionary<string, object> theAttributes = null)
        {
            IEdge e = new Edge(ID, vSource, vTarget, theAttributes);
            return AddEdge(e);
        }

        #endregion

        #region Remove
        public bool RemoveEdge(string ID)
        {
            IEdge e = Graph.Edges.SingleOrDefault(m => m.KHID == ID);
            return RemoveEdge(e);
        }

        public bool RemoveEdge(IEdge e)
        {
            return Graph.RemoveEdge(e);
        }
        #endregion

        #region select

        public IEdge SelectSingleEdge(string ID)
        {
            return Graph.Edges.SingleOrDefault(m => m.KHID == ID);
        }

        public IEdge SelectSingleEdge(string key, object value)
        {
            return Graph.Edges.SingleOrDefault(m => m[key] == value);
        }

        public IEnumerable<IEdge> SelectEdges(string key, object value, string orderbyKey = null, IEnumerable<IEdge> edges = null)
        {
            return from e in (edges == null)?Graph.Edges:edges
                   where e[key] == value
                   orderby (orderbyKey == null) ? null : e[orderbyKey]
                   select e;
        }

        public IEnumerable<IEdge> SelectEdges(string key, object value, IVertex vSource, IVertex vTarget, string orderbyKey = null, IEnumerable<IEdge> edges = null)
        {
            return from e in (edges == null) ? Graph.Edges : edges
                   where e[key] == value && 
                        (vSource == null)? e.Source.Equals(vSource) : true &&
                        (vSource == null) ? e.Target.Equals(vTarget) : true 
                   orderby (orderbyKey == null) ? null : e[orderbyKey]
                   select e;
        }

        public IEnumerable<IEdge> SelectParallelEdges(IEdge edge, string orderbyKey = null, IEnumerable<IEdge> edges = null)
        {
            return SelectParallelEdges(edge.Source, edge.Target, orderbyKey, edges);
        }

        public IEnumerable<IEdge> SelectParallelEdges(IVertex vSource, IVertex vTarget, string orderbyKey = null,IEnumerable<IEdge> edges = null)
        {
            if (vSource == null || vTarget == null ) return new HashSet<Edge>();
            if ( vSource.OutDegree < vTarget.InDegree)
                return from e in vSource.OutgoingEdges
                       where e.Target.Equals(vTarget) && (edges == null)?true:edges.Contains(e)
                       orderby (orderbyKey == null) ? null : e[orderbyKey]
                       select e;
            else
                return from e in vTarget.IncomingEdges
                       where e.Source.Equals(vSource) && (edges == null) ? true : edges.Contains(e)
                       orderby (orderbyKey == null) ? null : e[orderbyKey]
                       select e;
        }

        #endregion

        #endregion

    }
}
