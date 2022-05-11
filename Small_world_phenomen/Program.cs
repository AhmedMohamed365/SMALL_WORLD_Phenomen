using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_world_phenomen
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultSample = "Test/Sample/";
            const string defaultComplete = "Test/Complete/extreme/";
            //Dictionary<string, List<string>> moviesData = TestUnit.readMovies(defaultSample + "movies1.txt");

            //Dictionary<string, LinkedList<string>> moviesData = TestUnit.readMovies2(defaultComplete + "Movies122806.txt");


            //Graph graph = new Graph();
            //graph.constract_graph(moviesData);



            ////List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultSample + "queries1.txt");

            //List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultComplete + "queries200.txt");

            //queries.ForEach(pair =>
            //{
            //    graph.BFS(pair.Key, pair.Value, graph.adjcencyList,false);

            //    int distance = graph.distances[pair.Value];
            //    Console.WriteLine(pair.Key + " / " + pair.Value);

            //    Console.Write(distance + " : ");
            //   // graph.printPath(pair.Key, pair.Value, distance);
            //    Console.WriteLine();

            //    //Console.WriteLine("Strength: "+graph.printPath(pair.Key, pair.Value, distance )  );


            //    //foreach(var film in graph.films)
            //    //{
            //    //    Console.Write(film + " ");

            //    //}

            //    Console.WriteLine();
            //});


            //Console.Read();

            uint size = 500000;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            // ...

            LinkedList list = new LinkedList();
            for (int i = 0; i < size; i++)
            {
                list.AddLast("A");
            }

            Node node = list.First;

            Console.WriteLine("my Linked list");

           



            Console.WriteLine(" my Copied Linked list");

            LinkedList list2 = new LinkedList(list, list.First.Next);

            node = list2.First;

           
            sw.Stop();

            Console.WriteLine("Elapsed={0}", sw.Elapsed);







            Stopwatch sw2 = new Stopwatch();

            sw2.Start();

            LinkedList<string> list11 = new LinkedList<string>();

            for (int i = 0; i < size; i++)
            {
                list11.AddLast("A");
            }

            LinkedListNode<string> node11 = list11.First;

            Console.WriteLine("standard Linked list");

            



            Console.WriteLine(" standard Copied Linked list");

            LinkedList<string> list222 = new LinkedList<string>(list11);

            node11 = list222.First;

            

            sw2.Stop();

            Console.WriteLine("Elapsed2={0}", sw2.Elapsed);




            Console.WriteLine("Speed Up={0}", sw2.Elapsed.TotalSeconds / sw.Elapsed.TotalSeconds  +"X");




            Console.ReadLine();
        }
    }
}
