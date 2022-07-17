using System.Collections.Generic;
using NUnit.Framework;

namespace AVLTree.Tests
{
    public class AVLTests
    {
        [Test]
        public void TraverseInOrder_AfterSingleInsert()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(1);

            // Act
            List<int> nodes = new List<int>();
            avl.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void TraverseInOrder_AfterMultipleInserts()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(2);
            avl.Insert(1);
            avl.Insert(3);

            // Act
            List<int> nodes = new List<int>();
            avl.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Contains_ExistingElement_ShouldReturnTrue()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(2);
            avl.Insert(1);
            avl.Insert(3);

            // Act
            // Assert
            Assert.IsTrue(avl.Contains(1));
            Assert.IsTrue(avl.Contains(2));
            Assert.IsTrue(avl.Contains(3));
        }

        [Test]
        public void Contains_NonExistingElement_ShouldReturnFalse()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(2);
            avl.Insert(1);
            avl.Insert(3);

            // Act
            bool contains = avl.Contains(5);

            // Assert
            Assert.IsFalse(contains);
        }

        [Test]
        public void Height_RootRight()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(1);
            avl.Insert(2);

            // Act
            // Assert
            Assert.AreEqual(2, avl.Root.Height);
            Assert.AreEqual(1, avl.Root.Right.Height);
        }

        [Test]
        public void Height_RootLeft()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(2);
            avl.Insert(1);

            // Act
            // Assert
            Assert.AreEqual(2, avl.Root.Height);
            Assert.AreEqual(1, avl.Root.Left.Height);
        }

        [Test]
        public void Height_RootLeftRight()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(2);
            avl.Insert(1);
            avl.Insert(3);

            // Act
            // Assert
            Assert.AreEqual(2, avl.Root.Height);
            Assert.AreEqual(1, avl.Root.Left.Height);
            Assert.AreEqual(1, avl.Root.Right.Height);
        }

        [Test]
        public void Rebalance_RootShouldHaveHeightTwo()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();
            avl.Insert(1);
            avl.Insert(2);
            avl.Insert(3);

            // Assert
            Assert.AreEqual(2, avl.Root.Height);
        }

        [Test]
        public void Rebalance_TestHeightOneNodes()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            for (int i = 1; i < 10; i++)
            {
                avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(1, avl.Root.Left.Left.Height); // 1
            Assert.AreEqual(1, avl.Root.Left.Right.Height); // 3
            Assert.AreEqual(1, avl.Root.Right.Left.Height); // 5
            Assert.AreEqual(1, avl.Root.Right.Right.Left.Height); // 7
            Assert.AreEqual(1, avl.Root.Right.Right.Right.Height); // 9
        }

        [Test]
        public void Rebalance_TestHeightTwoNodes()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            for (int i = 1; i < 10; i++)
            {
                avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(2, avl.Root.Left.Height); // 2
            Assert.AreEqual(2, avl.Root.Right.Right.Height); // 8
        }

        [Test]
        public void Rebalance_TestHeightThreeNodes()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            for (int i = 1; i < 10; i++)
            {
                avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(3, avl.Root.Right.Height); // 6
        }

        [Test]
        public void Rebalance_TestHeightFourNodes()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            for (int i = 1; i < 10; i++)
            {
                avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(4, avl.Root.Height); // 4
        }

        [Test]
        public void Rebalance_SingleRight()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            // Act
            avl.Insert(3);
            avl.Insert(2);
            avl.Insert(1);

            // Assert
            Assert.AreEqual(2, avl.Root.Value);
        }

        [Test]
        public void Rebalance_SingleLeft()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            // Act
            avl.Insert(1);
            avl.Insert(2);
            avl.Insert(3);

            // Assert
            Assert.AreEqual(2, avl.Root.Value);
        }

        [Test]
        public void Rebalance_DoubleRight()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            // Act
            avl.Insert(5);
            avl.Insert(2);
            avl.Insert(4);

            // Assert
            Assert.AreEqual(4, avl.Root.Value);
            Assert.AreEqual(2, avl.Root.Height);
            Assert.AreEqual(1, avl.Root.Left.Height);
            Assert.AreEqual(1, avl.Root.Right.Height);
        }

        [Test]
        public void Rebalance_DoubleLeft()
        {
            // Arrange
            AVL<int> avl = new AVL<int>();

            // Act
            avl.Insert(5);
            avl.Insert(7);
            avl.Insert(6);

            // Assert
            Assert.AreEqual(6, avl.Root.Value);
            Assert.AreEqual(2, avl.Root.Height);
            Assert.AreEqual(1, avl.Root.Left.Height);
            Assert.AreEqual(1, avl.Root.Right.Height);
        }

        [Test, Timeout(400)]
        public void Performance_Insert_Contains()
        {
            AVL<int> avl = new AVL<int>();

            for (int i = 0; i < 100000; i++)
            {
                avl.Insert(i);
            }

            for (int i = 0; i < 100000; i++)
            {
                Assert.IsTrue(avl.Contains(i));
            }
        }
    }
}
