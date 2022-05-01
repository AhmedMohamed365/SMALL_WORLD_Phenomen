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
            Dictionary<string, List<string>> moviesData = TestUnit.readMovies(defaultSample + "movies1.txt");



            Graph graph = new Graph();

           // graph.

            foreach (var movie in moviesData)
            {
                
              //  Console.Write("key : " +  + "  value: ");
                

                foreach (var actor in movie.Value)
                {
                    

                    foreach (var friend in movie.Value)
                    {
                       
                        if ( actor != friend)
                        {
                            if (!graph.adjcencyList.ContainsKey(actor))
                            {

                                List<string> films = new List<string>();
                                films.Add(movie.Key);

                                Dictionary<string, List<string>> friendInfo = new Dictionary<string, List<string>>();
                                friendInfo.Add(friend, films);

                                graph.adjcencyList.Add(actor, friendInfo);
                            }
                              

                         else
                            {
                                
                                


                                if (!graph.adjcencyList[actor].ContainsKey(friend))
                                {
                                    List<string> films = new List<string>();
                                    films.Add(movie.Key);
                                    graph.adjcencyList[actor].Add(friend, films);
                                }
                                   

                                else
                                {
                                    graph.adjcencyList[actor][friend].Add(movie.Key);
                                }
                             }
                        }



                        
                    }

                    

                }

                

               
            }


            graph.BFS("A", "D", graph.adjcencyList);

            //Queries Question 
            List<KeyValuePair<string, string>> queries = TestUnit.readQueries(defaultSample + "queries1.txt");

           // queries.ForEach(pair =>
           //{

           //    Console.WriteLine("actor : " + pair.Key + " || Relate to actor: " + pair.Value);
               
           //});
        }
    }
}
