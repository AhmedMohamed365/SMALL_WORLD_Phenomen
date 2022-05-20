using System;
using System.Collections;
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

    class LinkedList : IEnumerable
    {
        public Node First, Last, joint;
        public int count;
        //constructor to create an empty LinkedList
        public LinkedList()
        {
            First = null;
            Last = null;
            joint = Last;
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
            if (node.value == copiedList.First.value)
            {
                First = copiedList.First.Next;
                Last = copiedList.Last;


                joint = Last;

            }


            else if (node.value == copiedList.Last.value)
            {
                First = copiedList.First;

                joint = copiedList.Last;

                Last = copiedList.Last.Previous;



            }


            //if it is somewehere in the middle 
            else
            {
                Node copiedNode = new Node();

                copiedNode.Previous = node.Previous;
                copiedNode.value = node.value;

                copiedNode.Next = node.Next;
                joint = copiedNode;



                //Seperate the list into 2 lists with one different node.
                First = copiedList.First;



                Last = copiedList.Last;






            }







        }


        public void printList()
        {
            Node node = this.First;

            for (; node.Previous != this.joint.Previous; node = node.Next)
            {
                Console.Write(node.value + " ");

            }


            if (this.joint != this.Last)
                node = this.joint.Next;


            for (; node != null; node = node.Next)
            {
                Console.Write(node.value + " ");

            }


        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}