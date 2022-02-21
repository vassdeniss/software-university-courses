namespace E01.FasterQueue.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using E01.FasterQueue;

    [TestFixture]
    public class QueueTests
    {
        private readonly Random _random = new Random();

        [Test]
        public void EnqueueShouldAddElementAtTheTop()
        {
            var queue = GetQueue();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                queue.Enqueue(randomValue);
                Assert.AreEqual(i + 1, queue.Count);
            }

            var index = 0;
            foreach (var queueElement in queue)
                Assert.AreEqual(array[index++], queueElement);
        }

        [Test]
        public void DequeueShouldRemoveTheLastElement()
        {
            var queue = GetQueue();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                queue.Enqueue(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], queue.Dequeue());
                Assert.AreEqual(array.Length - (i + 1), queue.Count);
            }
        }

        [Test]
        public void DequeueShouldThrowExceptionIfTheStackContainsNoElements()
        {
            var queue = GetQueue();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void PeekShouldReturnTheLastElementWithoutRemovingIt()
        {
            var queue = GetQueue();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                queue.Enqueue(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], queue.Peek());
                Assert.AreEqual(array.Length - i, queue.Count);
                queue.Dequeue();
            }
        }

        [Test]
        public void PeekShouldThrowExceptionIfTheStackContainsNoElements()
        {
            var queue = GetQueue();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void ContainsShouldWorkAsExpected()
        {
            var queue = GetQueue();
            var count = this._random.Next(10, 30);

            for (var i = 0; i < count; i++)
                queue.Enqueue(i);

            for (var i = 0; i < count; i++)
                Assert.IsTrue(queue.Contains(i));

            Assert.IsFalse(queue.Contains(count));
        }

        [Test]
        public void QueueContainsTwoPrivateNodes()
        {
            var queueType = typeof(FastQueue<sbyte>);
            var allFields = queueType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.FieldType.Name.Contains("Node"))
                .ToList();
            Assert.AreEqual(2, allFields.Count);
        }

        private static IAbstractQueue<int> GetQueue() => new FastQueue<int>();
    }
}
