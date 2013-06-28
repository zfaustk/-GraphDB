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
        private Color _BackGroundColor = Color.FromArgb(198, 198, 210);
        /// <summary>  
        /// 背景颜色 
        /// </summary>  
        public Color BackGroundColor
        {
            get { return this._BackGroundColor; }
            set { this._BackGroundColor = value; }
        }

        private Color _VertexColor = Color.FromArgb(12, 102, 204);
        /// <summary>  
        /// Vertex颜色 
        /// </summary>  
        public Color VertexColor
        {
            get { return this._VertexColor; }
            set { this._VertexColor = value; }
        }

        private Color _EdgeColor = Color.FromArgb(12, 102, 204);
        /// <summary>  
        /// Edge颜色 
        /// </summary>  
        public Color EdgeColor 
        {
            get { return this._EdgeColor; }
            set { this._EdgeColor = value; }
        }

        private Color _EdgePointColor = Color.FromArgb(101,44,144);
        /// <summary>  
        /// Edge标点颜色 
        /// </summary>  
        public Color EdgePointColor
        {
            get { return this._EdgePointColor; }
            set { this._EdgePointColor = value; }
        }

        private Color _TextColor = Color.FromArgb(15,15,15);
        /// <summary>  
        /// 文字颜色 
        /// </summary>  
        public Color TextColor 
        {
            get { return this._TextColor; }
            set { this._TextColor = value; }
        }


        private Color _HoverColor = Color.FromArgb(80, 182, 254);
        /// <summary>  
        /// 经过时颜色 
        /// </summary>  
        public Color HoverColor
        {
            get { return this._HoverColor; }
            set { this._HoverColor = value; }
        }

        private Color _BorderColor = Color.FromArgb(50, 152, 254);
        /// <summary>  
        /// 属性提示边框颜色 
        /// </summary>  
        public Color BorderColor
        {
            get { return this._BorderColor; }
            set { this._BorderColor = value; }
        }

        private Color _AttrColor = Color.FromArgb(80, 182, 254);
        /// <summary>  
        /// 属性背板颜色 
        /// </summary>  
        public Color AttrColor
        {
            get { return this._AttrColor; }
            set { this._AttrColor = value; }
        }

        private Color _BorderSliptColor = Color.FromArgb(82, 82, 98);
        /// <summary>  
        /// 属性分界线颜色
        /// </summary>  
        public Color BorderSliptColor
        {
            get { return this._BorderSliptColor; }
            set { this._BorderSliptColor = value; }
        }

        private Color _HighLightColor = Color.FromArgb(55, 182, 124);
        /// <summary>  
        /// 高亮颜色 
        /// </summary>  
        public Color HighLightColor
        {
            get { return this._HighLightColor; }
            set { this._HighLightColor = value; }
        }

        
    }
}
