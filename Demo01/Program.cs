using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;

using KHGraphDB.Algorithm;
using System.Windows.Forms;
using KHGraphDB.Helper;

namespace Demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            KHGraphDB.Structure.Type student = new KHGraphDB.Structure.Type(new Dictionary<string, object>(){
                {"Name",null}, {"Num",null}
            });
            student.Name = "Student";

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
            Vertex aaa = new Vertex(new Dictionary<string, object>(){
                {"Name","aaa"},
                {"Age","21"}
            });
            Vertex bbb = new Vertex(new Dictionary<string, object>(){
                {"Name","bbb"},
                {"Age","21"}
            });
            Vertex ccc = new Vertex(new Dictionary<string, object>(){
                {"Name","ccc"},
                {"Age","21"}
            });
            Vertex ddd = new Vertex(new Dictionary<string, object>(){
                {"Name","ddd"},
                {"Age","21"}
            });
            Vertex eee = new Vertex(new Dictionary<string, object>(){
                {"Name","eee"},
                {"Age","21"}
            });


            GraphHelper gHelper = new GraphHelper(graph);

            gHelper.AddType(student);
            gHelper.AddVertex(peiming, student);
            graph.AddVertex(yidong, student);
            graph.AddVertex(weidong);
            graph.AddVertex(aaa);
            graph.AddVertex(bbb);
            graph.AddVertex(ccc);
            graph.AddVertex(ddd);
            graph.AddVertex(eee);

            Console.WriteLine(peiming.ToString());
            Console.WriteLine(yidong.ToString());
            Console.WriteLine(weidong.ToString());

            Console.WriteLine(peiming.IncomingEdges.Count());
            Console.WriteLine(yidong.IncomingEdges.Count());
            Console.WriteLine(weidong.IncomingEdges.Count());



            Edge friendPY = new Edge(peiming, yidong, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"friend",null},
            });

            Edge friendYP = new Edge(yidong, peiming, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"friend",null},
            });

            Edge friendPA = new Edge(peiming, aaa, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"friend",1},
            });
            Edge friendAB = new Edge(aaa, bbb, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"friend",0.1},
            });
            Edge friendBC = new Edge(bbb, ccc, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"friend",2},
            });
            Edge friendYD = new Edge(yidong, ddd, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"friend",10},
            });
            Edge friendAE = new Edge(aaa, eee, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase){
                {"friend",0.5},
            });
            graph.AddEdge(friendAE);

            graph.AddEdge(friendPA);
            graph.AddEdge(friendAB);
            graph.AddEdge(friendBC);
            graph.AddEdge(friendYD);
            graph.AddEdge(friendPY);
            graph.AddEdge(friendYP);

            gHelper.AddEdge(peiming, weidong, new Dictionary<string, object>() { { "friend", null } });

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
