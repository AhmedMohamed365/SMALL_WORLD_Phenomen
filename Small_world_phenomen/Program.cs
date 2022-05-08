using System;
using System.Collections.Generic;
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
            const string defaultComplete = "Test/Complete/small/Case2/";
            //Dictionary<string, List<string>> moviesData = TestUnit.readMovies(defaultSample + "movies1.txt");

            Dictionary<string, List<string>> moviesData = TestUnit.readMovies(defaultComplete + "Movies187.txt");


            Graph graph = new Graph();
            graph.constract_graph(moviesData);

            

            //List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultSample + "queries1.txt");

            List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultComplete + "queries2.txt");

            queries.ForEach(pair =>
            {
                graph.BFS(pair.Key, pair.Value, graph.adjcencyList);

                int distance = graph.distances[pair.Value];
                Console.WriteLine(pair.Key + " / " + pair.Value);

                Console.Write(distance + " : ");
                graph.printPath(pair.Key, pair.Value, distance);
                Console.WriteLine();

                //Console.WriteLine("Strength: "+graph.printPath(pair.Key, pair.Value, distance )  );


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
