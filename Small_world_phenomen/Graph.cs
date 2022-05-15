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


        public Dictionary<string  , Dictionary<string, visited_Actor>  > discovered;

        public Stack<List<string>> bestWay;
        public Graph()
        {
            adjcencyList = new Dictionary<string, Dictionary<string, List<string>>>();

            discovered = new Dictionary<string, Dictionary<string, visited_Actor>>();
            bestWay = new Stack<List<string>>();



        }
        public class visited_Actor
        {
            public string name;
            public int strength;
            public int level;
            public string parent;

            public visited_Actor(string name, int strength, int level, string parent)
            {
                this.name = name;
                this.strength = strength;
                this.level = level;
                this.parent = parent;
            }

            public visited_Actor()
            {

            }
        }

        //public void printPath(string source, string destination, int distance)
        //{
        //    int strength = calcPath(source, destination, distance);

        //    Console.WriteLine(strength);
        //    while (parentNames.Count != 0)
        //    {

        //        Console.Write(parentNames.Pop() + " ");

        //        Console.Write("=>");

        //    }


        //    Console.WriteLine();

        //    while (movies.Count != 0)
        //    {
        //        foreach (var movie in movies.Pop())
        //        {
        //            Console.Write(movie + " ");
        //        }
        //        Console.Write("=>");

        //    }
        //    Console.WriteLine();
        //}
        //public int calcPath(string source, string destination, int distance)
        //{
        //    movies = new Stack<List<string>>();
        //    parentNames = new Stack<string>();

        //    string parent = parents[destination], child;

        //    child = destination;


        //    parentNames.Push(destination);
        //    int strength = 0;
        //    for (int i = 0; i < distance; i++)
        //    {
        //        strength += adjcencyList[child][parent].Count;


        //        //if(i == distance-1)
        //        //    parentNames.Push(source);

        //        movies.Push(adjcencyList[child][parent]);
        //        parentNames.Push(parent);

        //        child = parent;




        //        if (!parents.ContainsKey(child))
        //        {
        //            break;
        //        }
        //        parent = parents[child];





        //    }







        //    return strength;


        //}

        public void printInfo(Dictionary<string, visited_Actor>  visited_actors, Dictionary<string, Dictionary<string, List<string>>>  adjList,   visited_Actor dest_Acotr,ref  string source , ref string dest)
        {

            Console.WriteLine("DOS = {0} ,strenght = {1} ", dest_Acotr.level, dest_Acotr.strength);
            visited_Actor currentActor = new visited_Actor();
            Stack<string> bestway = new Stack<string>();
            currentActor = dest_Acotr;
            bestway.Push(dest_Acotr.name);

            for (int i = 0; i < dest_Acotr.level; i++)
            {
                currentActor = visited_actors[currentActor.parent];
                bestway.Push(currentActor.name);
            }
            while (bestway.Count > 1)
            {
                string actor1 = bestway.Pop();
                string actor2 = bestway.Peek();
                foreach (var movies in adjList[actor1][actor2])
                {
                    Console.Write(movies + " ");
                }
                Console.Write("=>");
            }
            Console.WriteLine();

            discovered.Add(source, visited_actors);
        }
        public void  BFS(string source, string dest, Dictionary<string, Dictionary<string, List<string>>> adjList)
        {

            if (discovered.ContainsKey(source))
            {
                if (discovered[source].ContainsKey(dest))
                {

                    printInfo(discovered[source], adjList,   discovered[source][dest],  ref source, ref  dest);

                    return;
                }

            }


            

            Dictionary<string, visited_Actor> visited_actors = new Dictionary<string, visited_Actor>();
            bool destination_found = false;
            visited_Actor source_Actor = new visited_Actor(source, 0, 0, "");
            visited_Actor dest_Acotr = new visited_Actor();
            Queue<string> vertices = new Queue<string>();
            visited_actors.Add(source, source_Actor);
         


           

            vertices.Enqueue(source);

            string parent = "";

            while (vertices.Count != 0)
            {
                parent = vertices.Dequeue();
                if (destination_found && visited_actors[parent].level >= dest_Acotr.level)
                {


                    printInfo(visited_actors, adjList, dest_Acotr, ref source, ref dest);

                    if(!discovered.ContainsKey(source))
                    discovered.Add(source, visited_actors);

                    else
                    {
                        discovered[source] = visited_actors;
                    }

                    break;

                }

                foreach (var adj in adjList[parent].Keys)
                {
                    visited_Actor current_Actor = new visited_Actor();
                    if (!visited_actors.ContainsKey(adj))
                    {
                      
                        current_Actor = new visited_Actor(adj, adjList[adj][parent].Count + visited_actors[parent].strength, visited_actors[parent].level + 1, parent);
                        visited_actors.Add(adj, current_Actor);
                        vertices.Enqueue(adj);
                    }
                    else
                    {
                        if (visited_actors[adj].strength < (adjList[parent][adj].Count + visited_actors[parent].strength) && visited_actors[adj].level == visited_actors[parent].level + 1)
                        {
                            current_Actor = new visited_Actor(adj, adjList[adj][parent].Count + visited_actors[parent].strength,visited_actors[parent].level+1, parent);
                            visited_actors[adj] = current_Actor;
                        }
                    }
                    if (adj == dest && !destination_found)
                    {
                        dest_Acotr = current_Actor;
                        destination_found = true;
                    }


                }
            }



           
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

//

