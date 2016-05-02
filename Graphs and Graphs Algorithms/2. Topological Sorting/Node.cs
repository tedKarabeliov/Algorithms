namespace _2.Topological_Sorting
{
    public class Node
    {
        public Node(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
