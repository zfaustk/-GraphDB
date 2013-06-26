using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KHGraphDBMS.KHCodeTextBox
{
    public partial class KHCodeTextArea : UserControl
    {
        public KHCodeTextArea()
        {
            InitializeComponent();
        }


        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);

        #region ScrollMove
        bool mouseDown = false;
        int mouseDownY = 0;
        int scrollY = 0;
        int lastLineNumber = 0;
        #endregion

        #region Attribute
        public override string Text { get { return codeTextBox.Text; } set { codeTextBox.Text = value; } }
        public string CodeText { get { return codeTextBox.Text; } set { codeTextBox.Text = value; } }
        public override Font Font { get { return codeTextBox.Font; } set { codeTextBox.Font = value; } }
        public override System.Drawing.Color ForeColor { get { return codeTextBox.ForeColor; } set { codeTextBox.ForeColor = value; } }
        /// <summary>  
        /// 背景颜色 
        /// </summary>  
        public Color BackGroundColor
        {
            get { return codeTextBox.Colorconfig.BackGroundColor; }
            set { codeTextBox.Colorconfig.BackGroundColor = value; }
        }
        /// <summary>  
        /// 滚动条颜色 
        /// </summary>  
        public Color ScrollColor
        {
            get { return codeTextBox.Colorconfig.ScrollColor; }
            set { codeTextBox.Colorconfig.ScrollColor = value; }
        }
        /// <summary>  
        /// 边框颜色 
        /// </summary>  
        public Color BorderColor
        {
            get { return codeTextBox.Colorconfig.BorderColor; }
            set { codeTextBox.Colorconfig.BorderColor = value; }
        }
        /// <summary>  
        /// 基本文字颜色 
        /// </summary>  
        public Color NormalWordColor
        {
            get { return codeTextBox.Colorconfig.NormalWordColor; }
            set { codeTextBox.Colorconfig.NormalWordColor = value; }
        }
        /// <summary>  
        /// 基本文字颜色 
        /// </summary>  
        public Color StringColor
        {
            get { return codeTextBox.Colorconfig.StringColor; }
            set { codeTextBox.Colorconfig.StringColor = value; }
        }
        /// <summary>  
        /// 关键字颜色 
        /// </summary>  
        public Color KeyWordColor
        {
            get { return codeTextBox.Colorconfig.KeyWordColor; }
            set { codeTextBox.Colorconfig.KeyWordColor = value; }
        }
        /// <summary>  
        /// 保留字颜色
        /// </summary>  
        public Color PreserveWordColor
        {
            get { return codeTextBox.Colorconfig.PreserveWordColor; }
            set { codeTextBox.Colorconfig.PreserveWordColor = value; }
        }
        #endregion

        #region Delegate
        //public delegate void OnScrollMove(object sender, MouseEventArgs e);
        //public OnScrollMove OnScroll;
        #endregion

        #region scorll move

        private void scroll_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseDownY = e.Y;
        }

        private void scroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int tempTop = scroll.Top;
                if ((scroll.Bottom < codeTextBox.Height + 5 && mouseDownY < e.Y)
                    ||
                    (scroll.Top > 5 && mouseDownY > e.Y)
                    )
                    tempTop += e.Y - mouseDownY;
                if (tempTop <= 5) tempTop = 5;
                else if (tempTop + scroll.Height >= codeTextBox.Height + 5) tempTop = codeTextBox.Height + 5 - scroll.Height;
                scroll.Top = tempTop;

                if (scroll.Top - scrollY > 1 || scroll.Top - scrollY < -1)
                {
                    SendMessage(base.Handle, 0xB, 0, IntPtr.Zero);  //防止闪烁

                    int lines = Convert.ToInt32(codeTextBox.Height / LineHeight);
                    int Select = codeTextBox.SelectionStart;
                    int heightDistance = codeTextBox.Height - scroll.Height;
                    if (heightDistance <= 0) heightDistance = 1;
                    int scrollTop = scroll.Top - 5;
                    int a = Convert.ToInt32((codeTextBox.Lines.Length - lines) * (scrollTop) / (heightDistance) - 0.1);
                    int index = codeTextBox.GetFirstCharIndexFromLine(a > 0 ? a : 0);
                    if (index < 0) index = 0;
                    codeTextBox.Select(index, 0);
                    codeTextBox.ScrollToCaret();
                    SendMessage(base.Handle, 0xB, 1, IntPtr.Zero);
                    codeTextBox.Refresh();
                    
                    scrollY = scroll.Top;
                }
                //codeTextBox.Select(Select, 0);
            }

        }

        private void scroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int Select = codeTextBox.SelectionStart;
            ResetScrollHeight();
            if (codeTextBox.Lines.Length != lastLineNumber) ResetScrollPosition();

            lastLineNumber = codeTextBox.Lines.Length;
        }

        private void KHCodeTextArea_Load(object sender, EventArgs e)
        {
            ResetScrollHeight();
        }

        private void codeTextBox_Resize(object sender, EventArgs e)
        {
            ResetScrollHeight();
            ResetScrollPosition();
        }

        private void ResetScrollHeight()
        {
            int lines = Convert.ToInt32(codeTextBox.Height / LineHeight);
            int addLine = codeTextBox.Lines.Length - lines;
            addLine = addLine >= 0 ? addLine : 0;
            scroll.Height = Convert.ToInt32(codeTextBox.Height * (1.0 -  addLine / (40.0 + addLine)));  
        }

        private void ResetScrollPosition()
        {
            int lines = Convert.ToInt32(codeTextBox.Height / LineHeight);
            int Select = codeTextBox.SelectionStart;
            int linenow = codeTextBox.GetLineFromCharIndex(Select);
            int lchange = codeTextBox.Lines.Length - lines;
            int lnowchange = linenow - lines;
            scroll.Top = 5 + ((lnowchange > 0 ? lnowchange : 0) * (codeTextBox.Height - scroll.Height)) / ((lchange < 1) ? 1 : lchange);
        }

        public float LineHeight { get { return codeTextBox.CreateGraphics().MeasureString("test", codeTextBox.Font).Height; } }

        
    }
}
