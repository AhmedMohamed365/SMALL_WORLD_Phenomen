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
            const string defualtPath = "Test/Sample/movies1.txt";
            Dictionary<string, LinkedList<string>> moviesData = TestUnit.readMovies(defualtPath);

            foreach(var pair in moviesData)
            {
                Console.WriteLine("key : " + pair.Key + "  value: " + pair.Value.First.Value);
            }

        }
    }
}
