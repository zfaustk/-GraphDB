using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHGraphDBMS.KHCodeTextBox
{
    public partial class CodeTextBox : RichTextBox
    {
        public CodeColorConfig Colorconfig { get { return colorconfig; } set { colorconfig = value; } }
        CodeColorConfig colorconfig = new CodeColorConfig();

        /// <summary>  
        /// 关键字组
        /// </summary> 
        public Dictionary<string, bool> Keyword { get { return Colorconfig.Keyword; } }

        /// <summary>  
        /// 保留字组
        /// </summary> 
        public Dictionary<string, bool> PreserveWord { get { return Colorconfig.PreserveWord; } }

        //后面的代码需要使用SendMessage，加到类里就可以了（为什么需要使用，后面说）：
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Colorconfig.BorderColor)), 0, 0, Width - 1, Height - 1);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Colorconfig.BorderColor)), 0, 0, Width - 1, Height - 1);
        }

        //重写OnTextChanged方法：
        protected override void OnTextChanged(EventArgs e)
        {
            
            base.OnTextChanged(e);
            SendMessage(base.Handle, 0xB, 0, IntPtr.Zero);  //防止闪烁
            int sIndex = this.SelectionStart;
            int nSelectStart = this.SelectionStart;
            int nSelectLength = this.SelectionLength;
            //while (sIndex < this.Text.Length)
            //{
            //    int nIndex = 0;
            //    this.SelectAll();
            //    this.SelectionColor = colorconfig.NormalWordColor;
            //    Dictionary<string, bool> keywords = colorconfig.Keyword;
            //    foreach (string key in keywords.Keys)
            //    {
            //        int position = nIndex;
            //        while ((key.Length - 2) != (position = key.Length - 1 + this.Find(key, position, -1, RichTextBoxFinds.None | (keywords[key] ? RichTextBoxFinds.WholeWord : RichTextBoxFinds.None))))
            //        {
            //            this.SelectionColor = color;
            //        }   //调用改变文字颜色的方法
            //    }

            //        this.Find("wings", nIndex, RichTextBoxFinds.WholeWord);
            //    if (nIndex < 0) break;
            //    this.Select(nIndex, 5);
            //    this.SelectionColor = colorconfig.KeyWordColor;
            //    nIndex += 5;
            //    nIndex = this.Find("winga", nIndex, RichTextBoxFinds.WholeWord);
            //    if (nIndex < 0) break;
            //    this.Select(nIndex, 5);
            //    this.SelectionColor = colorconfig.PreserveWordColor;
            //    nIndex += 5;
            //}
            //if (txtChangeNum > 1)
            //{
                this.SelectAll();
                this.SelectionColor = Colorconfig.NormalWordColor;
                foreach (string key in Colorconfig.Keyword.Keys)
                {
                    ChangeColor(key, Colorconfig.KeyWordColor, Colorconfig.Keyword[key]);              //调用改变文字颜色的方法
                }

                foreach (string key in Colorconfig.PreserveWord.Keys)
                {
                    ChangeColor(key, Colorconfig.PreserveWordColor, Colorconfig.PreserveWord[key]);              //调用改变文字颜色的方法

                }
                ChangeColorString(Colorconfig.StringColor);
                this.Select(sIndex, 0);
                this.SelectionColor = Colorconfig.NormalWordColor;
            //}
            //else
            //{
            //    int seIndex = sIndex;
            //    if (sIndex > 0 && !char.IsWhiteSpace(this.Text[sIndex])) { sIndex -- ;}
            //    if (seIndex < this.Text.Length && !char.IsWhiteSpace(this.Text[sIndex])) { sIndex--; }
            //    this.Select(sIndex, seIndex - sIndex);
            //    this.SelectionColor = colorconfig.NormalWordColor;

            //    foreach (string key in colorconfig.Keyword.Keys)
            //    {
            //        ChangeColorPos(sIndex, seIndex, key, colorconfig.KeyWordColor, colorconfig.Keyword[key]);              //调用改变文字颜色的方法
            //    }

            //    foreach (string key in colorconfig.PreserveWord.Keys)
            //    {
            //        ChangeColorPos(sIndex, seIndex, key, colorconfig.PreserveWordColor, colorconfig.PreserveWord[key]);              //调用改变文字颜色的方法
            //    }
            //    //ChangeColorString(colorconfig.StringColor);
            //    this.Select(sIndex, 0);
            //    this.SelectionColor = colorconfig.NormalWordColor;
            //}
            SendMessage(base.Handle, 0xB, 1, IntPtr.Zero);
            this.Select(nSelectStart, nSelectLength);
            this.Refresh();

        }

        //定义改变文字颜色的私有方法：
        private void ChangeColor(string text, Color color , bool wholeWord )
        {
            int position = 0;//this.GetCharIndexFromPosition(new Point(0, 0));
            while ((text.Length - 2) != (position = text.Length - 1 + this.Find(text, position, -1, RichTextBoxFinds.None | (wholeWord ? RichTextBoxFinds.WholeWord : RichTextBoxFinds.None) )))
            {
                this.SelectionColor = color;
            }
        }

        //定义改变文字颜色的私有方法：
        private void ChangeColorPos(int start, int end, string text, Color color, bool wholeWord)
        {
            int position = start;
            while ((text.Length - 2) != (start = text.Length - 1 + this.Find(text, start, end, RichTextBoxFinds.None | (wholeWord ? RichTextBoxFinds.WholeWord : RichTextBoxFinds.None))))
            {
                this.SelectionColor = color;
            }
        }



        //定义改变文字颜色的私有方法：
        private void ChangeColorString(Color color)
        {
            Regex reg1 = new Regex("(\'[^\']*\')|(\"[^\"]*\")");
            MatchCollection ma1 = reg1.Matches(this.Text);

            int indexMatch = 0;
            foreach (var key in ma1)
            {
                Match mat = reg1.Match(this.Text, indexMatch);
                indexMatch = mat.Index + mat.Length;
                this.Select(mat.Index, mat.Length);
                this.SelectionColor = color;
            }

        }
        //调用了RichTextBox的Find方法循环查询文字。
        //RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord 是查询的选项，分别代表大小写匹配和全字匹配。
        //当查询到结果的时候就会选中查询的文字，this.SelectionColor = color就是将选中的文字的颜色改变
        //如果将上面蓝色的使用SendMessage的代码去掉的话，在输入文字时，就能看见需要变色的文字被选中的效果闪了一下。

        public CodeTextBox()
        {
            InitializeComponent();
        }

        public CodeTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
