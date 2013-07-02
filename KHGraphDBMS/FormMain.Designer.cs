
namespace KHGraphDBMS
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            KHGraphDB.Structure.Graph graph1 = new KHGraphDB.Structure.Graph();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.pbMax = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelGraph = new KH_GraphControls.GraphPanel.GraphPanel();
            this.textArea1 = new KHGraphDBMS.KHCodeTextBox.KHCodeTextArea();
            this.MainMenu = new KHGraphDBMS.KHMenu.KH_Menu(this.components);
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建 = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.SAVE = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ShutDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.呼出控制台CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.添加节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加类型NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改类型DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除类型DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建查询SToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加边ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加点NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加平凡点NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按类型添加YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除点DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建查询SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加边EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加边ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.修改边AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除边DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建查询SToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.探索模式WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.代码模式CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分栏显示TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成自动代码MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainMenu.Controls.Add(this.MainMenu);
            this.panelMainMenu.Location = new System.Drawing.Point(0, 34);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(898, 23);
            this.panelMainMenu.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.ErrorImage = null;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(4, 2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(40, 30);
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.lbTitle.Location = new System.Drawing.Point(50, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(213, 15);
            this.lbTitle.TabIndex = 3;
            this.lbTitle.Text = "NewDatabase - KHGraphDBManager";
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.textArea1);
            this.panelMain.Controls.Add(this.pbMin);
            this.panelMain.Controls.Add(this.pbMax);
            this.panelMain.Controls.Add(this.pbExit);
            this.panelMain.Controls.Add(this.panelGraph);
            this.panelMain.Controls.Add(this.panelMainMenu);
            this.panelMain.Controls.Add(this.lbTitle);
            this.panelMain.Controls.Add(this.pbLogo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(900, 720);
            this.panelMain.TabIndex = 4;
            // 
            // pbMin
            // 
            this.pbMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMin.Image = global::KHGraphDBMS.Properties.Resources.btn_Min;
            this.pbMin.Location = new System.Drawing.Point(794, -2);
            this.pbMin.Margin = new System.Windows.Forms.Padding(0);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(35, 27);
            this.pbMin.TabIndex = 10;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            this.pbMin.MouseEnter += new System.EventHandler(this.pbMin_MouseEnter);
            this.pbMin.MouseLeave += new System.EventHandler(this.pbMin_MouseLeave);
            // 
            // pbMax
            // 
            this.pbMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMax.Image = global::KHGraphDBMS.Properties.Resources.btn_Max;
            this.pbMax.Location = new System.Drawing.Point(829, -2);
            this.pbMax.Margin = new System.Windows.Forms.Padding(0);
            this.pbMax.Name = "pbMax";
            this.pbMax.Size = new System.Drawing.Size(35, 27);
            this.pbMax.TabIndex = 9;
            this.pbMax.TabStop = false;
            this.pbMax.Click += new System.EventHandler(this.pbMax_Click);
            this.pbMax.MouseEnter += new System.EventHandler(this.pbMax_MouseEnter);
            this.pbMax.MouseLeave += new System.EventHandler(this.pbMax_MouseLeave);
            // 
            // pbExit
            // 
            this.pbExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbExit.Image = global::KHGraphDBMS.Properties.Resources.btn_exit;
            this.pbExit.Location = new System.Drawing.Point(864, -2);
            this.pbExit.Margin = new System.Windows.Forms.Padding(0);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(35, 27);
            this.pbExit.TabIndex = 8;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            this.pbExit.MouseEnter += new System.EventHandler(this.pbExit_MouseEnter);
            this.pbExit.MouseLeave += new System.EventHandler(this.pbExit_MouseLeave);
            // 
            // openDatabaseDialog
            // 
            this.openDatabaseDialog.FileName = "openDatabase";
            this.openDatabaseDialog.Filter = "图形数据库|*.gdbf|所有文件|*";
            this.openDatabaseDialog.Title = "选择一个数据库(.gdbf)文件";
            // 
            // saveDatabaseDialog
            // 
            this.saveDatabaseDialog.Filter = "图形数据库|*.gdbf";
            // 
            // panelGraph
            // 
            this.panelGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGraph.AttrFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.panelGraph.FocusElement = null;
            this.panelGraph.Graph = graph1;
            this.panelGraph.HighLightList = null;
            this.panelGraph.Location = new System.Drawing.Point(11, 63);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(876, 433);
            this.panelGraph.TabIndex = 7;
            // 
            // textArea1
            // 
            this.textArea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textArea1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.textArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.textArea1.CodeText = resources.GetString("textArea1.CodeText");
            this.textArea1.KeyWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(139)))), ((int)(((byte)(210)))));
            this.textArea1.Location = new System.Drawing.Point(11, 502);
            this.textArea1.Name = "textArea1";
            this.textArea1.NormalWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(225)))), ((int)(((byte)(222)))));
            this.textArea1.PreserveWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(153)))), ((int)(((byte)(16)))));
            this.textArea1.ScrollColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(129)))), ((int)(((byte)(104)))));
            this.textArea1.Size = new System.Drawing.Size(876, 205);
            this.textArea1.StringColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(161)))), ((int)(((byte)(134)))));
            this.textArea1.TabIndex = 6;
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.视图VToolStripMenuItem,
            this.项目PToolStripMenuItem,
            this.sQLPToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(898, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip2";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建,
            this.Open,
            this.SAVE,
            this.SaveAs,
            this.ShutDown,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建
            // 
            this.新建.Name = "新建";
            this.新建.Size = new System.Drawing.Size(121, 22);
            this.新建.Text = "新建(&N)";
            this.新建.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(121, 22);
            this.Open.Text = "打开(&O)";
            this.Open.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // SAVE
            // 
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(121, 22);
            this.SAVE.Text = "保存(&S)";
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(121, 22);
            this.SaveAs.Text = "另存为...";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // ShutDown
            // 
            this.ShutDown.Name = "ShutDown";
            this.ShutDown.Size = new System.Drawing.Size(121, 22);
            this.ShutDown.Text = "关闭(&B)";
            this.ShutDown.Click += new System.EventHandler(this.关闭BToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.退出ToolStripMenuItem.Text = "退出(&X)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.呼出控制台CToolStripMenuItem,
            this.toolStripSeparator2,
            this.添加节点ToolStripMenuItem,
            this.添加边ToolStripMenuItem,
            this.添加边EToolStripMenuItem});
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 呼出控制台CToolStripMenuItem
            // 
            this.呼出控制台CToolStripMenuItem.Name = "呼出控制台CToolStripMenuItem";
            this.呼出控制台CToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.呼出控制台CToolStripMenuItem.Text = "呼出控制台(&C)";
            this.呼出控制台CToolStripMenuItem.Visible = false;
            this.呼出控制台CToolStripMenuItem.Click += new System.EventHandler(this.呼出控制台CToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 添加节点ToolStripMenuItem
            // 
            this.添加节点ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加类型NToolStripMenuItem,
            this.修改类型DToolStripMenuItem,
            this.删除类型DToolStripMenuItem,
            this.新建查询SToolStripMenuItem1});
            this.添加节点ToolStripMenuItem.Name = "添加节点ToolStripMenuItem";
            this.添加节点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加节点ToolStripMenuItem.Text = "类型操作(&T)";
            // 
            // 添加类型NToolStripMenuItem
            // 
            this.添加类型NToolStripMenuItem.Name = "添加类型NToolStripMenuItem";
            this.添加类型NToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.添加类型NToolStripMenuItem.Text = "添加类型(&N)";
            // 
            // 修改类型DToolStripMenuItem
            // 
            this.修改类型DToolStripMenuItem.Name = "修改类型DToolStripMenuItem";
            this.修改类型DToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.修改类型DToolStripMenuItem.Text = "修改类型(&A)";
            // 
            // 删除类型DToolStripMenuItem
            // 
            this.删除类型DToolStripMenuItem.Name = "删除类型DToolStripMenuItem";
            this.删除类型DToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.删除类型DToolStripMenuItem.Text = "删除类型(&D)";
            // 
            // 新建查询SToolStripMenuItem1
            // 
            this.新建查询SToolStripMenuItem1.Name = "新建查询SToolStripMenuItem1";
            this.新建查询SToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.新建查询SToolStripMenuItem1.Text = "新建查询(&S)";
            // 
            // 添加边ToolStripMenuItem
            // 
            this.添加边ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加点NToolStripMenuItem,
            this.修改点ToolStripMenuItem,
            this.删除点DToolStripMenuItem,
            this.新建查询SToolStripMenuItem});
            this.添加边ToolStripMenuItem.Name = "添加边ToolStripMenuItem";
            this.添加边ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加边ToolStripMenuItem.Text = "点操作(&V)";
            // 
            // 添加点NToolStripMenuItem
            // 
            this.添加点NToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加平凡点NToolStripMenuItem,
            this.按类型添加YToolStripMenuItem});
            this.添加点NToolStripMenuItem.Name = "添加点NToolStripMenuItem";
            this.添加点NToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.添加点NToolStripMenuItem.Text = "添加点(&N)";
            // 
            // 添加平凡点NToolStripMenuItem
            // 
            this.添加平凡点NToolStripMenuItem.Name = "添加平凡点NToolStripMenuItem";
            this.添加平凡点NToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.添加平凡点NToolStripMenuItem.Text = "添加平凡点(&N)";
            // 
            // 按类型添加YToolStripMenuItem
            // 
            this.按类型添加YToolStripMenuItem.Name = "按类型添加YToolStripMenuItem";
            this.按类型添加YToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.按类型添加YToolStripMenuItem.Text = "按类型添加(&Y)";
            // 
            // 修改点ToolStripMenuItem
            // 
            this.修改点ToolStripMenuItem.Name = "修改点ToolStripMenuItem";
            this.修改点ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.修改点ToolStripMenuItem.Text = "修改点(&A)";
            // 
            // 删除点DToolStripMenuItem
            // 
            this.删除点DToolStripMenuItem.Name = "删除点DToolStripMenuItem";
            this.删除点DToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.删除点DToolStripMenuItem.Text = "删除点(&D)";
            // 
            // 新建查询SToolStripMenuItem
            // 
            this.新建查询SToolStripMenuItem.Name = "新建查询SToolStripMenuItem";
            this.新建查询SToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.新建查询SToolStripMenuItem.Text = "新建查询(&S)";
            // 
            // 添加边EToolStripMenuItem
            // 
            this.添加边EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加边ToolStripMenuItem1,
            this.修改边AToolStripMenuItem,
            this.删除边DToolStripMenuItem,
            this.新建查询SToolStripMenuItem2});
            this.添加边EToolStripMenuItem.Name = "添加边EToolStripMenuItem";
            this.添加边EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加边EToolStripMenuItem.Text = "边操作(&E)";
            // 
            // 添加边ToolStripMenuItem1
            // 
            this.添加边ToolStripMenuItem1.Name = "添加边ToolStripMenuItem1";
            this.添加边ToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.添加边ToolStripMenuItem1.Text = "添加边(&N)";
            // 
            // 修改边AToolStripMenuItem
            // 
            this.修改边AToolStripMenuItem.Name = "修改边AToolStripMenuItem";
            this.修改边AToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.修改边AToolStripMenuItem.Text = "修改边(&A)";
            // 
            // 删除边DToolStripMenuItem
            // 
            this.删除边DToolStripMenuItem.Name = "删除边DToolStripMenuItem";
            this.删除边DToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.删除边DToolStripMenuItem.Text = "删除边(&D)";
            // 
            // 新建查询SToolStripMenuItem2
            // 
            this.新建查询SToolStripMenuItem2.Name = "新建查询SToolStripMenuItem2";
            this.新建查询SToolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
            this.新建查询SToolStripMenuItem2.Text = "新建查询(&S)";
            // 
            // 视图VToolStripMenuItem
            // 
            this.视图VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.探索模式WToolStripMenuItem,
            this.代码模式CToolStripMenuItem,
            this.分栏显示TToolStripMenuItem});
            this.视图VToolStripMenuItem.Name = "视图VToolStripMenuItem";
            this.视图VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.视图VToolStripMenuItem.Text = "视图(&V)";
            // 
            // 探索模式WToolStripMenuItem
            // 
            this.探索模式WToolStripMenuItem.Name = "探索模式WToolStripMenuItem";
            this.探索模式WToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.探索模式WToolStripMenuItem.Text = "探索模式(&W)";
            this.探索模式WToolStripMenuItem.Click += new System.EventHandler(this.探索模式WToolStripMenuItem_Click);
            // 
            // 代码模式CToolStripMenuItem
            // 
            this.代码模式CToolStripMenuItem.Name = "代码模式CToolStripMenuItem";
            this.代码模式CToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.代码模式CToolStripMenuItem.Text = "代码模式(&C)";
            this.代码模式CToolStripMenuItem.Click += new System.EventHandler(this.代码模式CToolStripMenuItem_Click);
            // 
            // 分栏显示TToolStripMenuItem
            // 
            this.分栏显示TToolStripMenuItem.Name = "分栏显示TToolStripMenuItem";
            this.分栏显示TToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.分栏显示TToolStripMenuItem.Text = "分栏显示(&T)";
            this.分栏显示TToolStripMenuItem.Click += new System.EventHandler(this.分栏显示TToolStripMenuItem_Click);
            // 
            // 项目PToolStripMenuItem
            // 
            this.项目PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成自动代码MToolStripMenuItem,
            this.自动保存ToolStripMenuItem});
            this.项目PToolStripMenuItem.Name = "项目PToolStripMenuItem";
            this.项目PToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.项目PToolStripMenuItem.Text = "项目(&P)";
            // 
            // 生成自动代码MToolStripMenuItem
            // 
            this.生成自动代码MToolStripMenuItem.Name = "生成自动代码MToolStripMenuItem";
            this.生成自动代码MToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.生成自动代码MToolStripMenuItem.Text = "生成自动代码(&M)";
            // 
            // 自动保存ToolStripMenuItem
            // 
            this.自动保存ToolStripMenuItem.Checked = true;
            this.自动保存ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.自动保存ToolStripMenuItem.Name = "自动保存ToolStripMenuItem";
            this.自动保存ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.自动保存ToolStripMenuItem.Text = "自动保存";
            this.自动保存ToolStripMenuItem.Click += new System.EventHandler(this.自动保存ToolStripMenuItem_Click);
            // 
            // sQLPToolStripMenuItem
            // 
            this.sQLPToolStripMenuItem.Name = "sQLPToolStripMenuItem";
            this.sQLPToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.sQLPToolStripMenuItem.Text = "KHGL(&Q)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(900, 720);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "GraphDBMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            this.panelMainMenu.ResumeLayout(false);
            this.panelMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainMenu;
        private KHGraphDBMS.KHMenu.KH_Menu MainMenu;

        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem SAVE;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 视图VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 项目PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private KHCodeTextBox.KHCodeTextArea textArea1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private KH_GraphControls.GraphPanel.GraphPanel panelGraph;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbMax;
        private System.Windows.Forms.ToolStripMenuItem 探索模式WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 代码模式CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分栏显示TToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.ToolStripMenuItem 添加节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加边ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加边EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 呼出控制台CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成自动代码MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShutDown;
        private System.Windows.Forms.SaveFileDialog saveDatabaseDialog;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem 自动保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 添加类型NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改类型DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除类型DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建查询SToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加点NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加平凡点NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按类型添加YToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除点DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建查询SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加边ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 修改边AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除边DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建查询SToolStripMenuItem2;
        
        
    }
}

