using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_world_phenomen
{
   public  class Program
    {
        static void Main(string[] args)
        {
            string option;

            Stopwatch stopwatch = new Stopwatch();
            const string defaultSample = "Test/Sample/";
            const string defaultComplete = "Test/Complete/extreme/";
            const string defaultLarge = "Test/Complete/large/";
            const string defaultmedium = "Test/Complete/medium/";



            Dictionary<string, List<string>> moviesData = TestUnit.readMovies(defaultComplete + "Movies122806.txt");
            Graph graph = new Graph();
            graph.constract_graph(moviesData);
            Console.WriteLine("Enter 0 to run with optmization idea");
            Console.WriteLine("Enter 1 to run without optmization idea");
            Console.WriteLine("Enter 2 to run first bonus ");
            option = Console.ReadLine();
            if (option == "0")
            {

                stopwatch.Start();
                List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultComplete + "queries22.txt");
                queries.ForEach(pair =>
                {
                    Console.WriteLine(pair.Key + "/" + pair.Value);
                    graph.BFS(graph.actorToNumber[pair.Key], graph.actorToNumber[pair.Value], true);
                    Console.WriteLine();
                });
            }
            else if (option == "1")
            {

                stopwatch.Start();
                List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultComplete + "queries22.txt");
                queries.ForEach(pair =>
                {
                    Console.WriteLine(pair.Key + "/" + pair.Value);
                    graph.BFS(graph.actorToNumber[pair.Key], graph.actorToNumber[pair.Value]);
                    Console.WriteLine();
                });
            }
            else if (option == "2")
            {

                Console.Write("Enter actor name : ");
                string actor = Console.ReadLine();
                stopwatch.Start();
                if (graph.actorToNumber.ContainsKey(actor))
                {
                    graph.BFS(graph.actorToNumber[actor], graph.actorToNumber[actor], false, true);
                }


            }

            stopwatch.Stop();
            Console.WriteLine("seconds : {0}s , MilleSeconds: {1}",stopwatch.Elapsed.TotalSeconds, stopwatch.Elapsed.Milliseconds );

        }
    }
}