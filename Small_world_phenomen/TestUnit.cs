using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_world_phenomen
{
   static  class TestUnit
    {

        public static  void readQueries(string path)
        {

        }
        public static Dictionary<string, LinkedList<string>> readMovies(string path)
        {
            //Movie //num //actor / actor2

            char[] seprators = { ' ', '/' };
            Dictionary<string, LinkedList<string>> movieData = new Dictionary<string, LinkedList<string>>(10);

            StreamReader reader = new StreamReader(path);
            

            
            while(!reader.EndOfStream)
            {
                LinkedList<string> actor_list = new LinkedList<string>();

                string line = reader.ReadLine();

               string [] input =  line.Split(seprators);

                movieData.Add(input[1], actor_list);

                for(int i = 2; i <input.Length;i++)
                {
                    actor_list.AddLast(input[i]);
                }
            }

            // return 


            return movieData;
        }

        public static bool testCode()
        {


            return true;
        }


    }
}
