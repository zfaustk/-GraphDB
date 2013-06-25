using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHGraphDBMS.KHMenu;


namespace KHGraphDBMS
{
    public partial class FormMain : Form
    {

        #region Move and Zoom

        private bool _ReadyToMove = false;
        private bool _ReadyToZoomX = false;
        private bool _ReadyToZoomY = false;
        private int _MouseDownX = 0;
        private int _MouseDownY = 0;

        #endregion

        public FormMain()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelMain.MouseDown += FormMain_MouseDown;
            panelMain.MouseUp += FormMain_MouseUp;
            panelMain.MouseMove += FormMain_MouseMove;
            lbTitle.MouseDown += FormMain_MouseDown;
            lbTitle.MouseUp += FormMain_MouseUp;
            lbTitle.MouseMove += FormMain_MouseMove;
            pbLogo.MouseDown += FormMain_MouseDown;
            pbLogo.MouseUp += FormMain_MouseUp;
            pbLogo.MouseMove += FormMain_MouseMove;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ColorConfig colorconfig = new ColorConfig();//创建颜色配置类  
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(colorconfig.MainBordercolor)), 0, 0, Width - 1, Height - 1);
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < Width && e.Y < 32) _ReadyToMove = true;
            else
            {
                if (e.X <= 0 || e.X >= Width - 8) _ReadyToZoomX = true;
                if (e.Y <= 0 || e.Y >= Height - 8) _ReadyToZoomY = true;
            }

            _MouseDownX = e.X;
            _MouseDownY = e.Y;
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            _ReadyToMove = false;
            _ReadyToZoomX = false;
            _ReadyToZoomY = false;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ReadyToMove)
            {
                this.Left += e.X - _MouseDownX;
                this.Top += e.Y - _MouseDownY;
            }
            else 
            {
                if (_ReadyToZoomX && e.X>=398)
                {
                    this.Width += e.X - _MouseDownX;
                    _MouseDownX = e.X;
                    if (this.Width <= 400) this.Width = 400;
                }
                if (_ReadyToZoomY && e.Y >= 244)
                {
                    this.Height += e.Y - _MouseDownY;
                    _MouseDownY = e.Y;
                    if (this.Height <= 248) this.Height = 248;
                }
            }

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //int nSelectStart = richTextBox1.SelectionStart;
            //int nSelectLength = richTextBox1.SelectionLength;
            //int nIndex = 0;
            //richTextBox1.Select(nIndex, richTextBox1.Text.Length);
            //richTextBox1.SelectionColor = Color.White;
            //while (nIndex < richTextBox1.Text.Length)
            //{
            //    nIndex = richTextBox1.Find("wings", nIndex, RichTextBoxFinds.WholeWord);
            //    if (nIndex < 0)
            //    {
            //        break;
            //    }
            //    richTextBox1.Select(nIndex, 5);
            //    richTextBox1.SelectionColor = Color.Red;
            //    nIndex += 5;
            //}
            //richTextBox1.Select(nSelectStart, nSelectLength);
        }

       
    }
}
