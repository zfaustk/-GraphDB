namespace KHGraphDBMS.KHCodeTextBox
{
    partial class KHCodeTextArea
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            KHGraphDBMS.KHCodeTextBox.CodeColorConfig codeColorConfig1 = new KHGraphDBMS.KHCodeTextBox.CodeColorConfig();
            this.panelBack = new System.Windows.Forms.Panel();
            this.codeTextBox = new KHGraphDBMS.KHCodeTextBox.CodeTextBox(this.components);
            this.scroll = new System.Windows.Forms.Panel();
            this.panelBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.panelBack.Controls.Add(this.codeTextBox);
            this.panelBack.Controls.Add(this.scroll);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Padding = new System.Windows.Forms.Padding(8, 5, 5, 5);
            this.panelBack.Size = new System.Drawing.Size(632, 314);
            this.panelBack.TabIndex = 0;
            // 
            // codeTextBox
            // 
            this.codeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.codeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            codeColorConfig1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            codeColorConfig1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            codeColorConfig1.KeyWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(139)))), ((int)(((byte)(210)))));
            codeColorConfig1.NormalWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(225)))), ((int)(((byte)(222)))));
            codeColorConfig1.PreserveWordColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(153)))), ((int)(((byte)(16)))));
            codeColorConfig1.ScrollColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(129)))), ((int)(((byte)(104)))));
            codeColorConfig1.StringColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(161)))), ((int)(((byte)(134)))));
            this.codeTextBox.Colorconfig = codeColorConfig1;
            this.codeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeTextBox.Font = new System.Drawing.Font("Menlo", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox.ForeColor = System.Drawing.Color.White;
            this.codeTextBox.Location = new System.Drawing.Point(8, 5);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.codeTextBox.Size = new System.Drawing.Size(619, 304);
            this.codeTextBox.TabIndex = 0;
            this.codeTextBox.Text = "";
            this.codeTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.codeTextBox.Resize += new System.EventHandler(this.codeTextBox_Resize);
            // 
            // scroll
            // 
            this.scroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(129)))), ((int)(((byte)(104)))));
            this.scroll.Location = new System.Drawing.Point(0, 5);
            this.scroll.Name = "scroll";
            this.scroll.Size = new System.Drawing.Size(632, 53);
            this.scroll.TabIndex = 1;
            this.scroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scroll_MouseDown);
            this.scroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_MouseMove);
            this.scroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_MouseUp);
            // 
            // KHCodeTextArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBack);
            this.Name = "KHCodeTextArea";
            this.Size = new System.Drawing.Size(632, 314);
            this.Load += new System.EventHandler(this.KHCodeTextArea_Load);
            this.panelBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private KHCodeTextBox.CodeTextBox codeTextBox;
        private System.Windows.Forms.Panel scroll;
    }
}
