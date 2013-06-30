using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHGraphDB.Structure.Interface;
using KHGraphDB.Structure;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using KHGraphDB.Helper;

namespace KH_GraphControls.GraphPanel
{
    public partial class GraphPanel : Control 
    {
        public GraphPanel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserPaint, true);
        }

        #region 私有

        private PanelColorConfig panelColorConfig = new PanelColorConfig();
        private Graph _graph = new Graph();
        private Font _font = new Font("Melon", 10);
        private Font _Attrfont = new Font("Melon", 8);
        private Random Random = new Random();
        private string _KH_PANE_GRAPH_PRIOR = "_KH_PANE_GRAPH_PRIOR";
        private string _KH_PANE_LOCATION = "_KH_PANE_LOCATION";
        private string _KH_PANE_DEPTH = "_KH_PANE_DEPTH";
        private string _KH_PANE_BOUNDS = "_KH_PANE_BOUNDS";
        private GraphHelper ghelper;
        #endregion

        public override Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public Font AttrFont
        {
            get { return _Attrfont; }
            set { _Attrfont = value; }
        }

        public Graph Graph
        {
            get { return _graph; }
            set { InitialNewGraph(value); }
        }

        private void InitialNewGraph(Graph graph)
        {
            if (graph == null) return;
            if (_graph != null)
            {
                //TODO:删除旧有的图属性
            }

            _graph = graph;

            //TODO:Initial
            graph.SetAlgorithmObj(_KH_PANE_GRAPH_PRIOR, 0);
            Parallel.ForEach<IVertex>(Graph.Vertices, v =>
            {
                PointF location = new PointF(Random.Next(2, Width - 20), Random.Next(0, Height - 20));
                int radio = Random.Next(7, 12);
                RectangleF bound = new RectangleF(location.X - radio, location.Y - radio, radio * 2, radio*2);
                v.SetAlgorithmObj(_KH_PANE_LOCATION, location);
                v.SetAlgorithmObj(_KH_PANE_BOUNDS, bound);
                v.SetAlgorithmObj(_KH_PANE_GRAPH_PRIOR, 0);
                v.SetAlgorithmObj(Flags.State.None.ToString(), false);
                v.SetAlgorithmObj(Flags.State.Focus.ToString(), false);
                v.SetAlgorithmObj(Flags.State.Hover.ToString(), false);
                v.SetAlgorithmObj(Flags.State.DraggedOver.ToString(), false);
                v.SetAlgorithmObj(Flags.State.Dragging.ToString(), false);
                v.SetAlgorithmObj(Flags.State.HighLight.ToString(), false);
                v.OnAttributeGhange += OnAttributeChange;
            });

            Parallel.ForEach<IEdge>(Graph.Edges, e =>
            {
                e.SetAlgorithmObj(_KH_PANE_GRAPH_PRIOR, 0);
                e.SetAlgorithmObj(Flags.State.None.ToString(), false);
                e.SetAlgorithmObj(Flags.State.Focus.ToString(), false);
                e.SetAlgorithmObj(Flags.State.Hover.ToString(), false);
                e.SetAlgorithmObj(Flags.State.DraggedOver.ToString(), false);
                e.SetAlgorithmObj(Flags.State.Dragging.ToString(), false);
                e.SetAlgorithmObj(Flags.State.HighLight.ToString(), false);
                e.OnAttributeGhange += OnAttributeChange;
            });
            
            graph.OnAddVertex += OnAddVertex;
            graph.OnAddEdge += OnAddEdge;
            graph.OnAddType += OnAddType;
            graph.OnRemoveVertex += OnRemoveVertex;
            graph.OnRemoveEdge += OnRemoveEdge;
            graph.OnRemoveType += OnRemoveType;

            ghelper = new GraphHelper(_graph);

            this.Refresh();

        }


        #region Grapg Delegate
        private void OnAddVertex(object sender, IVertex vertex)
        {
            
            PointF location = new PointF(Random.Next(0, Width - 40), Random.Next(0, Height - 40));
            var points = new PointF[] { location };
            inverse_transformation.TransformPoints(points);
            location = new Point((int)points[0].X, (int)points[0].Y);

            int radio = Random.Next(6, 12);
            RectangleF bound = new RectangleF(location.X - radio, location.Y - radio, radio * 2, radio * 2);
            vertex.SetAlgorithmObj(_KH_PANE_LOCATION, location);
            vertex.SetAlgorithmObj(_KH_PANE_BOUNDS, bound);
            vertex.SetAlgorithmObj(_KH_PANE_GRAPH_PRIOR, 0);
            vertex.SetAlgorithmObj(Flags.State.None.ToString(), false);
            vertex.SetAlgorithmObj(Flags.State.Focus.ToString(), false);
            vertex.SetAlgorithmObj(Flags.State.Hover.ToString(), false);
            vertex.SetAlgorithmObj(Flags.State.DraggedOver.ToString(), false);
            vertex.SetAlgorithmObj(Flags.State.Dragging.ToString(), false);
            vertex.SetAlgorithmObj(Flags.State.HighLight.ToString(), false);
            vertex.OnAttributeGhange += OnAttributeChange;
            this.Refresh();
        }
        private void OnAddEdge(object sender, IEdge edge)
        {
            edge.SetAlgorithmObj(_KH_PANE_GRAPH_PRIOR, 0);
            edge.SetAlgorithmObj(_KH_PANE_BOUNDS, new RectangleF());
            edge.SetAlgorithmObj(Flags.State.None.ToString(), false);
            edge.SetAlgorithmObj(Flags.State.Focus.ToString(), false);
            edge.SetAlgorithmObj(Flags.State.Hover.ToString(), false);
            edge.SetAlgorithmObj(Flags.State.DraggedOver.ToString(), false);
            edge.SetAlgorithmObj(Flags.State.Dragging.ToString(), false);
            edge.SetAlgorithmObj(Flags.State.HighLight.ToString(), false);
            edge.OnAttributeGhange += OnAttributeChange;
            this.Refresh();
        }
        private void OnAddType(object sender, IType type)
        {
            this.Refresh();
        }
        private void OnRemoveVertex(object sender, IVertex vertex)
        {
            this.Refresh();
        }
        private void OnRemoveEdge(object sender, IEdge edge)
        {
            this.Refresh();
        }
        private void OnRemoveType(object sender, IType type)
        {
            this.Refresh();
        }
        private void OnAttributeChange(IDBObject sender)
        {
            HighLightOnce = sender;
        }
        #endregion

        #region handler
        public event EventHandler<DBObjectEventArgs>        FocusChanged    ;
        public event EventHandler<AcceptVertexEventArgs>    VertexAdded     ;
        public event EventHandler<AcceptVertexEventArgs>    VertexRemoving  ;
        public event EventHandler<VertexEventArgs>          VertexRemoved   ;
        public event EventHandler<AcceptEdgeEventArgs>      EdgeAdding      ;
        public event EventHandler<AcceptEdgeEventArgs>      EdgeAdded       ;
        public event EventHandler<AcceptEdgeEventArgs>      EdgeRemoving    ;
        public event EventHandler<EdgeEventArgs>            EdgeRemoved     ;
        #endregion

        #region UpdateMatrices
        PointF translation = new PointF();
        float zoom = 1.0f;
        readonly Matrix transformation = new Matrix();
        readonly Matrix inverse_transformation = new Matrix();
        void UpdateMatrices()
        {
            if (zoom < 0.25f) zoom = 0.25f;
            if (zoom > 5.00f) zoom = 5.00f;
            var center = new PointF(this.Width / 2.0f, this.Height / 2.0f);
            transformation.Reset();
            transformation.Translate(translation.X, translation.Y);
            transformation.Translate(center.X, center.Y);
            transformation.Scale(zoom, zoom);
            transformation.Translate(-center.X, -center.Y);

            inverse_transformation.Reset();
            inverse_transformation.Translate(center.X, center.Y);
            inverse_transformation.Scale(1.0f / zoom, 1.0f / zoom);
            inverse_transformation.Translate(-center.X, -center.Y);
            inverse_transformation.Translate(-translation.X, -translation.Y);
        }
        #endregion

        #region Find Object

        #region FindVertexAt
        IVertex FindVertexAt(PointF location)
        {
            foreach (var vertex in Graph.Vertices)
            {
                RectangleF bound = (RectangleF)vertex.GetAlgorithmObj(_KH_PANE_BOUNDS);
                if (bound.Contains(location))
                {
                    return vertex;
                }
            }
            return null;
        }
        #endregion

        #region FindEdgeAt
        IEdge FindInputEdgeAt(IVertex vertex, PointF location)
        {
            if (vertex.InDegree == 0)
                return null;

            PointF pointT = (PointF)vertex.GetAlgorithmObj(_KH_PANE_LOCATION);
            foreach (var incomingEdges in vertex.IncomingEdges)
            {
                PointF pointS = (PointF)incomingEdges.Source.GetAlgorithmObj(_KH_PANE_LOCATION);
                RectangleF bound = new RectangleF((pointS.X + pointT.X) / 2 - 3, (pointS.Y + pointT.Y) / 2 - 3, 6, 6);
                if (bound.IsEmpty)
                    continue;

                if (bound.Contains(location))
                    return incomingEdges;
            }
            return null;
        }

        IEdge FindEdgeAt(PointF location)
        {
            foreach (var e in Graph.Edges)
            {
                PointF pt = (PointF)e.Target.GetAlgorithmObj(_KH_PANE_LOCATION);
                PointF ps = (PointF)e.Source.GetAlgorithmObj(_KH_PANE_LOCATION);
                RectangleF bound = new RectangleF((pt.X * 2 + 3 * ps.X) / 5 - 4, (pt.Y * 2 + ps.Y * 3) / 5 - 4, 6, 6);
                if (bound.IsEmpty)
                    continue;

                if (bound.Contains(location))
                    return e;
            }
            return null;
        }
        #endregion

        #endregion

        #region override

        #region Mention Element

        void SetFlag(IDBObject obj, Flags.State state, bool Set)
        {
            obj.SetAlgorithmObj(state.ToString(), Set);
        }//检查这个tostring的用法

        #region DragElement
        IDBObject internalDragElement;
        IDBObject DragElement
        {
            get { return internalDragElement; }
            set
            {
                if (internalDragElement == value)
                    return;
                if (internalDragElement != null)
                    SetFlag(internalDragElement, Flags.State.Dragging, false);
                internalDragElement = value;
                if (internalDragElement != null)
                    SetFlag(internalDragElement, Flags.State.Dragging, true);
            }
        }
        #endregion

        #region HoverElement
        IDBObject internalHoverElement;
        IDBObject HoverElement
        {
            get { return internalHoverElement; }
            set
            {
                if (internalHoverElement == value)
                    return;
                if (internalHoverElement != null)
                    SetFlag(internalHoverElement, Flags.State.Hover, false);
                internalHoverElement = value;
                if (internalHoverElement != null)
                    SetFlag(internalHoverElement, Flags.State.Hover, true);
            }
        }
        #endregion

        #region FocusElement
        IDBObject internalFocusElement;
        public IDBObject FocusElement
        {
            get { return internalFocusElement; }
            set
            {
                if (internalFocusElement == value)
                    return;
                if (internalFocusElement != null)
                    SetFlag(internalFocusElement, Flags.State.Focus, false);
                internalFocusElement = value;
                if (internalFocusElement != null)
                    SetFlag(internalFocusElement, Flags.State.Focus, true);

                if (FocusChanged != null)
                    FocusChanged(this, new DBObjectEventArgs(value));

                this.Invalidate();
            }
        }
        #endregion
        #endregion


        #region Mouse
            MouseButtons currentButtons = MouseButtons.None;
            bool dragging = true;
            bool abortDrag = false;
            bool mouseMoved = false;
            Point lastLocation;
            PointF snappedLocation;
            PointF originalLocation;
            Point originalMouseLocation;
            enum CommandMode
            {
                None,
                TranslateView,
                ScaleView,
            }
            CommandMode command = CommandMode.None;
        #endregion

        #region OnMouseWheel
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            zoom *= (float)Math.Pow(2, e.Delta / 480.0f);

            this.Refresh();
        }
        #endregion

        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            if (currentButtons != MouseButtons.None)
                return;

            currentButtons |= e.Button;
            dragging = true;
            abortDrag = false;
            mouseMoved = false;
            snappedLocation = lastLocation = e.Location;

            var points = new PointF[] { e.Location };
            inverse_transformation.TransformPoints(points);
            var transformed_location = points[0];

            originalLocation = transformed_location;

            if (e.Button == MouseButtons.Left)
            {
                var vertex = FindVertexAt(transformed_location);
                if (vertex != null)
                {
                    var element_node = vertex;

                    FocusElement = DragElement = vertex;
                    BringElementToFront(vertex);
                    this.Refresh();
                }
            }
            else
            {
                DragElement = null;
                command = CommandMode.TranslateView;
            }

            points = new PointF[] { originalLocation };
            transformation.TransformPoints(points);
            originalMouseLocation = this.PointToScreen(new Point((int)points[0].X, (int)points[0].Y));
        }
        #endregion

        #region OnMouseMove
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (DragElement == null)
            {
                if (currentButtons == MouseButtons.Left)
                    command = CommandMode.TranslateView;
                else if (currentButtons == MouseButtons.Right)
                    command = CommandMode.ScaleView;
                else command = CommandMode.None;//
            }

            Point currentLocation;
            PointF transformed_location;
            if (abortDrag)
            {
                transformed_location = originalLocation;

                var points = new PointF[] { originalLocation };
                transformation.TransformPoints(points);
                currentLocation = new Point((int)points[0].X, (int)points[0].Y);
            }
            else
            {
                currentLocation = e.Location;

                var points = new PointF[] { currentLocation };
                inverse_transformation.TransformPoints(points);
                transformed_location = points[0];
            }

            var deltaX = (lastLocation.X - currentLocation.X) / zoom;
            var deltaY = (lastLocation.Y - currentLocation.Y) / zoom;

            bool needRedraw = false;
            switch (command)
            {
                case CommandMode.ScaleView:
                    if (!mouseMoved)
                    {
                        if ((Math.Abs(deltaY) > 1))
                            mouseMoved = true;
                    }

                    if (mouseMoved &&
                        (Math.Abs(deltaY) > 0))
                    {
                        zoom *= (float)Math.Pow(2, deltaY / 100.0f);
                        Cursor.Position = this.PointToScreen(lastLocation);
                        snappedLocation = //lastLocation = 
                            currentLocation;
                        this.Refresh();
                    }
                    return;
                case CommandMode.TranslateView:
                    {
                        if (!mouseMoved)
                        {
                            if ((Math.Abs(deltaX) > 1) ||
                                (Math.Abs(deltaY) > 1))
                                mouseMoved = true;
                        }

                        if (mouseMoved &&
                            (Math.Abs(deltaX) > 0) ||
                            (Math.Abs(deltaY) > 0))
                        {
                            translation.X -= deltaX * zoom;
                            translation.Y -= deltaY * zoom;
                            snappedLocation = lastLocation = currentLocation;
                            this.Refresh();
                        }
                        return;
                    }
            }

            if (dragging)
            {
                if (!mouseMoved)
                {
                    if ((Math.Abs(deltaX) > 1) ||
                        (Math.Abs(deltaY) > 1))
                        mouseMoved = true;
                }

                if (mouseMoved &&
                    (Math.Abs(deltaX) > 0) ||
                    (Math.Abs(deltaY) > 0))
                {
                    mouseMoved = true;
                    if (DragElement != null)
                    {
                        BringElementToFront(DragElement);

                        if (new Vertex().GetType().Equals(DragElement.GetType()))
                        {
                            var vertex = DragElement as Vertex;
                            PointF location = (PointF)vertex.GetAlgorithmObj(_KH_PANE_LOCATION);
                            RectangleF bounds = (RectangleF)vertex.GetAlgorithmObj(_KH_PANE_BOUNDS);
                            vertex.SetAlgorithmObj(_KH_PANE_LOCATION
                                , new PointF((int)Math.Round(location.X - deltaX),
                                           (int)Math.Round(location.Y - deltaY)) 
                            );
                            vertex.SetAlgorithmObj(_KH_PANE_BOUNDS
                                , new RectangleF(
                                    (int)Math.Round(bounds.X- deltaX),
                                    (int)Math.Round(bounds.Y - deltaY),
                                    (int)Math.Round(bounds.Width),
                                    (int)Math.Round(bounds.Height)
                                    )
                            );
                            snappedLocation = lastLocation = currentLocation;
                            this.Refresh();
                            return;
                        }
                    }
                }
            }

            //NodeConnector destinationConnector = null;
            //IElement draggingOverElement = null;

            IEdge elementEdge = FindEdgeAt(transformed_location);

            if (elementEdge != null)
            {
                if (HoverElement != elementEdge)
                {
                    HoverElement = elementEdge;
                    needRedraw = true;
                }
            }
            else
            {
                IVertex elementVertex = FindVertexAt(transformed_location);

                if (HoverElement != elementVertex)
                {
                    HoverElement = elementVertex;
                    needRedraw = true;
                }
            }
            
            
            if (needRedraw)
                this.Refresh();
        }
        #endregion

        #region OnMouseUp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            currentButtons &= ~e.Button;

            bool needRedraw = false;
            if (!dragging)
                return;

            try
            {
                Point currentLocation;
                PointF transformed_location;
                if (abortDrag)
                {
                    transformed_location = originalLocation;

                    var points = new PointF[] { originalLocation };
                    transformation.TransformPoints(points);
                    currentLocation = new Point((int)points[0].X, (int)points[0].Y);
                }
                else
                {
                    currentLocation = e.Location;

                    var points = new PointF[] { currentLocation };
                    inverse_transformation.TransformPoints(points);
                    transformed_location = points[0];
                }

                if (DragElement != null)
                {
                    DragElement = null;
                    needRedraw = true;
                }
                
            }
            finally
            {
                if (DragElement != null)
                {
                    DragElement = null;
                    needRedraw = true;
                }

                dragging = false;
                command = CommandMode.None;

                if (needRedraw)
                    this.Refresh();

                base.OnMouseUp(e);
            }
        }
        #endregion

        #region BringElementToFront
        public void BringElementToFront(IDBObject element)
        {
            if (element == null)
                return;
            int graphPrior = (int)Graph.GetAlgorithmObj(_KH_PANE_GRAPH_PRIOR);
            if (new Edge(new Vertex(),new Vertex()).GetType().Equals(element.GetType()))
            {
                Edge e = (Edge)element;
                e.SetAlgorithmObj(_KH_PANE_GRAPH_PRIOR, graphPrior);
            }
            if(new Vertex().GetType().Equals(element.GetType())){
                Vertex e = (Vertex)element;
                graphPrior += 1;
                e.SetAlgorithmObj(_KH_PANE_GRAPH_PRIOR, graphPrior);
                foreach (Edge ei in e.IncomingEdges)
                {
                    BringElementToFront(ei);
                }
                foreach (Edge eo in e.OutgoingEdges)
                {
                    BringElementToFront(eo);
                }
            }
        }
        #endregion

        #region HighLight
        public IEnumerable<IDBObject> HighLightList
        {
            get { return _HighLightList; }
            set {
                if (_HighLightList != null)
                {
                    foreach (var obj in _HighLightList)
                        obj.SetAlgorithmObj(Flags.State.HighLight.ToString(), false);
                }
                _HighLightList = value;
                if(_HighLightList != null)
                    foreach (var obj in _HighLightList)
                        obj.SetAlgorithmObj(Flags.State.HighLight.ToString(), true);
                this.Refresh();
            }
        }
        private IEnumerable<IDBObject> _HighLightList = null;

        public IDBObject HighLightOnce
        {
            set
            {
                if (value == null) return;
                if (new Vertex().GetType().Equals(value.GetType()))
                {
                    Vertex v = (Vertex)value;
                    v.SetAlgorithmObj(Flags.State.HighLight.ToString(), true);
                    this.Refresh();
                    v.SetAlgorithmObj(Flags.State.HighLight.ToString(), false);
                }
                else if (new Edge(new Vertex(), new Vertex()).GetType().Equals(value.GetType()))
                {
                    Edge e = (Edge)value;
                    e.SetAlgorithmObj(Flags.State.HighLight.ToString(), true);
                    this.Refresh();
                    e.SetAlgorithmObj(Flags.State.HighLight.ToString(), false);
                }
            }
        }
        #endregion

        #region OnPaint
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (e.Graphics == null)
                return;

            e.Graphics.Clear(panelColorConfig.BackGroundColor);

            if (this._graph.VertexCount == 0)
                return;

            UpdateMatrices();
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            IVertex hoverVertex = null;
            IEdge hoverEdge = null;

            e.Graphics.Transform = transformation;

            foreach (Edge edge in Graph.Edges)
            {
                var ps = (PointF)edge.Source.AlgorithmObjs[_KH_PANE_LOCATION];
                var pt = (PointF)edge.Target.AlgorithmObjs[_KH_PANE_LOCATION];
                var hover = (bool)edge.GetAlgorithmObj(Flags.State.Hover.ToString());
                var highlight = (bool)edge.GetAlgorithmObj(Flags.State.HighLight.ToString());
                Render.DrawEdge(e.Graphics, edge, ps, pt, highlight);
                if (hover) hoverEdge = edge;
            }

            foreach (Vertex v in Graph.Vertices)
            {
                var p = (PointF)v.AlgorithmObjs[_KH_PANE_LOCATION];
                var rect = (RectangleF)v.AlgorithmObjs[_KH_PANE_BOUNDS];
                var hover = (bool)v.GetAlgorithmObj(Flags.State.Hover.ToString());
                var highlight = (bool)v.GetAlgorithmObj(Flags.State.HighLight.ToString());
                Render.DrawVertex(e.Graphics, v, Font, p, rect, highlight);
                
                if (hover) hoverVertex = v;
            }

            if (hoverEdge != null) OnPaint_DrawEdgesInfo(e.Graphics, hoverEdge, ghelper.SelectParallelEdges(hoverEdge));
            if (hoverVertex != null) OnPaint_DrawVertexInfo(e.Graphics, hoverVertex);
        }

        protected void OnPaint_DrawVertexInfo(Graphics g,IVertex v)
        {      
            PointF location = (PointF)v.GetAlgorithmObj(_KH_PANE_LOCATION);
            RectangleF rect = (RectangleF)v.GetAlgorithmObj(_KH_PANE_BOUNDS);
            Render.DrawVertexSelected(g, v, _Attrfont, location, rect);
        }

        protected void OnPaint_DrawEdgeInfo(Graphics g, IEdge e)
        {
            var ps = (PointF)e.Source.GetAlgorithmObj(_KH_PANE_LOCATION);
            var pt = (PointF)e.Target.GetAlgorithmObj(_KH_PANE_LOCATION);
            Render.DrawEdgeSelected(g, e, _Attrfont, ps, pt);
        }

        protected void OnPaint_DrawEdgesInfo(Graphics g, IEdge e, IEnumerable<IEdge> es)
        {
            var ps = (PointF)e.Source.GetAlgorithmObj(_KH_PANE_LOCATION);
            var pt = (PointF)e.Target.GetAlgorithmObj(_KH_PANE_LOCATION);
            if(es.Count()>=2)
                Render.DrawParallelEdgeSelected(g, e, es,_Attrfont, ps, pt);
            else
                Render.DrawEdgeSelected(g, e, _Attrfont, ps, pt);
        }
        
        #endregion

        #endregion


    }
}
