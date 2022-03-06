namespace E08.CollectionHierarchy.Models
{
    public class AddCollection : AddableList
    {
        private readonly string[] arr;
        private int count;

        public AddCollection()
        {
            arr = new string[100];
            count = 0;
        }

        public override int Add(string item)
        {
            arr[count] = item;
            return count++;
        }
    }
}
