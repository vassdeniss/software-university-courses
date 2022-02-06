namespace E02.GenericBoxInteger
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
            return $"System.Int32: {item}";
        }
    }
}
