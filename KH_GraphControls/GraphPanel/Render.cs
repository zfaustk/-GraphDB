using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;

namespace KH_GraphControls.GraphPanel
{
    class Render
    {
        static PanelColorConfig panelColorConfig = new PanelColorConfig();
        static SolidBrush brushVertex = new SolidBrush(panelColorConfig.VertexColor);
        static SolidBrush brushEdge = new SolidBrush(panelColorConfig.EdgeColor);
        static SolidBrush brushEdgePoint = new SolidBrush(panelColorConfig.EdgePointColor);
        static SolidBrush brushText = new SolidBrush(panelColorConfig.TextColor);
        static SolidBrush brushHover = new SolidBrush(panelColorConfig.HoverColor);
        static SolidBrush brushHighLight = new SolidBrush(panelColorConfig.HighLightColor);
        static SolidBrush brushAttrPanel = new SolidBrush(panelColorConfig.AttrColor);

        static Pen penEdge = new Pen(brushEdge);
        static Pen penHighLight = new Pen(brushHighLight);
        static Pen penHover = new Pen(brushHover);
        static Pen penAttrBorder = new Pen(panelColorConfig.BorderColor,2);
        static Pen penAttrBorderSlipt = new Pen(panelColorConfig.BorderSliptColor, 1);

        /// <summary>
        /// Draw a Vertex
        /// </summary>
        public static void DrawVertex(Graphics g, IVertex v, Font f, PointF p, RectangleF r,bool highLight = false)
        {
            g.FillEllipse(highLight ? brushHighLight : brushVertex, r);
            g.DrawString((string)v["Name"], f, brushText, p);
        }

        /// <summary>
        /// Draw a Vertex
        /// </summary>
        public static void DrawEdge(Graphics g, IEdge e, PointF pSource, PointF pTarget, bool highLight = false)
        {
            var ps = pSource;
            var pt = pTarget;
            g.DrawLine(highLight ? penHighLight : penEdge, ps, pt);
            g.FillEllipse(highLight ? brushHighLight : brushEdgePoint, (pt.X + ps.X) / 2 - 2, (pt.Y + ps.Y) / 2 - 2, 4, 4);
            g.FillEllipse(highLight ? brushHighLight : brushEdgePoint, (pt.X * 2 + 3 * ps.X) / 5 - 4, (pt.Y * 2 + ps.Y * 3) / 5 - 4, 8, 8);
        }

        public static void DrawEdgeSelected(Graphics g, IEdge e, Font f, PointF pSource, PointF pTarget, int Radius = 5)
        {
            var ps = pSource;
            var pt = pTarget;
            String s = e.AttributesToString();
            SizeF size = g.MeasureString(s, f);
            PointF location = new PointF((pt.X * 2 + 3 * ps.X) / 5 - 4, (pt.Y * 2 + ps.Y * 3) / 5 - 4);
            RectangleF rect = new RectangleF(location, size);
            GraphicsPath roundedRect = GetRoundedRect(rect, Radius);

            g.DrawLine(penHover, ps, pt);
            g.FillEllipse(brushHover, (pt.X + ps.X) / 2 - 2, (pt.Y + ps.Y) / 2 - 2, 4, 4);

            g.FillPath(brushAttrPanel, roundedRect);
            g.DrawPath(penAttrBorder, roundedRect);
            g.DrawString(s, f, brushText, rect);
        }

        public static void DrawParallelEdgeSelected(Graphics g, IEdge e, IEnumerable<IEdge> es, Font f, PointF pSource, PointF pTarget, int Radius = 5)
        {
            var ps = pSource;
            var pt = pTarget;
            String s = "";
            List<float> Heights = new List<float>();
            foreach (var et in es)
            {
                string str = et.AttributesToString();
                s += str;
                Heights.Add(g.MeasureString(str, f).Height);
            }

            SizeF size = g.MeasureString(s, f);
            PointF location = new PointF((pt.X * 2 + 3 * ps.X) / 5 - 4, (pt.Y * 2 + ps.Y * 3) / 5 - 4);
            RectangleF rect = new RectangleF(location, size);
            GraphicsPath roundedRect = GetRoundedRect(rect, Radius);

            g.DrawLine(penHover, ps, pt);
            g.FillEllipse(brushHover, (pt.X + ps.X) / 2 - 2, (pt.Y + ps.Y) / 2 - 2, 4, 4);

            float hM = -1;
            
            
            g.FillPath(brushAttrPanel, roundedRect);
            
            foreach (var h in Heights)
            {
                hM += h;
                g.DrawLine(penAttrBorderSlipt, location.X + Radius, location.Y + hM, location.X + size.Width - Radius, location.Y + hM);
            }

            g.DrawPath(penAttrBorder, roundedRect);

            g.DrawString(s, f, brushText, rect);
        }

        public static void DrawVertexSelected(Graphics g, IVertex v, Font f, PointF p, RectangleF r, int Radius = 5)
        {
            String s = v.AttributesToString();
            SizeF size = g.MeasureString(s, f);
            RectangleF rect = new RectangleF(p, size);
            GraphicsPath roundedRect = GetRoundedRect(rect, Radius);

            g.FillEllipse(brushHover, r);

            g.FillPath(brushAttrPanel, roundedRect);
            g.DrawPath(penAttrBorder, roundedRect);
            g.DrawString(s, f, brushText, rect);
        }

        public static GraphicsPath GetRoundedRect(RectangleF rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }
}
