namespace L04.SinglyLinkedList.Tests
{
    using System;
    using NUnit.Framework;
    using L04.SinglyLinkedList;
    using System.Linq;

    [TestFixture]
    public class SinglyLinkedListTests
    {
        private IAbstractLinkedList<int> list;

        [SetUp]
        public void InitializeLinkedList()
        {
            this.list = new SinglyLinkedList<int>();
        }

        [Test]
        public void AddFirst_SingleElement_ShouldIncreaseCount()
        {
            Assert.AreEqual(0, this.list.Count);
            this.list.AddFirst(10);
            Assert.AreEqual(1, this.list.Count);
        }

        [Test]
        public void AddFirst_WithMultipleElements_ShouldAddThemToTheFront()
        {
            var expected = new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };

            foreach (var num in expected)
            {
                this.list.AddFirst(num);
                Assert.AreEqual(num, this.list.GetFirst());
            }

            Assert.AreEqual(expected.Length, this.list.Count);
            CollectionAssert.AreEqual(expected.Reverse(), this.list);
        }

        [Test]
        public void AddLast_SingleElement_ShouldIncreaseCount()
        {
            Assert.AreEqual(0, this.list.Count);
            this.list.AddLast(10);
            Assert.AreEqual(1, this.list.Count);
        }

        [Test]
        public void AddLast_WithMultipleElements_ShouldAddThemToTheBack()
        {
            var expected = new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };

            foreach (var num in expected)
            {
                this.list.AddLast(num);
                Assert.AreEqual(num, this.list.GetLast());
            }

            Assert.AreEqual(expected.Length, this.list.Count);
            CollectionAssert.AreEqual(expected, this.list);
        }

        [Test]
        public void RemoveFirst_WithSingleElement_ShouldEmptyTheCollection()
        {
            Assert.AreEqual(0, this.list.Count);
            this.list.AddFirst(10);
            Assert.AreEqual(1, this.list.Count);
            this.list.RemoveFirst();
            Assert.AreEqual(0, this.list.Count);
        }

        [Test]
        public void RemoveFirst_WithMultipleElements_ShouldRemoveThemFromTheFront()
        {
            var expected = new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };

            foreach (var num in expected)
            {
                this.list.AddLast(num);
            }

            Assert.AreEqual(expected.Length, this.list.Count);

            this.list.RemoveFirst();
            this.list.RemoveFirst();
            this.list.RemoveFirst();

            CollectionAssert.AreEqual(expected.Skip(3), this.list);
        }

        [Test]
        public void RemoveFirst_OnEmptyList_ShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() => this.list.RemoveFirst());
        }

        [Test]
        public void RemoveLast_WithSingleElement_ShouldEmptyTheCollection()
        {
            Assert.AreEqual(0, this.list.Count);
            this.list.AddFirst(10);
            Assert.AreEqual(1, this.list.Count);
            this.list.RemoveLast();
            Assert.AreEqual(0, this.list.Count);
        }

        [Test]
        public void RemoveLast_WithMultipleElements_ShouldRemoveThemFromTheBack()
        {
            var expected = new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };

            foreach (var num in expected)
            {
                this.list.AddLast(num);
            }

            Assert.AreEqual(expected.Length, this.list.Count);

            this.list.RemoveLast();
            this.list.RemoveLast();
            this.list.RemoveLast();

            CollectionAssert.AreEqual(expected.Take(expected.Length - 3), this.list);
        }

        [Test]
        public void RemoveLast_OnEmptyList_ShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() => this.list.RemoveLast());
        }


        [Test]
        public void GetFirst_WithSingleElement_ShouldReturnIt()
        {
            this.list.AddFirst(10);
            Assert.AreEqual(10, this.list.GetFirst());
        }

        [Test]
        public void GetFirst_WithMultipleElements_ShouldReturnLeftmostElement()
        {
            var expected = new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };

            foreach (var num in expected)
            {
                this.list.AddLast(num);
            }

            Assert.AreEqual(expected[0], this.list.GetFirst());
            Assert.AreEqual(expected.Length, this.list.Count);

            Assert.AreEqual(expected[0], this.list.GetFirst());
        }

        [Test]
        public void GetFirst_OnEmptyList_ShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() => this.list.GetFirst());
        }

        [Test]
        public void GetLast_WithSingleElement_ShouldReturnIt()
        {
            this.list.AddFirst(10);
            Assert.AreEqual(10, this.list.GetLast());
        }

        [Test]
        public void GetLast_WithMultipleElements_ShouldReturnRightmostElement()
        {
            var expected = new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };

            foreach (var num in expected)
            {
                this.list.AddLast(num);
            }

            Assert.AreEqual(expected[expected.Length - 1], this.list.GetLast());
            Assert.AreEqual(expected.Length, this.list.Count);

            Assert.AreEqual(expected[expected.Length - 1], this.list.GetLast());
        }

        [Test]
        public void GetLast_OnEmptyList_ShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() => this.list.GetLast());
        }
    }
}
