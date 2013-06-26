using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHGraphDB.Structure;

namespace Demo01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void AddGraph(Graph g)
        {
            this.panel1.Graph = g;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Graph.AddVertex(
                new Vertex(new Dictionary<string, object>(){
                    {"Name",textBox1.Text}
                })
            );
        }
    }
}
