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

      
        public static List<KeyValuePair<string, string>> readQueries(string path)
        {
            List<KeyValuePair<string, string>> actors_pairs = new List<KeyValuePair<string, string>>();
            char[] seprators = { '/' };
            StreamReader reader = new StreamReader(path);

            KeyValuePair<string, string> actor_pair;
            while (!reader.EndOfStream)
            {

                string[] values = reader.ReadLine().Split(seprators);

                for(int i = 0; i <values.Length -1;i++)
                {
                    actor_pair = new KeyValuePair<string, string>(values[i], values[i+1]); 

                    actors_pairs.Add(actor_pair);
                }
                

            }


            reader.Close();

            return actors_pairs;
        }


        public static Dictionary<string, List<string>> readMovies(string path)
        {
            //Movie //num //actor / actor2 is the format of file

            char[] seprators = {  '/' };
            Dictionary<string, List<string>> moviesData = new Dictionary<string, List<string>>();

            StreamReader reader = new StreamReader(path);
            
            while(!reader.EndOfStream)
            {
                
                List<string> actorsInMovie = new List<string>();

                string line = reader.ReadLine(); 

               string [] input =  line.Split(seprators);
 
                
                //input[0] = MovieName

                    moviesData.Add(input[0], actorsInMovie);

                
                for (int i = 1; i <input.Length;i++)
                {
                    actorsInMovie.Add(input[i]);
                }

                
            }


            reader.Close();

            return moviesData;
        }

      


    }
}
