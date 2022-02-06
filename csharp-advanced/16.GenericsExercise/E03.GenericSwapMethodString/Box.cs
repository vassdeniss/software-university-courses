namespace E03.GenericSwapMethodString
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"System.String: {item}";
        }
    }
}
