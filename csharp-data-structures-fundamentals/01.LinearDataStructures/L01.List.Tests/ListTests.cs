namespace L01.List.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using L01.List;

    [TestFixture]
    public class ListTests
    {
        private IAbstractList<int> list;

        [SetUp]
        public void InitializeList()
        {
            this.list = new L01.List.List<int>();
        }

        private static IEnumerable<int[]> RandomCollections()
        {
            var collections = new System.Collections.Generic.List<int[]>
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
        public void Add_SingleNumber_ShouldAddCorrectElement()
        {
            var expected = new int[] { 1 };

            foreach (var num in expected)
            {
                this.list.Add(num);
            }

            CollectionAssert.AreEqual(expected, this.list);
        }

        [Test]
        public void Add_SingleNumber_ShouldIncrementCount()
        {
            this.list.Add(5);

            Assert.AreEqual(1, this.list.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Add_MultipleNumbers_ShouldAddCorrectElements(int[] expected)
        {
            foreach (var num in expected)
            {
                this.list.Add(num);
            }

            CollectionAssert.AreEqual(expected, this.list);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Add_MultipleNumbers_ShouldIncreaseCount(int[] expected)
        {
            Assert.AreEqual(0, this.list.Count);

            foreach (var num in expected)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(expected.Length, this.list.Count);
        }

        [Test]
        [TestCase(5, ExpectedResult = 5)]
        public int Indexer_GetOnlyElement_ShouldReturnCorrectElement(int element)
        {
            this.list.Add(element);

            return this.list[0];
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Indexer_GetFirstElement_ShouldReturnCorrectElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(expected[0], this.list[0]);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Indexer_GetLastElement_ShouldReturnCorrectElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(expected[expected.Length - 1], this.list[this.list.Count - 1]);
        }

        [Test]
        public void Indexer_GetInvalidElement_ShouldThrowException([Values(-1, 1, 8, -5, int.MinValue, int.MaxValue)] int index)
        {
            this.list.Add(10);

            Assert.Throws<IndexOutOfRangeException>(() => { var test = this.list[index]; });
        }

        [Test]
        public void Indexer_SetSingleElement_ShouldWorkCorrectly()
        {
            this.list.Add(1);
            this.list[0] = 5;

            CollectionAssert.AreEqual(new int[] { 5 }, this.list);
        }

        [Test]
        public void Indexer_SetInvalidElement_ShouldThrowException([Values(-1, 1, 8, -5, int.MinValue, int.MaxValue)] int index)
        {
            this.list.Add(10);

            Assert.Throws<IndexOutOfRangeException>(() => { this.list[index] = 5; ; });
        }


        [Test]
        public void IndexOf_OnCollectionWithSingleElement_ShouldReturnCorrectIndex()
        {
            var value = 10;
            this.list.Add(value);

            Assert.AreEqual(0, this.list.IndexOf(value));
        }

        [Test]
        public void IndexOf_WithExistingElement_ShouldReturnCorrectIndex()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(1, this.list.IndexOf(5));
        }

        [Test]
        public void IndexOf_WithNonExistingElement_ShouldReturnMinusOne()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(-1, this.list.IndexOf(56));
        }

        [Test]
        public void IndexOf_OnEmptyCollection_ShouldReturnMinusOne()
        {
            Assert.AreEqual(-1, this.list.IndexOf(56));
        }

        [Test]
        public void IndexOf_WithMultipleCopiesOfElement_ShouldReturnLeftmostIndex()
        {
            var numbers = new int[] { 3, 5, 7, 1, 7, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(2, this.list.IndexOf(7));
        }

        [Test]
        public void IndexOf_FirstElement_ShouldReturnIndexZero()
        {
            var numbers = new int[] { 3, 5, 7, 1, 7, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(0, this.list.IndexOf(3));
        }

        [Test]
        public void IndexOf_LastElement_ShouldReturnLastIndex()
        {
            var numbers = new int[] { 3, 5, 7, 1, 7, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(numbers.Length - 1, this.list.IndexOf(-100));
        }

        [Test]
        public void Contains_OnCollectionWithSingleElement_ShouldReturnTrue()
        {
            var value = 10;
            this.list.Add(value);

            Assert.AreEqual(true, this.list.Contains(value));
        }

        [Test]
        public void Contains_WithExistingElement_ShouldReturnTrue()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(true, this.list.Contains(5));
        }

        [Test]
        public void Contains_OnEmptyCollection_ShouldReturnFalse()
        {
            Assert.AreEqual(false, this.list.Contains(56));
        }

        [Test]
        public void Contains_OnEmptyCollectionSearchingForZero_ShouldReturnFalse()
        {
            Assert.AreEqual(false, this.list.Contains(0));
        }

        [Test]
        public void Contains_WithNonExistingElement_ShouldReturnFalse()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            Assert.AreEqual(false, this.list.Contains(536));
        }

        [Test]
        public void RemoveAt_WithSingleElement_ShouldDecreaseCount()
        {
            this.list.Add(15);
            this.list.RemoveAt(0);

            Assert.AreEqual(0, this.list.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void RemoveAt_WithMultipleElements_ShouldDecreaseCount(int[] expected)
        {
            foreach (var num in expected)
            {
                this.list.Add(num);
            }
            this.list.RemoveAt(0);

            Assert.AreEqual(expected.Length - 1, this.list.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void RemoveAt_WithMultipleElements_ShouldRemoveCorrectElement(int[] expected)
        {
            int indexToRemove = expected.Length / 2;
            foreach (var num in expected)
            {
                this.list.Add(num);
            }
            this.list.RemoveAt(indexToRemove);

            var expectedAsList = expected.ToList();
            expectedAsList.RemoveAt(indexToRemove);

            CollectionAssert.AreEqual(expectedAsList, this.list);
        }

        [Test]
        public void RemoveAt_InvalidIndex_ShouldThrowException([Values(-1, 1, 8, -5, int.MinValue, int.MaxValue)] int index)
        {
            this.list.Add(10);

            Assert.Throws<IndexOutOfRangeException>(() => { this.list.RemoveAt(index); });
        }

        [Test]
        public void Remove_WithSingleElement_ShouldDecreaseCount()
        {
            this.list.Add(15);
            this.list.Remove(15);

            Assert.AreEqual(0, this.list.Count);
        }

        [Test]
        public void Remove_WithSingleElement_ShouldReturnTrue()
        {
            this.list.Add(15);

            Assert.AreEqual(true, this.list.Remove(15));
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Remove_WithMultipleElements_ShouldRemoveCorrectElement(int[] expected)
        {
            int itemToRemove = expected[expected.Length / 2];
            foreach (var num in expected)
            {
                this.list.Add(num);
            }
            this.list.Remove(itemToRemove);

            var expectedAsList = expected.ToList();
            expectedAsList.Remove(itemToRemove);

            CollectionAssert.AreEqual(expectedAsList, this.list);
        }

        [Test]
        public void Remove_InvalidElement_ShouldReturnFalse([Values(-1, 1)] int element)
        {
            this.list.Add(10);

            Assert.AreEqual(false, this.list.Remove(element));
        }


        [Test]
        public void Insert_SingleElement_ShouldIncreaseCount()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            this.list.Insert(2, 1001);

            Assert.AreEqual(numbers.Length + 1, this.list.Count);
        }

        [Test]
        public void Insert_SingleElement_ShouldPutElementInCorrectPosition()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            this.list.Insert(2, 1001);

            Assert.AreEqual(2, this.list.IndexOf(1001));
        }

        [Test]
        public void Insert_TwoElements_ShouldPutThemInCorrectPositions()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            this.list.Insert(2, 1001);

            Assert.AreEqual(2, this.list.IndexOf(1001));

            this.list.Insert(4, 1002);
            Assert.AreEqual(4, this.list.IndexOf(1002));
            Assert.AreEqual(1, this.list[5]);
        }

        [Test]
        public void Insert_LastIndex_ShouldWorkCorrectly()
        {
            var numbers = new int[] { 3, 5, 7, 1, -5, -100 };
            foreach (var num in numbers)
            {
                this.list.Add(num);
            }

            this.list.Insert(this.list.Count - 1, 100);

            Assert.AreEqual(-100, this.list[this.list.Count - 1]);
            Assert.AreEqual(100, this.list[5]);
        }

        [Test]
        public void Insert_InvalidIndex_ShouldThrowException([Values(-1, 1, 3, -5, int.MinValue, int.MaxValue)] int index)
        {
            this.list.Add(10);

            Assert.Throws<IndexOutOfRangeException>(() => { this.list.Insert(index, 15); });
        }
    }
}
