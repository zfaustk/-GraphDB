using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;

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
                {"Age","22"}
            });

            Vertex yidong = new Vertex(new Dictionary<string, object>(){
                {"Name","Yidong"},
                {"Age","21"}
            });

            graph.AddType(student);

            graph.AddVertex(peiming, student);
            graph.AddVertex(yidong, student);

            Console.WriteLine(peiming.IncomingEdges.Count());
            Console.WriteLine(yidong.IncomingEdges.Count());

            Console.WriteLine(peiming.ToString());

            Edge friend = new Edge(peiming, yidong, new Dictionary<string, object>(){
                {"relationship","friend"},
            });

            graph.AddEdge(friend);

            Console.WriteLine(peiming.IncomingEdges.Count());
            Console.WriteLine(yidong.IncomingEdges.Count());

            Console.WriteLine(peiming.ToString());

        }
    }
}
