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

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Dictionary<string, List<string>> moviesData = TestUnit.readMovies(defaultComplete + "Movies122806.txt");


            Graph graph = new Graph();
            graph.constract_graph(moviesData);



            List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultComplete + "queries200.txt");

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            //Dictionary<string , List<string>> queries = TestUnit.readQueries(defaultComplete + "queries200.txt");

            //A , B
            int counter = 0;

          // Console.WriteLine( queries.Count(pair => pair.Key == "Z") );
           
            queries.ForEach(pair =>
            {
             
                

                    graph.BFS(pair.Key, pair.Value, graph.adjcencyList);
                
                

                //int distance = graph.[pair.Value];
                //Console.WriteLine();
                //int max = int.MinValue;
                //Console.WriteLine("Distance : {0}  ", distance);

                
                //  graph.printPath(pair.Key, pair.Value, distance);
                //foreach(var film in graph.films)
                //{
                //    Console.Write(film + " ");

                //}

                Console.WriteLine();
            });


            Console.Read();
        }
    }
}