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

        private PanelColorConfig panelColorConfilg = new PanelColorConfig();
        private Graph _graph = new Graph();
        private Random Random = new Random();
        private string _KH_PANE_LOCATION = "_KH_PANE_LOCATION";
        private string _KH_PANE_DEPTH = "_KH_PANE_DEPTH";
        #endregion

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

            Parallel.ForEach<IVertex>(Graph.Vertices, v =>
            {
                v.SetAlgorithmObj(_KH_PANE_LOCATION,new PointF(Random.Next(0, Width - 40), Random.Next(0, Height - 40)) );
                v.SetAlgorithmObj(_KH_PANE_DEPTH, Random.Next(0,10) );
            });

            graph.OnAddVertex += OnAddVertex;
            graph.OnAddEdge += OnAddEdge;
            graph.OnAddType += OnAddType;
            graph.OnRemoveVertex += OnRemoveVertex;
            graph.OnRemoveEdge += OnRemoveEdge;
            graph.OnRemoveType += OnRemoveType;

            this.Refresh();

        }


        #region Delegate
        private void OnAddVertex(object sender, IVertex vertex)
        {
            vertex.SetAlgorithmObj(_KH_PANE_LOCATION, new PointF(Random.Next(0, Width - 40), Random.Next(0, Height - 40)));
            vertex.SetAlgorithmObj(_KH_PANE_DEPTH, Random.Next(0, 10));
            this.Refresh();
        }
        private void OnAddEdge(object sender, IEdge vertex)
        {
            this.Refresh();
        }
        private void OnAddType(object sender, IType vertex)
        {
            this.Refresh();
        }
        private void OnRemoveVertex(object sender, IVertex vertex)
        {
            this.Refresh();
        }
        private void OnRemoveEdge(object sender, IEdge vertex)
        {
            this.Refresh();
        }
        private void OnRemoveType(object sender, IType vertex)
        {
            this.Refresh();
        }
        #endregion

        public event EventHandler<DBObjectEventArgs>        FocusChanged    ;
        public event EventHandler<AcceptVertexEventArgs>    VertexAdded     ;
        public event EventHandler<AcceptVertexEventArgs>    VertexRemoving  ;
        public event EventHandler<VertexEventArgs>          VertexRemoved   ;
        public event EventHandler<AcceptEdgeEventArgs>      EdgeAdding      ;
        public event EventHandler<AcceptEdgeEventArgs>      EdgeAdded       ;
        public event EventHandler<AcceptEdgeEventArgs>      EdgeRemoving    ;
        public event EventHandler<EdgeEventArgs>            EdgeRemoved     ;


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

        #region OnPaint
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (e.Graphics == null)
                return;

            e.Graphics.Clear(panelColorConfilg.BackGroundColor);

            if (this._graph.VertexCount == 0)
                return;

            UpdateMatrices();
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;


            e.Graphics.Transform = transformation;

            foreach (Vertex v in Graph.Vertices)
            {
                var p = (PointF)v.AlgorithmObjs[_KH_PANE_LOCATION];
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(panelColorConfilg.VertexColor))
                    , p.X, p.Y, 50, 50);
                e.Graphics.DrawString((string)v["Name"], new Font("Melon", 10), new SolidBrush(Color.Black), p);
            }

            foreach (Edge edge in Graph.Edges)
            {
                var ps = (PointF)edge.Source.AlgorithmObjs[_KH_PANE_LOCATION];
                ps.X += 36;
                ps.Y += 36;
                var pt = (PointF)edge.Target.AlgorithmObjs[_KH_PANE_LOCATION];
                pt.X += 24;
                pt.Y += 24;
                e.Graphics.DrawLine(new Pen(new SolidBrush(panelColorConfilg.VertexColor)),
                    ps,pt);
                e.Graphics.DrawEllipse(new Pen(panelColorConfilg.VertexColor,2), ps.X,ps.Y,3,3);
            }


            //var transformed_location = GetTransformedLocation();
            //if (command == CommandMode.MarqueSelection)
            //{
            //    var marque_rectangle = GetMarqueRectangle();
            //    e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, marque_rectangle);
            //    e.Graphics.DrawRectangle(Pens.DarkGray, marque_rectangle.X, marque_rectangle.Y, marque_rectangle.Width, marque_rectangle.Height);
            //}

            //GraphRenderer.PerformLayout(e.Graphics, graphNodes);
            //GraphRenderer.Render(e.Graphics, graphNodes, ShowLabels);

            //if (command == CommandMode.Edit)
            //{
            //    if (dragging)
            //    {
            //        if (DragElement != null)
            //        {
            //            RenderState renderState = RenderState.Dragging | RenderState.Hover;
            //            switch (DragElement.ElementType)
            //            {
            //                case ElementType.OutputConnector:
            //                    var outputConnector = DragElement as NodeConnector;
            //                    renderState |= (outputConnector.state & (RenderState.Incompatible | RenderState.Compatible));
            //                    GraphRenderer.RenderOutputConnection(e.Graphics, outputConnector,
            //                        transformed_location.X, transformed_location.Y, renderState);
            //                    break;
            //                case ElementType.InputConnector:
            //                    var inputConnector = DragElement as NodeConnector;
            //                    renderState |= (inputConnector.state & (RenderState.Incompatible | RenderState.Compatible));
            //                    GraphRenderer.RenderInputConnection(e.Graphics, inputConnector,
            //                        transformed_location.X, transformed_location.Y, renderState);
            //                    break;
            //            }
            //        }
            //    }
            //}
        }
        #endregion


    }
}
