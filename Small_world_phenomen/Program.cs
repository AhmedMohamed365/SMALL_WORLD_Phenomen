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
            Dictionary<string, List<string>> moviesData = TestUnit.readMovies(defaultSample + "movies1.txt");
            Graph graph = new Graph();
            graph.constract_graph(moviesData);


            List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultSample + "queries1.txt");
            queries.ForEach(pair =>
            {
                graph.BFS(pair.Key, pair.Value, graph.adjcencyList);
                Console.WriteLine(graph.distances[pair.Value]);
            });
        }
    }
}
