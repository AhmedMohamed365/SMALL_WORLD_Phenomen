using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_world_phenomen
{

    //Expermintal Class
    //public class Actor_vertex // Actor with films that participate in 
    //{
    //    string actorName;

    //   List<string> movies;
    //}
    public enum  COLORS{ BLACK , WHITE  , GRAY};
    class Graph
    {

        public Dictionary<string  , Dictionary<string , List<string> >> adjcencyList; // key : ActorName ,Value :  Actors connected to (with films) 

         public Graph()
        {
            adjcencyList = new Dictionary<string, Dictionary<string, List<string>>>();
        }


       public  int BFS(string s ,string d, Dictionary<string, Dictionary<string, List<string>>> adjList )
        {
            Dictionary<string, COLORS> colors = new Dictionary<string, COLORS>();
            Dictionary<string, List<string>> parents = new Dictionary<string, List<string>>();
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Queue<string> vertices = new Queue<string>();
            int distance = 0;

            foreach ( var actor in adjList)
            {
                colors.Add(actor.Key, COLORS.WHITE);
                distances.Add(actor.Key, int.MaxValue);

                List<string> parent = new List<string>();
                parent.Add("");
                parents.Add(actor.Key,  parent);


            }

            colors[s] = COLORS.GRAY;
            distances[s] = 0;
            
            vertices.Enqueue(s);
            
            string v = "";
            string lastOne = "";
            
            while (vertices.Count != 0)
            {
                v = vertices.Dequeue();


                lastOne = adjList[v].Keys.Last();



                foreach (var adj in adjList[v].Keys)
                {

                    if (colors[adj] == COLORS.WHITE)
                    {
                        colors[adj] = COLORS.GRAY;

                        distances[adj] = distances[v] + 1;

                        parents[adj].Add(v);

                        vertices.Enqueue(adj);
                        lastOne = adj;
                    }


                    colors[v] = COLORS.BLACK;



                }

                if (distances[d] != int.MaxValue &&  (!vertices.Contains(lastOne)))
                {
                    return distances[d];
                }

                


              

            }

            return 0;
        }
    }
}
