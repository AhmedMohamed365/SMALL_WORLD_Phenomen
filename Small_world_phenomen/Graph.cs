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
        public Dictionary<string, string> parents;
        public Dictionary<string, int> distances;
        public Stack<List<string>> movies;
        public Stack<string> parentNames;
        public HashSet<string> films;
        public Graph()
        {
            adjcencyList = new Dictionary<string, Dictionary<string, List<string>>>();
            colors = new Dictionary<string, COLORS>();
            parents = new Dictionary<string, string>();
            distances = new Dictionary<string, int>();
            
            films = new HashSet<string>();


        }

        public void printPath(string source, string destination, int distance)
        {
            int strength = calcPath(source, destination, distance);

            Console.WriteLine(strength);
            while (parentNames.Count != 0)
            {

               Console.Write(parentNames.Pop() + " ");
                
               Console.Write("=>");

            }


            Console.WriteLine();

            while (movies.Count != 0)
            {
                foreach (var movie in movies.Pop())
                {
                    Console.Write(movie + " ");
                }
                Console.Write("=>");

            }
            Console.WriteLine();
        }
        public int calcPath(string source, string destination, int distance)
        {
             movies = new Stack<List<string>>();
             parentNames = new Stack<string>();

            string parent = parents[destination], child;

            child = destination;


            parentNames.Push(destination);
            int strength = 0;
            for (int i =0; i < distance; i++)
            {
                strength += adjcencyList[child][parent].Count;


                //if(i == distance-1)
                //    parentNames.Push(source);

                movies.Push(adjcencyList[child][parent]);
                parentNames.Push(parent);

                child = parent;


                

                if (!parents.ContainsKey(child))
                  {
                    break;
                  }
                parent = parents[child];


               


            }


            




            return strength;


        }
        public void BFS(string s, string d, Dictionary<string, Dictionary<string, List<string>>> adjList)
        {
            colors = new Dictionary<string, COLORS>();
            parents = new Dictionary<string, string>();
            distances = new Dictionary<string, int>();
            Queue<string> vertices = new Queue<string>();
            films = new HashSet<string>();
            int distance = 0;

            foreach (var actor in adjList)
            {
                colors.Add(actor.Key, COLORS.WHITE);
                distances.Add(actor.Key, int.MaxValue);

            }


            colors[s] = COLORS.GRAY;
            distances[s] = 0;

            vertices.Enqueue(s);

            string v = "";

            while (vertices.Count != 0)
            {
                v = vertices.Dequeue();
                foreach (var adj in adjList[v].Keys)
                {
                    if(colors[d] != COLORS.WHITE )
                    {
                        return;
                    }
                    if (colors[adj] == COLORS.WHITE )
                    {
                        colors[adj] = COLORS.GRAY;
                        //if (distances[adj] > distances[v] + 1)

                            distances[adj] = distances[v] + 1;
                        if (!parents.ContainsKey(adj))
                        {

                            parents.Add(adj,v);
                        }
                        

                        vertices.Enqueue(adj);

                    }

                    colors[v] = COLORS.BLACK;
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


            //
            //Sorted Dictionary

            for (int i = 0; i < adjcencyList.Count; i++)
            {

                var actor = adjcencyList.ElementAt(i).Key;
                adjcencyList[actor] = adjcencyList[actor].OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            }


            // var sortedDict = from entry in adjcencyList[actor] orderby entry.Value.Count descending select entry;

            //var mySortedList = adjcencyList[actor].OrderBy(d => d.Value.CompareTo(d.Value)).ToList();
            //mySortedList.Sort()
        }

    }




}

        //
    

