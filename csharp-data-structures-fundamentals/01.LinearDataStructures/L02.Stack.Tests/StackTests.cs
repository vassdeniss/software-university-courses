namespace L02.Stack.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using L02.Stack;

    [TestFixture]
    public class StackTests
    {
        private IAbstractStack<int> stack;
        private System.Collections.Generic.Stack<int> builtInStack;

        [SetUp]
        public void InitializeStack()
        {
            this.stack = new L02.Stack.Stack<int>();
            this.builtInStack = new System.Collections.Generic.Stack<int>();
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
        public void Push_SingleElement_ShouldIncreaseCount()
        {
            this.stack.Push(1);
            Assert.AreEqual(1, this.stack.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Push_MultipleElements_ShouldOrderElementsCorrectly(int[] expected)
        {

            foreach (var num in expected)
            {
                this.stack.Push(num);
                this.builtInStack.Push(num);
            }

            CollectionAssert.AreEqual(builtInStack, this.stack);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Push_MultipleElements_ShouldIncreaseCount(int[] expected)
        {
            foreach (var num in expected)
            {
                this.stack.Push(num);
                this.builtInStack.Push(num);
            }

            Assert.AreEqual(builtInStack.Count, this.stack.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Pop_WithMultipleElements_ShouldRemoveTheTopElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.stack.Push(num);
                this.builtInStack.Push(num);
            }

            do
            {
                Assert.AreEqual(builtInStack.Pop(), this.stack.Pop());
            }
            while (this.stack.Count > 0);
        }

        [Test]
        public void Pop_WithSingeElement_ShouldDecreaseCount()
        {
            Assert.AreEqual(0, this.stack.Count);
            this.stack.Push(10);

            Assert.AreEqual(1, this.stack.Count);

            this.stack.Pop();
            Assert.AreEqual(0, this.stack.Count);
        }

        [Test]
        public void Pop_OnEmptyStack_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Peek_WithMultipleElements_ShouldNotRemoveTheTopElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.stack.Push(num);
                this.builtInStack.Push(num);
            }

            Assert.AreEqual(builtInStack.Peek(), this.stack.Peek());
            Assert.AreEqual(builtInStack.Peek(), this.stack.Peek());
        }

        [Test]
        public void Peek_WithSingeElement_ShouldNotDecreaseCount()
        {
            Assert.AreEqual(0, this.stack.Count);
            this.stack.Push(10);

            Assert.AreEqual(1, this.stack.Count);

            this.stack.Peek();
            Assert.AreEqual(1, this.stack.Count);
        }

        [Test]
        public void Peek_OnEmptyStack_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Contains_OnCollectionWithSingleElement_ShouldReturnTrue()
        {
            var value = 10;
            this.stack.Push(value);

            Assert.AreEqual(true, this.stack.Contains(value));
        }

        [Test]
        public void Contains_WithExistingElement_ShouldReturnTrue()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.stack.Push(num);
            }

            Assert.AreEqual(true, this.stack.Contains(5));
        }

        [Test]
        public void Contains_OnEmptyCollection_ShouldReturnFalse()
        {
            Assert.AreEqual(false, this.stack.Contains(56));
        }

        [Test]
        public void Contains_WithNonExistingElement_ShouldReturnFalse()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.stack.Push(num);
            }

            Assert.AreEqual(false, this.stack.Contains(536));
        }

    }
}
