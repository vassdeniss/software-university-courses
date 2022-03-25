using E05.CircularQueue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.Collections.Tests
{
    public class QueueTests
    {
        private CircularQueue<int> queue;

        [SetUp]
        public void SetUp()
        {
            queue = new CircularQueue<int>();
        }

        [Test]
        public void Test_Constructor_Default_Capacity_Should_Initialize_Correctly()
        {
            Assert.That(queue.Count == 0, "Queues count should be zero.");
            Assert.That(queue.Capacity > 0, "Queues capacity has to be higher or equal to zero.");
            Assert.That(queue.StartIndex == 0, "Start index has to is not zero.");
            Assert.That(queue.EndIndex == 0, "Zero index has to is not zero.");
        }

        [Test]
        public void Test_Enqueue_Should_Add_Elements_Correctly()
        {
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.AreEqual(3, queue.Count, "Queue count mismatches with actual count.");
            Assert.True(queue.Capacity >= queue.Count, "Count overshot the queues capacity.");
        }

        [Test]
        public void Test_Enqueue_Overflow_Should_Grow_Correctly()
        {
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60);
            queue.Enqueue(70);
            queue.Enqueue(80);
            queue.Enqueue(90);

            Assert.AreEqual(9, queue.Count, "Queue count mismatches with actual count.");
            Assert.AreEqual(16, queue.Capacity, "Grow did not multiply correctly.");
            Assert.AreEqual(0, queue.StartIndex, "Start index did not reset correctly.");
            Assert.AreEqual(9, queue.EndIndex, "End index did not reset correctly.");
        }

        [Test]
        public void Test_Dequeue_Should_Remove_Correctly()
        {
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            int el;
            string failureDequue = "Dequeue element mismatch";

            el = queue.Dequeue();
            Assert.AreEqual(10, el, failureDequue);
            el = queue.Dequeue();
            Assert.AreEqual(20, el, failureDequue);
            el = queue.Dequeue();
            Assert.AreEqual(30, el, failureDequue);

            Assert.AreEqual(0, queue.Count, "Expected and actual count mismatch.");
        }

        [Test]
        public void Test_Dequeue_Empty_Should_Throw_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue(), "Cannot dequeue on an empty queue");
        }

        [Test]
        public void Test_Peek_Should_Return_Correct_Element()
        {
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);

            Assert.AreEqual(10, queue.Peek(), "The queue returned the wrong element at peek.");
        }

        [Test]
        public void Test_Peek_Empty_Should_Throw_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Peek(), "Cannot peek an empty queue");
        }

        [TestCaseSource(nameof(ArrayCases))]
        public void Test_To_Array_Should_Return_Correct_Array(int[] nums, int[] expected)
        {
            foreach (int n in nums) queue.Enqueue(n);

            CollectionAssert.AreEqual(expected, queue.ToArray(), "ToArray does not return correct array.");
        }

        [TestCaseSource(nameof(StringCases))]
        public void Test_To_String_Should_Return_Correct_String(int[] nums, string expected)
        {
            foreach (int n in nums) queue.Enqueue(n);

            Assert.AreEqual(expected, queue.ToString(), "ToString does not return correct string.");
        }

        [Test]
        public void Test_Enqueue_Dequeue_Range_Cross()
        {
            CircularQueue<int> queue = new CircularQueue<int>(5);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.AreEqual(10, queue.Dequeue());
            Assert.AreEqual(20, queue.Dequeue());

            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60);

            Assert.AreEqual("[30, 40, 50, 60]", queue.ToString());
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(5, queue.Capacity);
            Assert.True(queue.StartIndex > queue.EndIndex);
        }

        [Test]
        public void Test_Threehundred_Operatios()
        {
            CircularQueue<int> queue = new CircularQueue<int>(2);

            int added = 0;
            int removed = 0;
            int counter = 0;

            for (int i = 0; i < 300; i++)
            {
                Assert.AreEqual(added - removed, queue.Count);

                for (int j = 0; j < 2; j++)
                {
                    queue.Enqueue(++counter);
                    added++;
                    Assert.AreEqual(added - removed, queue.Count);
                }

                int peekEl = queue.Peek();
                Assert.AreEqual(removed + 1, peekEl);

                int dequeueEl = queue.Dequeue();
                removed++;
                Assert.AreEqual(removed, dequeueEl);
                Assert.AreEqual(added - removed, queue.Count);

                int[] expectedArr = Enumerable.Range(removed + 1, added - removed).ToArray();
                string expectedStr = $"[{string.Join(", ", expectedArr)}]";
                CollectionAssert.AreEqual(expectedArr, queue.ToArray());
                Assert.AreEqual(expectedStr, queue.ToString());

                Assert.True(queue.Capacity >= queue.Count);
            }

            Assert.True(queue.Capacity > 2);
        }

        [Test]
        [Timeout(500)]
        public void Test_Million_Items_Performance()
        {
            CircularQueue<int> queue = new CircularQueue<int>();

            int added = 0;
            int removed = 0;
            int counter = 0;

            for (int i = 0; i < 1_000_000 / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    queue.Enqueue(++counter);
                    added++;
                }

                queue.Dequeue();
                removed++;
            }

            Assert.AreEqual(added - removed, queue.Count);
        }

        private static IEnumerable<TestCaseData> StringCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new int[] {  }, "[]"),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50 }, "[10, 20, 30, 40, 50]"),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }, "[10, 20, 30, 40, 50, 60, 70, 80, 90]")
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        private static IEnumerable<TestCaseData> ArrayCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new int[] {  }, new int[] { }),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50 }, new int[] { 10, 20, 30, 40, 50 }),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }, new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 })
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }
    }
}
