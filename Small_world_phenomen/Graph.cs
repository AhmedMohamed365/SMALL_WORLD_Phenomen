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
    public enum COLORS { BLACK, WHITE, GRAY };
    class Graph
    {

        public Dictionary<string, Dictionary<string, List<string>>> adjcencyList; // key : ActorName ,Value :  Actors connected to (with films) 
        public Dictionary<string, COLORS> colors;
        public Dictionary<string, List<string>> parents;
        public Dictionary<string, int> distances;
        public Stack<List<string>> movies;
        public List<int> strength;

        public Stack<List<string>> bestWay;
        public Graph()
        {
            adjcencyList = new Dictionary<string, Dictionary<string, List<string>>>();
            colors = new Dictionary<string, COLORS>();
            parents = new Dictionary<string, List<string>>();
            distances = new Dictionary<string, int>();
            bestWay = new Stack<List<string>>();


            
        }
        public class visited_Actor
        {
            public string name;
            public int strength;
            public int level;
            public string parent;

       
        public int path(string source , string destination ,int n,string adj,int max)
        {


            foreach (var film in adjcencyList[destination][adj])
            {
                
                films.Add(film);

              //  Console.Write(film + "  ");
            }

         

            //Console.WriteLine();
            n += adjcencyList[destination][adj].Count;

            destination = adj;

            if (adj == source)
                return films.Count;

            
            foreach (var parent in parents[destination])
            {
               max = Math.Max( path(source, destination, n, parent,max)  , max) ;

            }

            return max;
        }
        public void BFS(string s, string d, Dictionary<string, Dictionary<string, List<string>>> adjList)
        {
            colors = new Dictionary<string, COLORS>();
            parents = new Dictionary<string, List<string>>();
            distances = new Dictionary<string, int>();
            Dictionary<string, visited_Actor> visited_actors = new Dictionary<string, visited_Actor>();
            bool destination_found = false;
            visited_Actor source_Actor = new visited_Actor(source, 0, 0, "");
            visited_Actor dest_Acotr = new visited_Actor();
            Queue<string> vertices = new Queue<string>();
            visited_actors.Add(source, source_Actor);
            foreach (var actor in adjList)
            {
                colors.Add(actor.Key, COLORS.WHITE);
                distances.Add(actor.Key, int.MaxValue);

                List<string> parent = new List<string>();
            }


            colors[source] = COLORS.GRAY;
            distances[source] = 0;

            vertices.Enqueue(source);

            string parent = "";

            while (vertices.Count != 0)
            {
                parent = vertices.Dequeue();

                if (destination_found && visited_actors[parent].level >= dest_Acotr.level)
                {
                    Console.WriteLine("strenght = " + dest_Acotr.strength);
                    visited_Actor currentActor = new visited_Actor();
                    Stack<string> bestway = new Stack<string>();
                    currentActor = dest_Acotr;
                    bestway.Push(dest_Acotr.name);

                    if (colors[adj] == COLORS.WHITE || colors[adj] == COLORS.GRAY)
                    {
                        colors[adj] = COLORS.GRAY;
                        if (distances[adj] > distances[v] + 1)
                            distances[adj] = distances[v] + 1;
                        if (parents.ContainsKey(adj))
                        {
                            if(! (parents[adj].Contains(v)) && adjcencyList[v][adj].Count == 0)
                                parents[adj].Add(v);
                        }
                        else
                        {

                            List<string> parent = new List<string>();
                            parent.Add(v);
                            parents[adj] = parent;
                        }

                        vertices.Enqueue(adj);
                    }
                    else
                    {
                        if (visited_actors[adj].strength < (adjList[parent][adj].Count + visited_actors[parent].strength) && visited_actors[adj].level == visited_actors[parent].level + 1)
                        {
                            current_Actor = new visited_Actor(adj, adjList[adj][parent].Count + visited_actors[parent].strength, distances[adj], parent);
                            visited_actors[adj] = current_Actor;
                        }
                    }
                    colors[v] = COLORS.BLACK;
                }

                if (distances[d] != int.MaxValue && !(vertices.Contains(d)))
                {
                    return;
                }
            }
            return;
        }
        public void constract_graph(Dictionary<string, List<string>> moviesData)
        {

            foreach (var movie in moviesData)
            {
                //  Console.Write("key : " +  + "  value: ");
                foreach (var actor in movie.Value)
                {
                    foreach (var friend in movie.Value)
                    {

                        if (actor != friend)
                        {
                            if (!adjcencyList.ContainsKey(actor))
                            {

                                List<string> films = new List<string>();
                                films.Add(movie.Key);

                                Dictionary<string, List<string>> friendInfo = new Dictionary<string, List<string>>();
                                friendInfo.Add(friend, films);
                                adjcencyList.Add(actor, friendInfo);
                            }
                            else
                            {
                                if (!adjcencyList[actor].ContainsKey(friend))
                                {
                                    List<string> films = new List<string>();
                                    films.Add(movie.Key);
                                    adjcencyList[actor].Add(friend, films);
                                }
                                else
                                {
                                    adjcencyList[actor][friend].Add(movie.Key);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
