namespace _2.Topological_Sorting
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var graph = BuildGraph();

            var sorted = new List<Node>();
            var nodesWithoutIncomingEdges = new Queue<Node>();

            foreach (var node in graph.Nodes)
            {
                if (!(graph.NodeIsChild(node)))
                {
                    nodesWithoutIncomingEdges.Enqueue(node);
                }
            }

            while (nodesWithoutIncomingEdges.Count != 0)
            {
                var currentNode = nodesWithoutIncomingEdges.Dequeue();
                var childrenOfNode = graph.GetChildren(currentNode);

                sorted.Add(currentNode);
                graph.RemoveNode(currentNode);

                foreach (var child in childrenOfNode)
                {
                    if (!(graph.NodeIsChild(child)))
                    {
                        nodesWithoutIncomingEdges.Enqueue(child);
                    }
                }
            }

            if (graph.Nodes.Count == 0)
            {
                Console.WriteLine("Topologically sorted: ");

                foreach (var node in sorted)
                {
                    Console.Write(node + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Error: Graph has cycles");
            }
        }

        static Graph<Node> BuildGraph()
        {
            var graph = new Graph<Node>();

            var nodes = new List<Node>()
            {
                new Node("A"),
                new Node("B"),
                new Node("C"),
                new Node("D"),
                new Node("E"),
                new Node("F")
            };

            foreach (var node in nodes)
            {
                graph.AddNode(node);
            }

            graph.AddEdge(new Edge<Node>(nodes[0], nodes[1]));
            graph.AddEdge(new Edge<Node>(nodes[0], nodes[2]));


            graph.AddEdge(new Edge<Node>(nodes[1], nodes[3]));
            graph.AddEdge(new Edge<Node>(nodes[1], nodes[4]));

            graph.AddEdge(new Edge<Node>(nodes[3], nodes[2]));
            graph.AddEdge(new Edge<Node>(nodes[3], nodes[5]));

            graph.AddEdge(new Edge<Node>(nodes[4], nodes[3]));

            return graph;
        }
    }
}
