using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_world_phenomen
{
    class Node
    {
        public string value;
        public Node Next;
        public Node Previous;
    };

    class LinkedList
    {
        public Node First, Last , joint;
        public int count;
        //constructor to create an empty LinkedList
        public LinkedList()
        {
            First = null;
            Last = null;
            
        }


        
        public void AddLast(string value)
        {
            Node node = new Node();
            node.value = value;

            if (count == 0)
            {
                
               First = Last = node;

               
            }
           
            else
            {

                Last.Next = node;

                node.Previous = Last;
                node.Next = null;
               
                Last = node;

              
            }
        

           
            count++;

           
           

        }
        public LinkedList(LinkedList copiedList, Node node)
        {
            //Simply trim  from first or last of the list 
                if (node == copiedList.First)
                {
                    First = copiedList.First.Next;
                    Last = copiedList.Last;
                }


                else if (node == copiedList.Last)
                {
                    First = copiedList.First;

                    Last = copiedList.Last.Previous;
                }

        
            //if it is somewehere in the middle 
            else  
            {
                Node copiedNode = new Node();

                copiedNode = node.Previous;
                copiedNode.Next = node.Next;


               

                //Seperate the list into 2 lists with one different node 
                First = copiedList.First;

                joint = copiedNode;
                Last = copiedList.Last;
                
              
                

                
            }


            
         



           
            
        }


    };

   
}
