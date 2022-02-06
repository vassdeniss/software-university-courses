namespace E04.GenericSwapMethodInteger
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
