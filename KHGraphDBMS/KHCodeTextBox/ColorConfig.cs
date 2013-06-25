using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDBMS.KHCodeTextBox
{
    class ColorConfig
    {
        private Color _BackGroundColor = Color.FromArgb(0, 32, 40);
        /// <summary>  
        /// 背景颜色 
        /// </summary>  
        public Color BackGroundColor
        {
            get { return this._BackGroundColor; }
            set { this._BackGroundColor = value; }
        }


        private Color _NormalWordColor = Color.FromArgb(211, 225, 222);
        /// <summary>  
        /// 基本文字颜色 
        /// </summary>  
        public Color NormalWordColor
        {
            get { return this._NormalWordColor; }
            set { this._NormalWordColor = value; }
        }


        private Color _KeyWordColor = Color.FromArgb(38, 139, 210);
        /// <summary>  
        /// 关键字颜色 
        /// </summary>  
        public Color KeyWordColor
        {
            get { return this._KeyWordColor; }
            set { this._KeyWordColor = value; }
        }


        private Color _PreserveWordColor = Color.FromArgb(133, 153, 16);
        /// <summary>  
        /// 保留字颜色
        /// </summary>  
        public Color PreserveWordColor
        {
            get { return this._PreserveWordColor; }
            set { this._PreserveWordColor = value; }
        }
    }
}
