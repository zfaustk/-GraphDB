using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHGraphDBMS.KHCodeTextBox
{
    public partial class CodeTextBox : RichTextBox
    {
        ColorConfig colorconfig = new ColorConfig();

        //后面的代码需要使用SendMessage，加到类里就可以了（为什么需要使用，后面说）：
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);

        //重写OnTextChanged方法：
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            SendMessage(base.Handle, 0xB, 0, IntPtr.Zero);  //防止闪烁
            int sIndex = this.SelectionStart;
            //this.ForeColor = colorconfig.NormalWordColor;

            int nSelectStart = this.SelectionStart;
            int nSelectLength = this.SelectionLength;
            int nIndex = this.GetCharIndexFromPosition(new Point(0, 0));    //只修改显示的行
            this.SelectAll();
            this.SelectionColor = colorconfig.NormalWordColor;
            while (nIndex < this.Text.Length)
            {
                nIndex = this.Find("wings", nIndex, RichTextBoxFinds.WholeWord);
                if (nIndex < 0)
                {
                    break;
                }
                this.Select(nIndex, 5);
                this.SelectionColor = colorconfig.KeyWordColor;
                nIndex += 5;
            }
            this.Select(nSelectStart, nSelectLength);

            //this.Select(sIndex, 0);
            //ChangeColor("static", colorconfig.PreserveWordColor);              //调用改变文字颜色的方法
            //ChangeColor("void", colorconfig.PreserveWordColor);
            //this.Select(sIndex, 0);
            //this.SelectionColor = colorconfig.NormalWordColor;
            SendMessage(base.Handle, 0xB, 1, IntPtr.Zero);
            this.Refresh();

            

        }

        //定义改变文字颜色的私有方法：
        private void ChangeColor(string text, Color color)
        {
            int s = 0;
            while ((-1 + text.Length - 1) != (s = text.Length - 1 + this.Find(text, s, -1, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord)))
            {
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
