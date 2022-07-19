using System;
using System.Linq;

using NUnit.Framework;

namespace _01.Hierarchy.Tests.Correctness
{
    public class Add : BaseTest
    {
        [Test]
        public void Add_WithDuplicateElement_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.Hierarchy.Add(DefaultRootValue, 2);
                this.Hierarchy.Add(DefaultRootValue, 3);
                this.Hierarchy.Add(3, 2);
            });
        }

        [Test]
        public void Add_ToNonExistingElement_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.Hierarchy.Add(DefaultRootValue + 1, 2);
            });
        }

        [Test]
        public void Add_WithSingleElement_ShouldIncrementCountByOne()
        {
            this.Hierarchy.Add(DefaultRootValue, 2);
            Assert.AreEqual(2, this.Hierarchy.Count, "Count did not increase correctly!");
        }

        [Test]
        public void Add_WithMultipleElements_ShouldIncrementCountCorrectly()
        {
            int[] elementsToAdd = { 3, 2, 7 };

            this.Hierarchy.Add(DefaultRootValue, elementsToAdd[0]);
            this.Hierarchy.Add(DefaultRootValue, elementsToAdd[1]);
            this.Hierarchy.Add(elementsToAdd[1], elementsToAdd[2]);

            Assert.AreEqual(1 + elementsToAdd.Length, this.Hierarchy.Count, "Count did not increase correctly!");
        }

        [Test]
        public void Add_WithSingleElement_ShouldAddCorrectElement()
        {
            Assert.IsFalse(this.Hierarchy.Contains(2));

            this.Hierarchy.Add(DefaultRootValue, 2);

            Assert.IsTrue(this.Hierarchy.Contains(2), "Element wasn't added!");
        }

        [Test]
        public void Add_WithSingleElement_ShouldCorrectlySetElementsParent()
        {
            this.Hierarchy.Add(DefaultRootValue, 111);
            this.Hierarchy.Add(111, 222);

            Assert.AreEqual(111, this.Hierarchy.GetParent(222), "Element's parent wasn't correct!");
        }

        [Test]
        public void Add_WithMultipleElements_ShouldAddElementAtCorrectPlace()
        {
            this.Hierarchy.Add(DefaultRootValue, 6);
            this.Hierarchy.Add(DefaultRootValue, 2);
            this.Hierarchy.Add(6, 13);
            this.Hierarchy.Add(2, 7);
            this.Hierarchy.Add(7, 22);

            this.Hierarchy.Add(7, 25);

            Assert.AreEqual(25, this.Hierarchy.GetChildren(7).ToList()[1], "Element wasn't added at correct place!");
        }

        [Test]
        public void Add_WithAddAfterRemoving_ShouldAddCorrectly()
        {
            this.Hierarchy.Add(DefaultRootValue, 2);
            this.Hierarchy.Remove(2);
            Assert.AreEqual(1, this.Hierarchy.Count);

            this.Hierarchy.Add(DefaultRootValue, 2);

            Assert.AreEqual(2, this.Hierarchy.Count);
        }
    }
}
