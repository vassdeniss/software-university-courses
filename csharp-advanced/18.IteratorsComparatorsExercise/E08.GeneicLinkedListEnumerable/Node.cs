namespace E08.GeneicLinkedListEnumerable
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
        public Node<T> PreviousNode { get; set; }
    }
}
