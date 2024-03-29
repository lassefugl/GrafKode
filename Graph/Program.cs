﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of our graph
            MyGraph<string> myGraph = new MyGraph<string>();

            //Create the graph
            CreateGraph(ref myGraph);

            Queue q = new Queue();

            Node<String> rootNode = myGraph.NodeSet[2]; //Idaho
            Node<String> targetNode = myGraph.NodeSet[6]; //South Dakota
            
            q.Enqueue(rootNode);
            rootNode.Visited = true;
            while (q.Count != 0)
            {
                Node<String> element = (Node<String>) q.Dequeue();
                foreach (Edge<String> edge in element.MyEdges)
                {   
                    if (edge.To.Equals(targetNode))
                    {
                        edge.To.Parent = edge.From;
                        q.Clear();
                        Node<String> returning = edge.To;
                        Stack printStack = new Stack();
                        while (!returning.Equals(rootNode)){
                            printStack.Push(returning.Parent.MyEdges.Find(x => x.To.Equals(returning)));
                            returning = returning.Parent;
                        }
                        while (printStack.Count > 0) {
                            Console.WriteLine(printStack.Pop());
                        }
                        break;
                    }

                    if (!edge.To.Visited)
                    {
                        q.Enqueue(edge.To);
                        edge.To.Visited = true;
                        edge.To.Parent = edge.From;
                    }
                }
            }
        }

        private static void CreateGraph(ref MyGraph<string> myGraph)
        {
            //Adds nodes to our graph
            Node<String> n1 = myGraph.AddNode("OREGON");
            Node<String> n2 = myGraph.AddNode("CALIFORNIA");
            Node<String> n3 = myGraph.AddNode("IDAHO");
            Node<String> n4 = myGraph.AddNode("UTAH");
            Node<String> n5 = myGraph.AddNode("NEW MEXICO");
            Node<String> n6 = myGraph.AddNode("KANSAS");
            Node<String> n7 = myGraph.AddNode("SOUTH DAKOTA");
            Node<String> n8 = myGraph.AddNode("NORTH DAKOTA");
            Node<String> n9 = myGraph.AddNode("IOWA");
            Node<String> n10 = myGraph.AddNode("TENNESSEE");
            Node<String> n11 = myGraph.AddNode("NEW YORK");
            Node<String> n12 = myGraph.AddNode("FLORIDA");
            Node<String> n13 = myGraph.AddNode("TEXAS");

            //Creates edges between the graphs nodes
            myGraph.AddEdge("OREGON", "CALIFORNIA");
            myGraph.AddEdge("CALIFORNIA", "UTAH");
            myGraph.AddEdge("UTAH", "IDAHO");
            myGraph.AddEdge("UTAH", "NEW MEXICO");
            myGraph.AddEdge("NEW MEXICO", "KANSAS");
            myGraph.AddEdge("NEW MEXICO", "TEXAS");
            myGraph.AddEdge("TEXAS", "TENNESSEE");
            myGraph.AddEdge("TEXAS", "FLORIDA");
            myGraph.AddEdge("TEXAS", "KANSAS");
            myGraph.AddEdge("KANSAS", "SOUTH DAKOTA");
            myGraph.AddEdge("SOUTH DAKOTA", "NORTH DAKOTA");
            myGraph.AddEdge("NORTH DAKOTA", "IOWA");
            myGraph.AddEdge("IOWA", "TENNESSEE");
            myGraph.AddEdge("TENNESSEE", "FLORIDA");
            myGraph.AddEdge("TENNESSEE", "NEW YORK");
        }
    }
}
