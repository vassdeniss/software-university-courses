using NUnit.Framework;
using L02.BinarySearchTree;
using System.Collections.Generic;
using System.Linq;
using System;

[TestFixture]
public class BinarySearchTreeTests
{
    [Test]
    public void Insert_Single_TraverseInOrder()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(1);

        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        int[] expectedNodes = new int[] { 1 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Insert_Multiple_TraverseInOrder()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        int[] expectedNodes = new int[] { 1, 2, 3 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [Test]
    public void Contains_ExistingElement_ShouldReturnTrue()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        bool contains = bst.Contains(1);

        Assert.IsTrue(contains);
    }

    [Test]
    public void Contains_NonExistingElement_ShouldReturnFalse()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        bool contains = bst.Contains(5);

        Assert.IsFalse(contains);
    }


    [Test]
    public void Search_NonExistingElement_ShouldReturnNull()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        IBinarySearchTree<int> result = bst.Search(5);

        Assert.IsNull(result);
    }


    [Test]
    public void Search_ExistingElement_ShouldReturnSubTree()
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

        IBinarySearchTree<int> result = bst.Search(5);
        List<int> nodes = new List<int>();
        result.EachInOrder(nodes.Add);

        int[] expectedNodes = new int[] { 1, 3, 4, 5, 8, 9 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }
}
