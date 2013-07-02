using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDBMS.KHCodeTextBox
{
    public class CodeColorConfig
    {
        /// <summary>  
        /// 关键字组
        /// </summary> 
        public Dictionary<string, bool> Keyword { get { return _Keyword ; } }
        private Dictionary<string, bool> _Keyword = new Dictionary<string, bool>()
        {
            {"vertex",true},
            {"edge",true},
            {"graph",true},
            {"type",true},
        };

        /// <summary>  
        /// 保留字组
        /// </summary> 
        public Dictionary<string, bool> PreserveWord { get { return _PreserveWord; } }
        private Dictionary<string, bool> _PreserveWord = new Dictionary<string, bool>()
        {            
            {"select",true},
            {"start",true},
            {"create",true},
            {"match",true},
            {"alter",true},
            {"delete",true},
            {"change",true},
            {"merge",true},
            {"from",true},
            {"-[",false},
            {"]->",false},
            {"]-",false}
        };
        

        private Color _BackGroundColor = Color.FromArgb(0, 32, 40);
        /// <summary>  
        /// 背景颜色 
        /// </summary>  
        public Color BackGroundColor
        {
            get { return this._BackGroundColor; }
            set { this._BackGroundColor = value; }
        }

        private Color _ScrollColor = Color.FromArgb(251, 129, 104);
        /// <summary>  
        /// 背景颜色 
        /// </summary>  
        public Color ScrollColor
        {
            get { return this._ScrollColor; }
            set { this._ScrollColor = value; }
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

        private Color _NormalWordColor = Color.FromArgb(211, 225, 222);
        /// <summary>  
        /// 基本文字颜色 
        /// </summary>  
        public Color NormalWordColor
        {
            get { return this._NormalWordColor; }
            set { this._NormalWordColor = value; }
        }

        private Color _StringColor = Color.FromArgb(42, 161, 134);
        /// <summary>  
        /// 基本文字颜色 
        /// </summary>  
        public Color StringColor 
        {
            get { return this._StringColor; }
            set { this._StringColor = value; }
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

        private Color _AttrValueColor = Color.FromArgb(187, 40, 91);
        /// <summary>  
        /// 保留字颜色
        /// </summary>  
        public Color AttrValueColor
        {
            get { return this._AttrValueColor; }
            set { this._AttrValueColor = value; }
        }
    }
}
