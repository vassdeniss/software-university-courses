namespace E07.Tuple
{
    public class CustomTuple<TFirst, TSecond>
    {
        private TFirst first;
        private TSecond second;

        public CustomTuple(TFirst first, TSecond second)
        {
            this.first = first;
            this.second = second;
        }

        public override string ToString()
        {
            return $"{first} -> {second}";
        }
    }
}
