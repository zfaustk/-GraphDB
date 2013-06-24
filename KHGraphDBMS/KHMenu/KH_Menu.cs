using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHGraphDBMS.KHMenu
{
    public partial class KH_Menu : MenuStrip
    {
        public KH_Menu()
        {
            InitializeComponent();
            this.Renderer = new MenuRender();
        }


        public KH_Menu(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.Renderer = new MenuRender();
        }
        
    }
}
