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
            const string defaultComplete = "Test/Complete/small/Case1/";
            Dictionary<string, LinkedList<string>> moviesData = TestUnit.readMovies(defaultSample + "movies1.txt");



            /*
            foreach(var pair in moviesData)
            {
                Console.Write("key : " + pair.Key + "  value: " );

              foreach(var node in pair.Value)
                {
                    Console.Write(node+" ");
                }

                Console.WriteLine();
            }

            */


            List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultComplete + "queries110.txt");

            queries.ForEach(pair =>
           {

               Console.WriteLine("actor : " + pair.Key + " || Relate to actor: " + pair.Value);
               
           });
        }
    }
}
