namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] arr = new T[length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = item;
            }

            return arr;
        }
    }
}
