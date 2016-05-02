namespace _1.DFS___BFS
{
    public class Edge<T>
    {
        public Edge(T firstNode, T secondNode)
        {
            this.FirstNode = firstNode;
            this.SecondNode = secondNode;
        }

        public T FirstNode { get; set; }

        public T SecondNode { get; set; }
    }
}
