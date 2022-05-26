using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Small_world_phenomen
{
    struct Friend
    {
        public int Count;
        public string film;
        public Friend(int numFilms, string film)
        {
            this.Count = numFilms;
            this.film = film;
        }
    }

public class Graph
    {

         Dictionary<int, Dictionary<int, Friend>> adjcencyList; // key : ActorName ,Value :  Actors connected to (with filmsInfo) 
        public Dictionary<int, Dictionary<int, visited_Actor>> discovered;
        public Dictionary<int, string> NumberToActor;
        public Dictionary<string, int> actorToNumber;
        public HashSet<string> allActors;
        public int code;
        public Graph()
        {
            adjcencyList = new Dictionary<int, Dictionary<int, Friend>>();
            discovered = new Dictionary<int, Dictionary<int, visited_Actor>>();
            actorToNumber = new Dictionary<string, int>();
            NumberToActor = new Dictionary<int, String>();
            allActors = new HashSet<string>();
            code = 0;
        }
        public class visited_Actor
        {
            public int name;
            public int strength;
            public int level;
            public int parent;
            public bool continueFromHere;
            public visited_Actor(int name, int strength, int level, int parent)
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
        public void printInfo(Dictionary<int, visited_Actor> visited_actors, visited_Actor dest_Actor, ref int source, ref int dest, bool optmization)
        {

            Console.WriteLine("DOS = {0} ,strenght = {1} ", dest_Actor.level, dest_Actor.strength);
            visited_Actor currentActor = new visited_Actor();

            Stack<int> chainOfMovies = new Stack<int>();
            Stack<int> chainOfActors = new Stack<int>();
            currentActor = dest_Actor;
            chainOfMovies.Push(dest_Actor.name);
            chainOfActors.Push(dest_Actor.name);
            for (int i = 0; i < dest_Actor.level; i++)
            {
                currentActor = visited_actors[currentActor.parent];
                chainOfMovies.Push(currentActor.name);
                chainOfActors.Push(currentActor.name);
            }
            Console.Write("chain of Movies : ");
            while (chainOfMovies.Count > 1)
            {
                int actor1 = chainOfMovies.Pop();
                int actor2 = chainOfMovies.Peek();   
                Console.Write(this.adjcencyList[actor1][actor2].film);
                Console.Write("=>");
            }
            Console.WriteLine();
            Console.Write("CHAIN OF ACTORS : ");
            Console.Write("=>");
            while (chainOfActors.Count > 0)
            {
                int actor = chainOfActors.Pop();
                Console.Write(NumberToActor[actor]);
                Console.Write("=>");
            }

            Console.WriteLine();
            if (optmization)
            {
                /*
                 Adding  the last point to start from in the parent of the source of the  discovered way as it's not used in searching .

                Means : starting from the first grey Node in the discovered way.
                 
                 */

                if (!discovered.ContainsKey(source))
                {
                    discovered.Add(source, visited_actors);


                    foreach (var a in discovered[source])
                    {
                        if (a.Value.continueFromHere == false)
                        {

                            discovered[source][source].parent = a.Value.name;
                            break;
                        }
                    }
                }
                else
                {
                    discovered[source] = visited_actors;

                    foreach (var a in discovered[source])
                    {
                        if (a.Value.continueFromHere == false)
                        {
                            discovered[source][source].parent = a.Value.name;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Breadth First Search Algorithm with modifications to start from a specific point and to get info about corresponding actor in the actor pair like "Ahmed , Wael"  finding the realtion strength and degree of seperation.
        /// </summary>
        /// <param name="source">The source Actor to start searching from.</param>
        /// <param name="dest">The dest actor to reach .</param>
        /// <param name="optmization">if set to <c>true</c> [optmization] the BFS stops when it reache destination.</param>
        /// <param name="bonus">if set to <c>true</c> [bonus] calculate the seperation between all actors in the graph.</param>
        public void BFS(int source, int dest, bool optmization = false, bool bonus = false)
        {
            Dictionary<int, visited_Actor> visited_actors;
            visited_Actor source_Actor;
            visited_Actor dest_Actor = new visited_Actor();

            Dictionary<int, int> bonusStore = new Dictionary<int, int>();

            int originalSource = source;

            if (discovered.ContainsKey(source) && optmization == true && bonus == false)
            {
                if (discovered[source].ContainsKey(dest))
                {
                    printInfo(discovered[originalSource], discovered[originalSource][dest], ref originalSource, ref dest, optmization);
                    visited_actors = new Dictionary<int, visited_Actor>();
                    return;
                }
                else
                {
                    visited_actors = discovered[source];
                    source = discovered[source][source].parent;

                    source_Actor = discovered[originalSource][source];
                }
            }
            else
            {
                visited_actors = new Dictionary<int, visited_Actor>();
                source_Actor = new visited_Actor(source, 0, 0, -1);
                visited_actors.Add(source, source_Actor);
            }

            bool destination_found = false;
            Queue<int> vertices = new Queue<int>();



            vertices.Enqueue(source);
            int parent;
            while (vertices.Count != 0)
            {
                parent = vertices.Dequeue();
                if (destination_found && visited_actors[parent].level >= dest_Actor.level)
                {
                    printInfo(visited_actors, dest_Actor, ref originalSource, ref dest, optmization);
                    break;

                }

                
                foreach (var adj in adjcencyList[parent].Keys) 
                {
                    visited_Actor current_Actor = new visited_Actor();
                    if (!visited_actors.ContainsKey(adj))
                    {
                        current_Actor = new visited_Actor(adj, adjcencyList[adj][parent].Count + visited_actors[parent].strength, visited_actors[parent].level + 1, parent);
                        visited_actors.Add(adj, current_Actor);
                        vertices.Enqueue(adj);
                    }
                    else
                    {
                        /*
                         if you found another path leads to a node with the same speration but higer strength 
                        Then you update that Node to that path.
                         */
                        if (visited_actors[adj].strength < (adjcencyList[parent][adj].Count + visited_actors[parent].strength) && visited_actors[adj].level == visited_actors[parent].level + 1)
                        {
                            current_Actor = new visited_Actor(adj, adjcencyList[adj][parent].Count + visited_actors[parent].strength, visited_actors[parent].level + 1, parent);
                            visited_actors[adj] = current_Actor;
                        }
                    }
                    if (adj == dest && !destination_found && optmization == true )
                    {
                        dest_Actor = current_Actor;
                        destination_found = true;
                    }

                    /*
                     if you found destination from another node with the same seperation but higher strength 
                    Then we update it.
                     */
                    if (adj == dest && destination_found && (visited_actors[parent].level + 1) <= dest_Actor.level)
                    {
                        if (visited_actors[parent].strength + adjcencyList[adj][parent].Count > dest_Actor.strength)
                        {
                            dest_Actor.strength = visited_actors[parent].strength + adjcencyList[adj][parent].Count;
                            dest_Actor.name = adj;
                            dest_Actor.parent = parent;
                        }
                    }
                }

                visited_actors[parent].continueFromHere = true;
            }
            if (optmization == false && bonus == false)
            {
                dest_Actor = visited_actors[dest];
                printInfo(visited_actors, dest_Actor, ref originalSource, ref dest, optmization);
            }
            if (bonus == true)
            {
                foreach (var actor in visited_actors)
                {
                    if (bonusStore.ContainsKey(actor.Value.level))
                    {
                        bonusStore[(actor.Value.level)]++;
                    }
                    else
                        bonusStore.Add(actor.Value.level, 1);
                }
                foreach (var bon in bonusStore)
                {
                    Console.WriteLine(bon.Key + " : " + bon.Value);
                }
            }
        }

        /// <summary>Constracts the graph to make the adjacency list between<font color="#548dd4"> every actors and his friends</font>.</summary>
        /// <param name="moviesData">The movies data (Name , actorList).</param>
        public void constract_graph(Dictionary<string, List<string>> moviesData)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var movie in moviesData)
            {
                foreach (var actor in movie.Value)
                {
                    allActors.Add(actor);
                }
            }
            foreach (var actor in allActors)
            {
                actorToNumber.Add(actor, code);
                NumberToActor.Add(code, actor);
                code++;
            }
            foreach (var movie in moviesData)
            {
               
                foreach (var actor in movie.Value)
                {
                    foreach (var friend in movie.Value)
                    {
                        int actor1 = actorToNumber[actor];
                        int actor2 = actorToNumber[friend];

                        if (actor1 != actor2)
                        {
                            if (!adjcencyList.ContainsKey(actor1))
                            {

                                Friend newFriendInfo = new Friend(1, movie.Key);

                                Dictionary<int, Friend> actorFriends = new Dictionary<int, Friend>();

                                actorFriends.Add(actor2, newFriendInfo);

                                adjcencyList.Add(actor1, actorFriends);
                            }
                            else
                            {
                                if (!adjcencyList[actor1].ContainsKey(actor2))
                                {

                                    Friend newFriendInfo = new Friend(1, movie.Key);

                                    adjcencyList[actor1].Add(actor2, newFriendInfo);
                                }
                                else
                                {
                                    Friend existingFriendInfo = adjcencyList[actor1][actor2];
                                    existingFriendInfo.Count++;
                                    adjcencyList[actor1][actor2] = existingFriendInfo;
                                }
                            }
                        }
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine("constract = " + stopwatch.Elapsed.TotalSeconds);
        }
    }
}