namespace L03.Queue.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using L03.Queue;

    [TestFixture]
    public class QueueTests
    {
        private IAbstractQueue<int> queue;
        private System.Collections.Generic.Queue<int> builtInQueue;

        [SetUp]
        public void InitializeQueue()
        {
            this.queue = new L03.Queue.Queue<int>();
            this.builtInQueue = new System.Collections.Generic.Queue<int>();
        }

        private static IEnumerable<int[]> RandomCollections()
        {
            var collections = new List<int[]>
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                new int[] { 3, 8, 1, 6, 5, 7, 2, 9, 4 },
                new int[] { 3, 8, 1 },
                new int[] { 3 },
                new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 }
            };

            return collections;
        }

        [Test]
        public void Enqueue_SingleElement_ShouldIncreaseCount()
        {
            this.queue.Enqueue(1);
            Assert.AreEqual(1, this.queue.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Enqueue_MultipleElements_ShouldOrderElementsCorrectly(int[] expected)
        {

            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            CollectionAssert.AreEqual(this.builtInQueue, this.queue);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Enqueue_MultipleElements_ShouldIncreaseCount(int[] expected)
        {
            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            Assert.AreEqual(this.builtInQueue.Count, this.queue.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Dequeue_WithMultipleElements_ShouldRemoveTheFirstElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            do
            {
                Assert.AreEqual(this.builtInQueue.Dequeue(), this.queue.Dequeue());
            }
            while (this.queue.Count > 0);
        }

        [Test]
        public void Dequeue_WithSingeElement_ShouldDecreaseCount()
        {
            Assert.AreEqual(0, this.queue.Count);
            this.queue.Enqueue(10);

            Assert.AreEqual(1, this.queue.Count);

            this.queue.Dequeue();
            Assert.AreEqual(0, this.queue.Count);
        }

        [Test]
        public void Dequeue_OnEmptyQueue_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.queue.Dequeue());
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Peek_WithMultipleElements_ShouldNotRemoveTheTopElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            Assert.AreEqual(builtInQueue.Peek(), this.queue.Peek());
            Assert.AreEqual(builtInQueue.Peek(), this.queue.Peek());
        }

        [Test]
        public void Peek_WithSingeElement_ShouldNotDecreaseCount()
        {
            Assert.AreEqual(0, this.queue.Count);
            this.queue.Enqueue(10);

            Assert.AreEqual(1, this.queue.Count);

            this.queue.Peek();
            Assert.AreEqual(1, this.queue.Count);
        }

        [Test]
        public void Peek_OnEmptyStack_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.queue.Peek());
        }

        [Test]
        public void Contains_OnCollectionWithSingleElement_ShouldReturnTrue()
        {
            var value = 10;
            this.queue.Enqueue(value);

            Assert.AreEqual(true, this.queue.Contains(value));
        }

        [Test]
        public void Contains_WithExistingElement_ShouldReturnTrue()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.queue.Enqueue(num);
            }

            Assert.AreEqual(true, this.queue.Contains(5));
        }

        [Test]
        public void Contains_OnEmptyCollection_ShouldReturnFalse()
        {
            Assert.AreEqual(false, this.queue.Contains(56));
        }

        [Test]
        public void Contains_WithNonExistingElement_ShouldReturnFalse()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.queue.Enqueue(num);
            }

            Assert.AreEqual(false, this.queue.Contains(536));
        }

    }
}
