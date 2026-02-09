using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _76_Get_Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node node1 = new Node("1");
            Node node2 = new Node("2");
            Node node3 = new Node("3");
            Node node4 = new Node("4");
            Node node5 = new Node("5");
            Node node6 = new Node("6");
            Node node7 = new Node("7");
            Node node8 = new Node("8");
            Node node9 = new Node("9");
            Node node10= new Node("10");
            Node node11 = new Node("11");
            Node node12 = new Node("12");

            nodeA.next = nodeB;
            nodeB.next = nodeC;
            nodeC.next = node1;
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;
            node8.next = node9;
            node9.next = node10;
            node10.next = node11;
            node11.next = node12;
            node12.next = node1;

            var currentNode = nodeA;
            List<Node> previousNodes = new List<Node>();
            Node foundLoop = null;
            while (currentNode.next != null )
            {
                Console.WriteLine($"Checking the node with content {currentNode.content}");

                foreach (var node in previousNodes)
                {
                    if (node == currentNode)
                    {
                        foundLoop = currentNode;
                        break;
                    }
                    //found the loop 
                }
                if (foundLoop != null) break;

                previousNodes.Add(currentNode);
                currentNode = currentNode.next;
            }

            currentNode = foundLoop;
            int cntLoop = 0;
            while (true)
            {
                cntLoop ++;
                if (currentNode.next == foundLoop) break;
                else currentNode = currentNode.next;
            }

            Console.WriteLine(cntLoop);
            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    class Node
    {
        public Node next {get; set;}
        public string content { get; set; }

        public Node(string cont)
        {
            content = cont;
        }
    }
}
