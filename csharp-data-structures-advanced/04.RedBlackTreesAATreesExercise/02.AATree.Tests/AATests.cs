using System.Collections.Generic;

using NUnit.Framework;

namespace _02.AA_Tree.Tests
{
    public class AATests
    {
        private AATree<int> AATree;
        private readonly int[] input = 
        {
            18, 13, 1, 7, 42, 73, 56, 24, 6, 2, 74, 69, 55
        };

        [SetUp]
        public void Setup()
        {
            this.AATree = new AATree<int>();

            foreach (int integer in this.input) 
            {
                this.AATree.Insert(integer);
            }
        }


        [Test]
        public void TestCountNodes()
        {
            Assert.AreEqual(13, this.AATree.CountNodes());
            Assert.AreEqual(0, new AATree<int>().CountNodes());
        }

        [Test]
        public void TestIsEmpty() 
        {
            Assert.IsFalse(this.AATree.IsEmpty());
            Assert.IsTrue(new AATree<int>().IsEmpty());
        }

        [Test]
        public void TestSearch() 
        {
            Assert.IsTrue(this.AATree.Search(73));
            Assert.False(new AATree<int>().Search(100));
        }

        [Test]
        public void TestPreOrder() 
        {
            List<int> actual = new List<int>();
            this.AATree.PreOrder(n => actual.Add(n));

            List<int> expected = new List<int>(){ 13, 6, 1, 2, 7, 56, 42, 18, 24, 55, 73, 69, 74 };

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInOrder()
        {
            List<int> numbers = new List<int>();
            this.AATree.InOrder(n => numbers.Add(n));
            List<int> expected = new List<int> { 1, 2, 6, 7, 13, 18, 24, 42, 55, 56, 69, 73, 74 };

            Assert.AreEqual(expected.Count, numbers.Count);
            CollectionAssert.AreEqual(expected, numbers);
        }

        [Test]
        public void TestPostOrder() 
        {
            List<int> actual = new List<int>();
            this.AATree.PostOrder(n => actual.Add(n));

            List<int> expected = new List<int> {2, 1, 7, 6, 24, 18, 55, 42, 69, 74, 73, 56, 13};

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
