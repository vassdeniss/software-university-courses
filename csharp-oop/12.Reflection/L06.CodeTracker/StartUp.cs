namespace AuthorProblem
{
    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        public static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Dennis")]
        public void BestMethod() { } 

        [Author("Bob")]
        private static void WontShow() { }
    }

}
