namespace E08.CollectionHierarchy.Models
{
    public class MyList : CountableList
    {
        private readonly string[] arr;
        private int count;

        public MyList()
        {
            arr = new string[100];
            count = 0;
        }

        public override int Add(string item)
        {
            for (int i = count; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[0] = item;
            count++;
            return 0;
        }

        public override string Remove()
        {
            string @return = arr[0];
            for (int i = 0; i < count; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[count] = null;
            count--;

            return @return;
        }

        public override int Used => count;
    }
}
