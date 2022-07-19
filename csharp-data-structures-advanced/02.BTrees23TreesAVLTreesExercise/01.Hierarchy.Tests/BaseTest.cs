using NUnit.Framework;

namespace _01.Hierarchy.Tests
{
    public class BaseTest
    {
        public IHierarchy<int> Hierarchy { get; private set; }

        public const int DefaultRootValue = 5;

        [SetUp]
        public void Initialize()
        {
            this.Hierarchy = new Hierarchy<int>(DefaultRootValue);
        }
    }
}
