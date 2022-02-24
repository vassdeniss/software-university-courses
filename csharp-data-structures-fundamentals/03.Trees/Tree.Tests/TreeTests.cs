namespace Tree.Tests
{
    using NUnit.Framework;
    using System;

    public class TreeTests
    {
        private Tree<int> tree;

        [SetUp]
        public void Setup()
        {
            this.tree = new Tree<int>(7,
                new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)));
        }

        [Test]
        public void TestTreeConstructorNotNull()
        {
            Assert.NotNull(tree);
            Assert.NotNull(tree.Value);
            Assert.NotNull(tree.Children);
        }


        [Test]
        public void TestTreeBfsWorksCorrectly()
        {
            int[] expected = { 7, 19, 21, 14, 1, 12, 31, 23, 6 };
            int index = 0;
            var traversedTree = tree.OrderBfs();
            foreach (int num in traversedTree)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestTreeDfsWorksCorrectly()
        {
            int[] expected = { 1, 12, 31, 19, 21, 23, 6, 14, 7 };
            int index = 0;
            var traversedTree = tree.OrderDfs();
            foreach (int num in traversedTree)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestAddChildSubtreeWorksCorrectly()
        {
            tree.AddChild(1, new Tree<int>(-1, new Tree<int>(-2), new Tree<int>(-3)));
            int[] expected = { -2, -3, -1, 1, 12, 31, 19, 21, 23, 6, 14, 7 };
            int index = 0;
            var traversedTree = tree.OrderDfs();
            foreach (int num in traversedTree)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestAddChildSubtreeThrowsException()
        {
            Assert.Throws<ArgumentNullException>(()
                => tree.AddChild(77, new Tree<int>(-1, new Tree<int>(-2), new Tree<int>(-3))));
        }

        [Test]
        public void TestRemoveNodeWorksCorrectly()
        {
            int[] expected = { 7, 21, 14, 23, 6 };
            tree.RemoveNode(19);
            var integers = tree.OrderBfs();

            Assert.AreEqual(expected.Length, integers.Count);

            int index = 0;
            foreach (int num in integers)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestRemoveLeafNodeWorksCorrectly()
        {
            int[] expected = { 7, 19, 14, 1, 12, 31, 23, 6 };
            tree.RemoveNode(21);
            var integers = tree.OrderBfs();

            Assert.AreEqual(expected.Length, integers.Count);

            int index = 0;
            foreach (int num in integers)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestRemoveParentWorksCorrectly()
        {
            int[] expected = { };
            tree.RemoveNode(7);

            var integers = tree.OrderBfs();

            Assert.AreEqual(expected.Length, integers.Count);
        }

        [Test]
        public void TestRemoveNodeThrowsException()
        {
            Assert.Throws<ArgumentNullException>(()
                => tree.RemoveNode(77));
        }

        [Test]
        public void TestSwapWorksCorrectly()
        {
            int[] expected = { 7, 14, 21, 19, 23, 6, 1, 12, 31 };
            tree.Swap(19, 14);
            var integers = tree.OrderBfs();

            Assert.AreEqual(expected.Length, integers.Count);

            int index = 0;
            foreach (int num in integers)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestSwapWorksCorrectlyWithLeafNode()
        {
            int[] expected = { 7, 23, 21, 14, 19, 6, 1, 12, 31 };
            tree.Swap(19, 23);
            var integers = tree.OrderBfs();

            Assert.AreEqual(expected.Length, integers.Count);

            int index = 0;
            foreach (int num in integers)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestSwapRootNodeWorksCorrectly()
        {
            int[] expected = { 19, 1, 12, 31 };
            tree.Swap(7, 19);
            var integers = tree.OrderBfs();

            Assert.AreEqual(expected.Length, integers.Count);

            int index = 0;
            foreach (int num in integers)
            {
                Assert.AreEqual(expected[index++], num);
            }
        }

        [Test]
        public void TestSwapThrowsExceptionForLeftNode()
        {
            Assert.Throws<ArgumentNullException>(()
                => tree.Swap(77, 19));
        }

        [Test]
        public void TestSwapThrowsExceptionForRightNode()
        {
            Assert.Throws<ArgumentNullException>(()
                => tree.Swap(19, 77));
        }
    }
}
