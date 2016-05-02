using System;
using System.Collections.Generic;
namespace _1.DFS___BFS
{
    public class Program
    {
        static void Main(string[] args)
        {
            var graph = BuildGraph();

            var visited = new HashSet<Node>();

            Console.WriteLine("Printing graph via DFS traversal: ");

            GraphDFS(graph, visited, graph.Nodes[0]);

            visited.Clear();

            Console.WriteLine("Printing graph via BFS traversal: ");

            GraphBFS(graph, visited, graph.Nodes[0]);
        }

        static void GraphDFS(Graph<Node> graph, HashSet<Node> visited, Node currentNode)
        {
            foreach (var node in graph.Nodes)
            {
                GraphDFSFunc(graph, visited, currentNode);
            }
        }

        static void GraphDFSFunc(Graph<Node> graph, HashSet<Node> visited, Node currentNode)
        {
            if (!(visited.Contains(currentNode)))
            {
                visited.Add(currentNode);

                var children = graph.GetChildren(currentNode);

                foreach (var child in children)
                {
                    GraphDFSFunc(graph, visited, child);
                }

                Console.WriteLine(currentNode.Value);
            }
        }

        static void GraphBFS(Graph<Node> graph, HashSet<Node> visited, Node currentNode)
        {
            var queue = new Queue<Node>();

            queue.Enqueue(currentNode);
            visited.Add(currentNode);

            GraphBFSFunc(graph, visited, queue, currentNode);
        }

        static void GraphBFSFunc(Graph<Node> graph, HashSet<Node> visited, Queue<Node> queue, Node currentNode)
        {
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                Console.WriteLine(node.Value);

                var children = graph.GetChildren(node);

                foreach (var child in children)
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }
        }

        static Graph<Node> BuildGraph()
        {
            var graph = new Graph<Node>();

            var nodes = new List<Node>() {
                new Node(1), new Node(19), new Node(21), new Node(14),
                new Node(7), new Node(12), new Node(31), new Node(23), new Node(6) };

            foreach (var node in nodes)
            {
                graph.AddNode(node);
            }

            graph.AddEdge(new Edge<Node>(nodes[0], nodes[1]));
            graph.AddEdge(new Edge<Node>(nodes[0], nodes[2]));
            graph.AddEdge(new Edge<Node>(nodes[0], nodes[3]));

            graph.AddEdge(new Edge<Node>(nodes[1], nodes[4]));
            graph.AddEdge(new Edge<Node>(nodes[1], nodes[5]));
            graph.AddEdge(new Edge<Node>(nodes[1], nodes[6]));
            graph.AddEdge(new Edge<Node>(nodes[1], nodes[2]));

            graph.AddEdge(new Edge<Node>(nodes[2], nodes[3]));

            graph.AddEdge(new Edge<Node>(nodes[3], nodes[7]));
            graph.AddEdge(new Edge<Node>(nodes[3], nodes[8]));

            graph.AddEdge(new Edge<Node>(nodes[4], nodes[0]));

            graph.AddEdge(new Edge<Node>(nodes[6], nodes[2]));

            graph.AddEdge(new Edge<Node>(nodes[7], nodes[2]));

            return graph;
        }
    }
}
