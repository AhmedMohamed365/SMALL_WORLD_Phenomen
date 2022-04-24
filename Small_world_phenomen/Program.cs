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
            Dictionary<string, LinkedList<string>> moviesData = TestUnit.readMovies(defaultComplete + "movies193.txt");

            foreach(var pair in moviesData)
            {
                Console.WriteLine("key : " + pair.Key + "  value: " + pair.Value.First.Value);
            }


            List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultComplete + "queries110.txt");

            queries.ForEach(pair =>
           {

               Console.WriteLine("actor : " + pair.Key + " || Relate to actor: " + pair.Value);
               
           });
        }
    }
}
