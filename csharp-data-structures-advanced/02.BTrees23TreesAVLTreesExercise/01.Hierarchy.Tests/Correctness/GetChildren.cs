using System;
using System.Linq;

using NUnit.Framework;

namespace _01.Hierarchy.Tests.Correctness
{
    public class GetChildren : BaseTest
    {
        [Test]
        public void GetChildren_WithNonExistentElement_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.Hierarchy.GetParent(-17);
            });
        }

        [Test]
        public void GetChildren_WithAnElementWithNoChildren_ShouldReturnEmptyCollection()
        {
            this.Hierarchy.Add(DefaultRootValue, 13);
            this.Hierarchy.Add(DefaultRootValue, 14);
            this.Hierarchy.Add(13, 17);
            this.Hierarchy.Add(13, -666);

            int[] result = this.Hierarchy.GetChildren(-666).ToArray();

            CollectionAssert.AreEqual(result, new int[0], "Incorrect amount of children returned!");
        }

        [Test]
        public void GetChildren_WithAnElementWithOneChild_ShouldReturnACollectionWithOneElement()
        {
            this.Hierarchy.Add(DefaultRootValue, 55);
            this.Hierarchy.Add(DefaultRootValue, 10);
            this.Hierarchy.Add(55, 17);
            this.Hierarchy.Add(55, 18);
            this.Hierarchy.Add(10, -666);

            int[] result = this.Hierarchy.GetChildren(10).ToArray();

            CollectionAssert.AreEqual(result, new[] { -666 }, "Incorrect amount of children returned!");
        }

        [Test]
        public void GetChildren_WithAnElementWithMultipleChildren_ShouldReturnACorrectCollection()
        {
            this.Hierarchy.Add(DefaultRootValue, 25);
            this.Hierarchy.Add(DefaultRootValue, 110);
            this.Hierarchy.Add(25, -10);
            this.Hierarchy.Add(110, 22);
            this.Hierarchy.Add(110, 333);
            this.Hierarchy.Add(110, 15);
            this.Hierarchy.Add(110, 99);
            this.Hierarchy.Add(99, 1);

            int[] result = this.Hierarchy.GetChildren(110).ToArray();

            CollectionAssert.AreEqual(result, new[] { 22, 333, 15, 99 }, "Incorrect amount of children returned!");
        }
    }
}
