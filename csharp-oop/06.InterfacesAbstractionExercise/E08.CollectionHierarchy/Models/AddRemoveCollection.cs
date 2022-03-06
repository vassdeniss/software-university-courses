namespace E08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : RemoveableList
    {
        private readonly string[] arr;
        private int count;

        public AddRemoveCollection()
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
            int idx = 0;
            while (idx != count - 1) idx++;
            string @return = arr[idx];
            arr[idx] = null;
            count--;
            return @return;
        }
    }
}
