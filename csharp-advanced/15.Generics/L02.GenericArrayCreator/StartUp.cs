namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(5, 33);
        }
    }
}
