using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace _01.RedBlackTree.Tests
{
    [TestFixture]
    public class RedBlackTests
    {
        [Test]
        public void Insert_Single_TraverseInOrder()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(1);

            // Act
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Insert_Multiple_TraverseInOrder()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(2);
            rbt.Insert(1);
            rbt.Insert(3);

            // Act
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Insert_Multiple_DeleteMin_Should_Work_Correctly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(2);
            rbt.Insert(1);
            rbt.Insert(3);

            // Act
            rbt.DeleteMin();
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMin_EmptyTree_ShouldThrow()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => rbt.DeleteMin());
        }

        [Test]
        public void DeleteMin_OnSingleNodeRoot_ShouldWorkCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(1);

            // Act
            rbt.DeleteMin();
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMin_OnRootWithRightChild_ShouldWorkCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(10);
            rbt.Insert(15);
            rbt.Insert(11);
            rbt.Insert(20);

            // Act
            rbt.DeleteMin();
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 11, 15, 20 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMin_WithoutRightChild_ShouldWorkCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(10);
            rbt.Insert(1);
            rbt.Insert(20);

            // Act
            rbt.DeleteMin();
            List<int> nodes = new List<int>() { };
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 10, 20 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMin_WithRightChild_ShouldWorkCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(10);
            rbt.Insert(1);
            rbt.Insert(5);
            rbt.Insert(20);

            // Act
            rbt.DeleteMin();
            List<int> nodes = new List<int>() { };
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 5, 10, 20 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMax_EmptyTree_ShouldThrow()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => rbt.DeleteMax());
        }

        [Test]
        public void DeleteMax_OnSingleNodeRoot_ShouldRemoveCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(1);

            // Act
            rbt.DeleteMax();
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMax_WithoutLeftChild_ShouldRemoveCorrectElement()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(2);
            rbt.Insert(1);
            rbt.Insert(3);

            // Act
            rbt.DeleteMax();
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 2 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMax_WithLeftChild_ShouldWorkCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(10);
            rbt.Insert(1);
            rbt.Insert(20);
            rbt.Insert(15);

            // Act
            rbt.DeleteMax();
            List<int> nodes = new List<int>() { };
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 10, 15 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void DeleteMax_OnRootWithLeftChild_ShouldWorkCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(1);
            rbt.Insert(8);

            // Act
            rbt.DeleteMax();
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 5, 8 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Count_OnFewElements_ShouldReturnCorrectCount()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);

            // Act
            int actualCount = rbt.Count;

            // Assert
            Assert.AreEqual(10, actualCount);
        }

        [Test]
        public void Count_EmptyTree_ShouldReturnCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            // Act
            int actualCount = rbt.Count;

            // Assert
            Assert.AreEqual(0, actualCount);
        }

        [Test]
        public void Count_AfterDeleteMin_ShouldReturnCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);

            // Act
            rbt.DeleteMin();
            int actualCount = rbt.Count;

            // Assert
            Assert.AreEqual(9, actualCount);
        }

        [Test]
        public void Count_AfterDeleteMax_ShouldReturnCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);

            // Act
            rbt.DeleteMax();
            int actualCount = rbt.Count;

            // Assert
            Assert.AreEqual(9, actualCount);
        }

        [Test]
        public void Search_NonExistingElement_ShouldReturnEmptyTree()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            // Act
            IBinarySearchTree<int> result = rbt.Search(5);
            List<int> nodes = new List<int>();
            result.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }


        [Test]
        public void Search_ExistingElement_ShouldReturnSubTree()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);

            // Act
            IBinarySearchTree<int> result = rbt.Search(37);
            List<int> nodes = new List<int>();
            result.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 8, 9, 10, 37, 39, 45 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_EmptyTree_ShouldThrow()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => rbt.Delete(45));
        }

        [Test]
        public void Delete_OneElement_ShouldRemoveCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);

            // Act
            rbt.Delete(10);
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_ElementWithoutRightChild_ShouldReplaceWithLeft()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);
            rbt.Insert(0);

            // Act
            rbt.Delete(1);
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 0, 3, 4, 5, 8, 9, 10, 37, 39, 45 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_LeafElement_ShouldRemoveCorrectly()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);

            // Act
            rbt.Delete(1);
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 3, 4, 5, 8, 9, 10, 37, 39, 45 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_RightChildHasNoLeftChild_ShouldPromoteRightChild()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);

            // Act
            rbt.Delete(37);
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 3, 4, 5, 8, 9, 10, 39, 45 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_RightChildHasLeftChild_ShouldPromoteSmallestLeft()
        {
            // Arrange
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);
            rbt.Insert(6);

            // Act
            rbt.Delete(5);
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = new int[] { 1, 3, 4, 6, 8, 9, 10, 37, 39, 45 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
    }
}
