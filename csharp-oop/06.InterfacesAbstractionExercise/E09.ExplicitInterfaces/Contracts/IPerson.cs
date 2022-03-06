namespace E09.ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        string Name { get; }

        string Age { get; }

        string GetName();
    }
}
