
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
            this.MainMenu = new KHGraphDBMS.KHMenu.KH_Menu(this.components);
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelGraph = new KH_GraphControls.GraphPanel.GraphPanel();
            this.textArea1 = new KHGraphDBMS.KHCodeTextBox.KHCodeTextArea();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMainMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainMenu.Controls.Add(this.button1);
            this.panelMainMenu.Controls.Add(this.MainMenu);
            this.panelMainMenu.Location = new System.Drawing.Point(0, 34);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(891, 23);
            this.panelMainMenu.TabIndex = 1;
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
            this.MainMenu.Size = new System.Drawing.Size(891, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip2";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.bToolStripMenuItem,
            this.toolStripSeparator1,
            this.cToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aToolStripMenuItem.Text = "新建(&N)";
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.bToolStripMenuItem.Text = "打开(&O)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cToolStripMenuItem.Text = "添加(&D)";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.退出ToolStripMenuItem.Text = "退出(&X)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 视图VToolStripMenuItem
            // 
            this.视图VToolStripMenuItem.Name = "视图VToolStripMenuItem";
            this.视图VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.视图VToolStripMenuItem.Text = "视图(&V)";
            // 
            // 项目PToolStripMenuItem
            // 
            this.项目PToolStripMenuItem.Name = "项目PToolStripMenuItem";
            this.项目PToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.项目PToolStripMenuItem.Text = "项目(&P)";
            // 
            // sQLPToolStripMenuItem
            // 
            this.sQLPToolStripMenuItem.Name = "sQLPToolStripMenuItem";
            this.sQLPToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.sQLPToolStripMenuItem.Text = "SQL(&Q)";
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
            this.panelMain.Controls.Add(this.panelGraph);
            this.panelMain.Controls.Add(this.textArea1);
            this.panelMain.Controls.Add(this.panelMainMenu);
            this.panelMain.Controls.Add(this.lbTitle);
            this.panelMain.Controls.Add(this.pbLogo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(893, 544);
            this.panelMain.TabIndex = 4;
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
            this.panelGraph.Location = new System.Drawing.Point(539, 63);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(341, 468);
            this.panelGraph.TabIndex = 7;
            // 
            // textArea1
            // 
            this.textArea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textArea1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.textArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.textArea1.CodeText = resources.GetString("textArea1.CodeText");
            this.textArea1.KeyWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(139)))), ((int)(((byte)(210)))));
            this.textArea1.Location = new System.Drawing.Point(10, 63);
            this.textArea1.Name = "textArea1";
            this.textArea1.NormalWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(225)))), ((int)(((byte)(222)))));
            this.textArea1.PreserveWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(153)))), ((int)(((byte)(16)))));
            this.textArea1.ScrollColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(129)))), ((int)(((byte)(104)))));
            this.textArea1.Size = new System.Drawing.Size(523, 468);
            this.textArea1.StringColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(161)))), ((int)(((byte)(134)))));
            this.textArea1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(805, -3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(893, 544);
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
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainMenu;
        private KHGraphDBMS.KHMenu.KH_Menu MainMenu;

        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
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
        private System.Windows.Forms.Button button1;
        
        
    }
}

