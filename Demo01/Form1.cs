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
using KHGraphDB.Structure.Interface;

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
            Vertex aa = new Vertex(new Dictionary<string, object>(){
                    {"Name",textBox1.Text}
                });
            IVertex v = panel1.Graph.Vertices.SingleOrDefault(m =>"Peiming".Equals(m["Name"]) );
            this.panel1.Graph.AddVertex(aa);
            IEdge ee = new Edge(v,aa);
            panel1.Graph.AddEdge(ee);
        }
    }
}
