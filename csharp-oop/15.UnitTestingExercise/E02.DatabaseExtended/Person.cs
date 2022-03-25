namespace ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string userName;

        public Person(long id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public string UserName
        {
            get => userName;
            private set { userName = value; }
        }

        public long Id
        {
            get => id;
            private set { id = value; }
        }
    }
}
