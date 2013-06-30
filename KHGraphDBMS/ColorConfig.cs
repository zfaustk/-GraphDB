using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHGraphDBManager.KHMenu
{
    class ColorConfig
    {
        private Color _MainBordercolor = Color.FromArgb(62,62,66);
        /// <summary>  
        /// 主边框颜色  
        /// </summary>  
        public Color MainBordercolor
        {
            get { return this._MainBordercolor; }
            set { this._MainBordercolor = value; }
        }

        private Color _fontcolor = Color.FromArgb(241,241,241);
        /// <summary>  
        /// 菜单字体颜色  
        /// </summary>  
        public Color FontColor
        {
            get { return this._fontcolor; }
            set { this._fontcolor = value; }
        }
        private Color _marginstartcolor = Color.FromArgb(27,27,28);
        /// <summary>  
        /// 下拉菜单坐标图标区域开始颜色  
        /// </summary>  
        public Color MarginStartColor
        {
            get { return this._marginstartcolor; }
            set { this._marginstartcolor = value; }
        }
        private Color _marginendcolor = Color.FromArgb(27, 27, 28);
        /// <summary>  
        /// 下拉菜单坐标图标区域结束颜色  
        /// </summary>  
        public Color MarginEndColor
        {
            get { return this._marginendcolor; }
            set { this._marginendcolor = value; }
        }

        private Color _dropdownitembackcolor = Color.FromArgb(27, 27, 28);//Color.FromArgb(34, 34, 34);
        /// <summary>  
        /// 下拉项背景颜色  
        /// </summary>  
        public Color DropDownItemBackColor
        {
            get { return this._dropdownitembackcolor; }
            set { this._dropdownitembackcolor = value; }
        }

        private Color _dropdownitemstartcolor = Color.FromArgb(51, 51, 52);
        /// <summary>  
        /// 下拉项选中时开始颜色  
        /// </summary>  
        public Color DropDownItemStartColor
        {
            get { return this._dropdownitemstartcolor; }
            set { this._dropdownitemstartcolor = value; }
        }
        private Color _dorpdownitemendcolor = Color.FromArgb(51, 51, 52);
        /// <summary>  
        /// 下拉项选中时结束颜色  
        /// </summary>  
        public Color DropDownItemEndColor
        {
            get { return this._dorpdownitemendcolor; }
            set { this._dorpdownitemendcolor = value; }
        }
        private Color _menuitemstartcolor = Color.FromArgb(62, 62, 64);
        /// <summary>  
        /// 主菜单项选中时的开始颜色  
        /// </summary>  
        public Color MenuItemStartColor
        {
            get { return this._menuitemstartcolor; }
            set { this._menuitemstartcolor = value; }
        }
        private Color _menuitemendcolor = Color.FromArgb(62, 62, 64);
        /// <summary>  
        /// 主菜单项选中时的结束颜色  
        /// </summary>  
        public Color MenuItemEndColor
        {
            get { return this._menuitemendcolor; }
            set { this._menuitemendcolor = value; }
        }
        private Color _separatorcolor = Color.Gray;
        /// <summary>  
        /// 分割线颜色  
        /// </summary>  
        public Color SeparatorColor
        {
            get { return this._separatorcolor; }
            set { this._separatorcolor = value; }
        }
        private Color _mainmenubackcolor = Color.Black;
        /// <summary>  
        /// 主菜单背景色  
        /// </summary>  
        public Color MainMenuBackColor
        {
            get { return this._mainmenubackcolor; }
            set { this._mainmenubackcolor = value; }
        }
        private Color _mainmenustartcolor = Color.FromArgb(45, 45, 48);
        /// <summary>  
        /// 主菜单背景开始颜色  
        /// </summary>  
        public Color MainMenuStartColor
        {
            get { return this._mainmenustartcolor; }
            set { this._mainmenustartcolor = value; }
        }
        private Color _mainmenuendcolor = Color.FromArgb(45, 45, 48);
        /// <summary>  
        /// 主菜单背景结束颜色  
        /// </summary>  
        public Color MainMenuEndColor
        {
            get { return this._mainmenuendcolor; }
            set { this._mainmenuendcolor = value; }
        }
        private Color _dropdownborder = Color.FromArgb(51, 51, 55);
        /// <summary>  
        /// 下拉区域边框颜色  
        /// </summary>  
        public Color DropDownBorder
        {
            get { return this._dropdownborder; }
            set { this._dropdownborder = value; }
        }  
    }
}
