using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHGraphDB.Helper;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;
using KHGraphDBMS.KHMenu;
using KHGraphDBMS.Properties;


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

        #region Prop
        Graph graph = new Graph();
        Grammar.Grammar grammar;

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

            textArea1.PressControlEnter += textArea1_PressControlEnter;
            
            #region Graph test

            graph = new Graph();
            grammar = new Grammar.Grammar(graph);

            KHGraphDB.Structure.Type student = new KHGraphDB.Structure.Type(new Dictionary<string, object>(){
                {"Name",null},{"Num",null}
            });
            student.Name = "Student";

            Vertex peiming = new Vertex(new Dictionary<string, object>(){
                {"Name","Peiming"},
                {"Age","22"},
                {"Game","Gal"}
            });

            Vertex weidong = new Vertex(new Dictionary<string, object>(){
                {"Name","Weidong"},
                {"Age","22"}
            });

            Vertex yidong = new Vertex(new Dictionary<string, object>(){
                {"Name","Yidong"},
                {"Age","21"}
            });

            graph.AddType(student);

            graph.AddVertex(peiming, student);
            graph.AddVertex(yidong, student);
            graph.AddVertex(weidong, student);

            Edge friendPY = new Edge(peiming, yidong, new Dictionary<string, object>(){
                {"relationship","friend"},
            });

            Edge friendYW = new Edge(yidong, weidong, new Dictionary<string, object>(){
                {"relationship","friend"},
            });

            graph.AddEdge(friendPY);
            graph.AddEdge(friendYW);

            panelGraph.Graph = graph;
            this.graph.OnAnyChange += GraphChange;
            #endregion


        }

        /// <summary>
        /// 更换图
        /// </summary>
        public void ReplaceGraph(Graph __graph)
        {
            this.graph = __graph;
            this.panelGraph.Graph = this.graph;
            grammar = new Grammar.Grammar(this.graph);
            this.graph.OnAnyChange += GraphChange;
            SavePath = "";
        }

        bool console = false;
        void textArea1_PressControlEnter(object sender)
        {
            grammar.Exert(textArea1.CodeText);
            textArea1.CodeText = "";
            if (console)
            {
                探索模式WToolStripMenuItem_Click(sender, new EventArgs());
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ColorConfig colorconfig = new ColorConfig();//创建颜色配置类  
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(colorconfig.MainBordercolor)), 0, 0, Width - 1, Height - 1);
        }

        #region Zoom and Move the window
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

        #endregion

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        #region Min Max Exit

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMax_MouseEnter(object sender, EventArgs e)
        {
            this.pbMax.Image = Resources.btn_Max_hover;
        }

        private void pbMax_MouseLeave(object sender, EventArgs e)
        {
            this.pbMax.Image = Resources.btn_Max;
        }

        private void pbMin_MouseEnter(object sender, EventArgs e)
        {
            this.pbMin.Image = Resources.btn_Min_hover;
        }

        private void pbMin_MouseLeave(object sender, EventArgs e)
        {
            this.pbMin.Image = Resources.btn_Min;
        }

        private void pbExit_MouseEnter(object sender, EventArgs e)
        {
            this.pbExit.Image = Resources.btn_exit_hover;
        }

        private void pbExit_MouseLeave(object sender, EventArgs e)
        {
            this.pbExit.Image = Resources.btn_exit;
        }

        #endregion

        #region Graph change
        private void GraphChange(object sender)
        {
            lbTitle.Text = SavePath + "* - KHGraphDBManager";
            if (this.自动保存ToolStripMenuItem.Checked)
                SAVE_Click(this, new EventArgs());
        }
        #endregion

        #region Menu

        #region View Mode

        private void 探索模式WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textArea1.Hide();
            this.panelGraph.Show();
            this.panelGraph.Height = this.Height - 78;
            this.呼出控制台CToolStripMenuItem.Visible = true;
            this.呼出控制台CToolStripMenuItem.Enabled = true;
        }

        private void 代码模式CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.textArea1.Top = 68;
            this.textArea1.Height = this.Height - 78;
            this.textArea1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.textArea1.Left = this.panelGraph.Left;
            this.textArea1.Width = this.panelGraph.Width;
            this.panelGraph.Hide();
            this.textArea1.Show();
            this.呼出控制台CToolStripMenuItem.Visible = false;
            this.呼出控制台CToolStripMenuItem.Enabled = false ;
        
        }

        private void 分栏显示TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.textArea1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.textArea1.Height = 205;
            
            this.panelGraph.Height = this.Height - 82 - this.textArea1.Height;
            this.textArea1.Top = this.panelGraph.Height + 69;
            this.textArea1.Left = this.panelGraph.Left;
            this.textArea1.Width = this.panelGraph.Width;
            this.panelGraph.Show();
            this.textArea1.Show();
            this.呼出控制台CToolStripMenuItem.Visible = false;
            this.呼出控制台CToolStripMenuItem.Enabled = false;
        }

        private void 呼出控制台CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!console)
            {
                this.textArea1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                this.textArea1.Height = 100;
                this.textArea1.Width = (Width > 500) ? 500 : Width;
                this.textArea1.Top = Height - 150;
                this.textArea1.Left = Width - this.textArea1.Width - 5;
                this.textArea1.Show();
                console = true;
            }
            else
            {
                console = false;
                探索模式WToolStripMenuItem_Click(sender, e);
            }
        }

        #endregion

        #region Exit
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region New Read Save

        private void aToolStripMenuItem_Click(object sender, EventArgs e)//New
        {
            ReplaceGraph(new Graph());
            lbTitle.Text = "NewDatabase* - KHGraphDBManager";
        }

        private string SavePath = "";
        private void bToolStripMenuItem_Click(object sender, EventArgs e)//OPEN
        {
            bool isAuto = this.自动保存ToolStripMenuItem.Checked;
            this.自动保存ToolStripMenuItem.Checked = false; //如果自动保存，在这边会发生同时占用错误
            if (this.openDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = this.openDatabaseDialog.FileName;
                if (!String.IsNullOrEmpty(FileName))
                {
                    ReplaceGraph(new Graph());
                    GraphReader gr = new GraphReader(this.graph);
                    SavePath = FileName;
                    if (SavePath.EndsWith(".gdbf"))
                    {
                        SavePath = SavePath.Substring(0, SavePath.Length - 5);
                    }
                    gr.Path = SavePath;

                    gr.Read();
                }
                lbTitle.Text = SavePath + " - KHGraphDBManager";
            }
            this.自动保存ToolStripMenuItem.Checked = isAuto;
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SavePath))
            {
                SaveAs_Click(sender, e);
                lbTitle.Text = SavePath + " - KHGraphDBManager";
            }
            else
            {
                if (!SaveDatabase(SavePath))
                {
                    MessageBox.Show("未能正确保存，请尝试另存", "保存错误", MessageBoxButtons.OK);
                }
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (this.saveDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                SavePath = saveDatabaseDialog.FileName;
                if (SavePath.EndsWith(".gdbf"))
                {
                    SavePath = SavePath.Substring(0, SavePath.Length - 5);
                }
                SAVE_Click(sender,e);
            }
        }

        private bool SaveDatabase(string FileName)
        {
            if (!String.IsNullOrEmpty(FileName))
            {
                GraphWriter gw = new GraphWriter(this.graph);
                gw.Path = FileName;
                return gw.Write();
            }
            return false;
        }

        private void 关闭BToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void 自动保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.自动保存ToolStripMenuItem.Checked = !this.自动保存ToolStripMenuItem.Checked;
        }

        #endregion






    }
}
