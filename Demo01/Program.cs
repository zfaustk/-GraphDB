using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;

using KHGraphDB.Algorithm;
using System.Windows.Forms;

namespace Demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            KHGraphDB.Structure.Type student = new KHGraphDB.Structure.Type(new Dictionary<string, object>(){
                {"Name","Student"},
            });

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
            graph.AddVertex(weidong);

            Console.WriteLine(peiming.ToString());
            Console.WriteLine(yidong.ToString());
            Console.WriteLine(weidong.ToString());

            Console.WriteLine(peiming.IncomingEdges.Count());
            Console.WriteLine(yidong.IncomingEdges.Count());
            Console.WriteLine(weidong.IncomingEdges.Count());



            Edge friendPY = new Edge(peiming, yidong, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"relationship","friend"},
            });

            Edge friendYP = new Edge(yidong, peiming, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"relationship",null},
            });

            Edge friendYW = new Edge(yidong, weidong, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"relationship","friend"},
            });

            graph.AddEdge(friendPY);
            graph.AddEdge(friendYP);
            graph.AddEdge(friendYW);

            Console.WriteLine(peiming.InDegree);
            Console.WriteLine(peiming.OutDegree);
            Console.WriteLine(yidong.InDegree);
            Console.WriteLine(yidong.OutDegree);
            Console.WriteLine(weidong.InDegree);
            Console.WriteLine(weidong.OutDegree);

            Console.WriteLine(peiming.ToString());
            Console.WriteLine(yidong.ToString());
            Console.WriteLine(weidong.ToString());

            Console.WriteLine(weidong["Name"]);
            Console.WriteLine("+++");
            BreadthFirstSearch bfs01 = new BreadthFirstSearch();
            var path = bfs01.Search(graph, peiming, weidong);

            foreach (var v in path)
            {
                Console.WriteLine(v["Name"]);
            }

            BreadthFirstSearch bfs02 = new BreadthFirstSearch();
            path = bfs02.Search(graph, peiming, weidong, false);

            foreach (var v in path)
            {
                Console.WriteLine(v["Name"]);
            }

            BreadthFirstSearch bfs03 = new BreadthFirstSearch();
            path = bfs03.Search(graph, weidong, peiming);

            if(null != path )
            foreach (var v in path)
            {
                Console.WriteLine(v["Name"]);
            }



            Console.ReadKey(true);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            form.AddGraph(graph);
            Application.Run(form);

            

        }
    }
}
