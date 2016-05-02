namespace _2.Topological_Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Graph<T>
    {
        private IList<T> nodes;
        private IList<Edge<T>> edges;

        public Graph()
        {
            this.nodes = new List<T>();
            this.edges = new List<Edge<T>>();
        }

        public IList<T> Nodes { get { return new List<T>(this.nodes); } }

        public IList<Edge<T>> Edges { get { return new List<Edge<T>>(this.edges); } }

        public void AddNode(T node)
        {
            this.nodes.Add(node);
        }

        public void AddEdge(Edge<T> edge)
        {
            if (!(this.nodes.Contains(edge.FirstNode)) ||
                !(this.nodes.Contains(edge.SecondNode)))
            {
                throw new ArgumentException("Graph does not contain nodes in given edge");
            }

            this.edges.Add(edge);
        }

        public void RemoveNode(T node)
        {
            this.nodes.Remove(node);
            var edgesToRemove = this.edges.Where(e => e.FirstNode.Equals(node)
                || e.SecondNode.Equals(node)).ToList();

            foreach (var edgeToRemove in edgesToRemove)
            {
                this.edges.Remove(edgeToRemove);
            }
        }

        public IList<T> GetChildren(T node)
        {
            return this.edges.Where(e => e.FirstNode.Equals(node))
                .Select(e => e.SecondNode).ToList();
        }

        public bool NodeIsChild(T node)
        {
            return this.edges.Any(e => e.SecondNode.Equals(node));
        }
    }
}
