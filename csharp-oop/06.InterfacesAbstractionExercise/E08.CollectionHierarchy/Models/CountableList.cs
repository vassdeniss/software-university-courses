namespace E08.CollectionHierarchy.Models
{
    public abstract class CountableList : RemoveableList
    {
        public abstract int Used { get; }
    }
}
