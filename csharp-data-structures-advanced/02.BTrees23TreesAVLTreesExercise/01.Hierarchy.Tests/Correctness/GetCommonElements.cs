using System.Linq;

using NUnit.Framework;

namespace _01.Hierarchy.Tests.Correctness
{
    public class GetCommonElements : BaseTest
    {
        [Test]
        public void GetCommonElements_WithHierarchyWithoutCommonElements_ShouldReturnAnEmptyCollection()
        {
            Hierarchy<int> otherHierarchy = new Hierarchy<int>(1);

            int[] result = this.Hierarchy.GetCommonElements(otherHierarchy).ToArray();

            CollectionAssert.AreEquivalent(result, new int[0],"GetCommonElements returned an incorrect collection!");
        }

        [Test]
        public void GetCommonElements_WithHierarchyWithOneCommonElement_ShouldReturnACollectionOfCorrectElement()
        {
            Hierarchy<int> otherHierarchy = new Hierarchy<int>(1);
            otherHierarchy.Add(1,13);
            this.Hierarchy.Add(DefaultRootValue,13);

            int[] result = this.Hierarchy.GetCommonElements(otherHierarchy).ToArray();

            CollectionAssert.AreEquivalent(result, new [] {13}, "GetCommonElements returned an incorrect collection!");
        }

        [Test]
        public void GetCommonElements_WithHierarchyWithMultipleCommonElements_ShouldReturnACorrectCollection()
        {
            Hierarchy<int> otherHierarchy = new Hierarchy<int>(10);
            otherHierarchy.Add(10, -22);
            otherHierarchy.Add(-22, 56);
            otherHierarchy.Add(10, 108);
            otherHierarchy.Add(-22, 34);
            this.Hierarchy.Add(DefaultRootValue, 100);
            this.Hierarchy.Add(DefaultRootValue, -22);
            this.Hierarchy.Add(100, 34);
            this.Hierarchy.Add(100, 10);

            int[] result = this.Hierarchy.GetCommonElements(otherHierarchy).ToArray();

            CollectionAssert.AreEquivalent(result, new[] { -22,34,10 }, "GetCommonElements returned an incorrect collection!");
        }
    }
}
