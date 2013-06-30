using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;

namespace KH_GraphControls.GraphPanel
{
    public sealed class VertexEventArgs : EventArgs
    {
        public VertexEventArgs(Vertex vertex) { Vertex = vertex; }
        public Vertex Vertex { get; private set; }
    }

    public sealed class DBObjectEventArgs : EventArgs
    {
        public DBObjectEventArgs(IDBObject dbobject) { DBObject = dbobject; }
        public IDBObject DBObject { get; private set; }
    }

    public sealed class AcceptVertexEventArgs : CancelEventArgs
    {
        public AcceptVertexEventArgs(Vertex vertex) { Vertex = vertex; }
        public AcceptVertexEventArgs(Vertex vertex, bool cancel) : base(cancel) { Vertex = vertex; }
        public Vertex Vertex { get; private set; }
    }

    public sealed class EdgeEventArgs : EventArgs
    {
        public EdgeEventArgs(Edge edge) { Connection = edge; Source = edge.Source; Target = edge.Target; }
        public EdgeEventArgs(IVertex from, IVertex to, Edge edge) { Connection = edge; Source = edge.Source; Target = edge.Target; }
        public IVertex Source { get; set; }
        public IVertex Target { get; set; }
        public Edge Connection { get; private set; }
    }

    public sealed class AcceptEdgeEventArgs : CancelEventArgs
    {
        public AcceptEdgeEventArgs(Edge edge) { Connection = edge; }
        public AcceptEdgeEventArgs(Edge edge, bool cancel) : base(cancel) { Connection = edge; }
        public Edge Connection { get; private set; }
    }
}
