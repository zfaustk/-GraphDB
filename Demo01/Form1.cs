using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHGraphDB.Algorithm;
using KHGraphDB.Helper;
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

        private GraphHelper vHelper;

        public void AddGraph(Graph g)
        {
            this.panel1.Graph = g;
            vHelper = new GraphHelper(g);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            IVertex aa = vHelper.AddVertex(null, new Dictionary<string, object>(){
                    {"Name",textBox1.Text}
                });

            IEnumerable<IVertex> vs = vHelper.SelectVerteics("name", "Peiming", "student");

            foreach(var v in vs){
                vHelper.AddEdge(v, aa, new Dictionary<string, object>(){
                    {"name","add"}
                });
                vHelper.AddEdge(v, aa, new Dictionary<string, object>(){
                    {"name","add2"}
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox2.Text))return;

            IVertex v = panel1.Graph.Vertices.SingleOrDefault(m => "Peiming".Equals(m["Name"]));
            v[textBox2.Text] = "Add";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BreadthFirstSearch bfs = new BreadthFirstSearch();
            IVertex v = panel1.Graph.Vertices.SingleOrDefault(m => "Peiming".Equals(m["name"]));
            IVertex vw = panel1.Graph.Vertices.SingleOrDefault(m => "Weidong".Equals(m["Name"]));
            if (panel1.HighLightList == null)
                panel1.HighLightList = bfs.Search(panel1.Graph, v, vw);
            else panel1.HighLightList = null;
        }
    }
}
