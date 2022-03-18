using NUnit.Framework;
using E01.BinarySearchTree;
using System.Collections.Generic;
using System.Linq;
using System;

[TestFixture]
public class Tests
{
    [Test]
    public void Insert_Single_TraverseInOrder()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(1);

        // Act
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Insert_Multiple_TraverseInOrder()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 2, 3 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Contains_ExistingElement_ShouldReturnTrue()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        bool contains = bst.Contains(1);

        // Assert
        Assert.IsTrue(contains);
    }

    [Test]
    public void Contains_NonExistingElement_ShouldReturnFalse()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        bool contains = bst.Contains(5);

        // Assert
        Assert.IsFalse(contains);
    }

    [Test]
    public void Insert_Multiple_DeleteMin_Should_Work_Correctly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 2, 3 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }


    [Test]
    public void DeleteMin_EmptyTree_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.DeleteMin());
    }

    [Test]
    public void DeleteMin_OnSingleNodeRoot_ShouldWorkCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(1);

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void DeleteMin_OnRootWithRightChild_ShouldWorkCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(10);
        bst.Insert(15);
        bst.Insert(11);
        bst.Insert(20);

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 11, 15, 20 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void DeleteMin_WithoutRightChild_ShouldWorkCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(10);
        bst.Insert(1);
        bst.Insert(20);

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>() { };
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 10, 20 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void DeleteMin_WithRightChild_ShouldWorkCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(10);
        bst.Insert(1);
        bst.Insert(5);
        bst.Insert(20);

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>() { };
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 5, 10, 20 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void DeleteMax_EmptyTree_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.DeleteMax());
    }

    [Test]
    public void DeleteMax_OnSingleNodeRoot_ShouldRemoveCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(1);

        // Act
        bst.DeleteMax();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void DeleteMax_WithoutLeftChild_ShouldRemoveCorrectElement()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        bst.DeleteMax();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 2 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void DeleteMax_WithLeftChild_ShouldWorkCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(10);
        bst.Insert(1);
        bst.Insert(20);
        bst.Insert(15);

        // Act
        bst.DeleteMax();
        List<int> nodes = new List<int>() { };
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 10, 15 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void DeleteMax_OnRootWithLeftChild_ShouldWorkCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(1);
        bst.Insert(8);

        // Act
        bst.DeleteMax();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 5, 8 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Count_OnFewElements_ShouldReturnCorrectCount()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        int actualCount = bst.Count();

        // Assert
        Assert.AreEqual(10, actualCount);
    }

    [Test]
    public void Count_EmptyTree_ShouldReturnCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        int actualCount = bst.Count();

        // Assert
        Assert.AreEqual(0, actualCount);
    }

    [Test]
    public void Count_AfterDeleteMin_ShouldReturnCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        bst.DeleteMin();
        int actualCount = bst.Count();

        // Assert
        Assert.AreEqual(9, actualCount);
    }

    [Test]
    public void Count_AfterDeleteMax_ShouldReturnCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        bst.DeleteMax();
        int actualCount = bst.Count();

        // Assert
        Assert.AreEqual(9, actualCount);
    }

    [Test]
    public void Search_NonExistingElement_ShouldReturnEmptyTree()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        IBinarySearchTree<int> result = bst.Search(5);
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
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        IBinarySearchTree<int> result = bst.Search(5);
        List<int> nodes = new List<int>();
        result.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 5, 8, 9 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Range_ExistingElements_ShouldReturnCorrectElements()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        IEnumerable<int> result = bst.Range(4, 37);

        // Assert
        int[] expectedNodes = new int[] { 4, 5, 8, 9, 10, 37 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [Test]
    public void Range_ExistingElements_ShouldReturnCorrectCount()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        IEnumerable<int> result = bst.Range(4, 37);

        // Assert
        int[] expectedNodes = new int[] { 4, 5, 8, 9, 10, 37 };
        Assert.AreEqual(expectedNodes.Length, result.ToArray().Length);
    }

    [Test]
    public void Rank_ExistingElement_ShouldReturnCorrectRank()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        int rank = bst.Rank(9);

        // Assert
        Assert.AreEqual(5, rank);
    }

    [Test]
    public void Rank_NonExistingSmallElement_ShouldReturnZero()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        int rank = bst.Rank(-9);

        // Assert
        Assert.AreEqual(0, rank);
    }

    [Test]
    public void Rank_NonExistingLargeElement_ShouldReturnTreeCount()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        int rank = bst.Rank(5500);

        // Assert
        Assert.AreEqual(bst.Count(), rank);
    }

    [Test]
    public void Rank_EmptyTree_ShouldReturnZero()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        int rank = bst.Rank(5500);

        // Assert
        Assert.AreEqual(0, rank);
    }

    [Test]
    public void Select_EmptyTree_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.Select(5));
    }

    [Test]
    public void Select_FewElements_ShouldReturnCorrectElement()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        int select = bst.Select(5);

        // Assert
        Assert.AreEqual(9, select);
    }

    [Test]
    public void Select_NonExistingElement_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.Select(15));
    }

    [Test]
    public void Ceiling_FewElements_ShouldReturnCorrectElement()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        int ceiling = bst.Ceiling(4);

        // Assert
        Assert.AreEqual(5, ceiling);
    }

    [Test]
    public void Ceiling_NonExistingCeil_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(45);

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.Ceiling(45));
    }

    [Test]
    public void Ceiling_EmptyTree_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.Ceiling(45));
    }

    [Test]
    public void Floor_EmptyTree_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.Floor(45));
    }

    [Test]
    public void Floor_FewElements_ShouldReturnCorrectElement()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        int floor = bst.Floor(5);

        // Assert
        Assert.AreEqual(4, floor);
    }

    [Test]
    public void Delete_EmptyTree_ShouldThrow()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => bst.Delete(45));
    }

    [Test]
    public void Delete_OneElement_ShouldRemoveCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);

        // Act
        bst.Delete(10);
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Delete_ElementWithoutRightChild_ShouldReplaceWithLeft()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);
        bst.Insert(0);

        // Act
        bst.Delete(1);
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 0, 3, 4, 5, 8, 9, 10, 37, 39, 45 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Delete_LeafElement_ShouldRemoveCorrectly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        bst.Delete(1);
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 3, 4, 5, 8, 9, 10, 37, 39, 45 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Delete_RightChildHasNoLeftChild_ShouldPromoteRightChild()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        bst.Delete(37);
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 5, 8, 9, 10, 39, 45 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Delete_RightChildHasLeftChild_ShouldPromoteSmallestLeft()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);
        bst.Insert(6);

        // Act
        bst.Delete(5);
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 6, 8, 9, 10, 37, 39, 45 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }
}
