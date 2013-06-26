using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH_GraphControls.GraphPanel
{
    class PanelColorConfig
    {
        private Color _BackGroundColor = Color.FromArgb(158, 158, 158);
        /// <summary>  
        /// 背景颜色 
        /// </summary>  
        public Color BackGroundColor
        {
            get { return this._BackGroundColor; }
            set { this._BackGroundColor = value; }
        }

        private Color _VertexColor = Color.FromArgb(0, 102, 204);
        /// <summary>  
        /// Vertex颜色 
        /// </summary>  
        public Color VertexColor
        {
            get { return this._VertexColor; }
            set { this._VertexColor = value; }
        }

        private Color _BorderColor = Color.FromArgb(62, 62, 66);
        /// <summary>  
        /// 边框颜色 
        /// </summary>  
        public Color BorderColor
        {
            get { return this._BorderColor; }
            set { this._BorderColor = value; }
        }
    }
}
