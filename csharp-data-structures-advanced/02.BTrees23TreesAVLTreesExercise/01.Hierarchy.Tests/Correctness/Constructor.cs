using NUnit.Framework;

namespace _01.Hierarchy.Tests.Correctness
{
    public class Constructor
    {
        [Test]
        public void Constructor_NewHierarchyShouldHaveExactly1Element()
        {
            Hierarchy<int> hierarchy = new Hierarchy<int>(5);
            Assert.AreEqual(1, hierarchy.Count);
        }

        [Test]
        public void Constructor_NewHierarchyShouldHaveCorrectElement()
        {
            Hierarchy<int> hierarchy = new Hierarchy<int>(5);
            Assert.IsTrue(hierarchy.Contains(5));
        }

        [Test]
        public void Hierarchy_ShouldBeGeneric()
        {
            Hierarchy<string> hierarchy = new Hierarchy<string>("test");
            Assert.IsTrue(hierarchy.Contains("test"));
        }
    }
}
