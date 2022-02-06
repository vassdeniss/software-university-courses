namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            EqualityScale<string> equalityScale = new EqualityScale<string>("left", "right");
            equalityScale.AreEqual();
        }
    }
}
