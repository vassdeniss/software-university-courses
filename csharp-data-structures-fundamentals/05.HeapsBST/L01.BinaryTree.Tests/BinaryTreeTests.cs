using NUnit.Framework;
using L01.BinaryTree;
using System.Text;
using System;
using System.Linq;

public class BinaryTreeTests
{
    private IAbstractBinaryTree<int> tree;

    [SetUp]
    public void InitializeBinaryTree()
    {
        this.tree = new BinaryTree<int>(
                        17,
                        new BinaryTree<int>(
                            9,
                            new BinaryTree<int>(3, null, null),
                            new BinaryTree<int>(11, null, null)
                        ),
                        new BinaryTree<int>(
                            25,
                            new BinaryTree<int>(20, null, null),
                            new BinaryTree<int>(31, null, null)
                        )
        );
    }

    [Test]
    public void TestAsIndentedPreOrder()
    {
        string indentedPreOrder = this.tree.AsIndentedPreOrder(0);
        Assert.AreEqual(
            $"17{Environment.NewLine}" +
            $"  9{Environment.NewLine}" +
            $"    3{Environment.NewLine}" +
            $"    11{Environment.NewLine}" +
            $"  25{Environment.NewLine}" +
            $"    20{Environment.NewLine}" +
             "    31", indentedPreOrder.TrimEnd());
    }

    [Test]
    public void TestPreOrder()
    {
        var trees = this.tree.PreOrder().ToList();
        int[] expected = { 17, 9, 3, 11, 25, 20, 31 };
        Assert.AreEqual(expected.Length, trees.Count);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], trees[i].Value);
        }
    }


    [Test]
    public void TestInOrder()
    {
        var trees = this.tree.InOrder().ToList();
        int[] expected = { 3, 9, 11, 17, 20, 25, 31 };
        Assert.AreEqual(expected.Length, trees.Count);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], trees[i].Value);
        }
    }


    [Test]
    public void TestPostOrder()
    {
        var trees = this.tree.PostOrder().ToList();
        int[] expected = { 3, 11, 9, 20, 31, 25, 17 };
        Assert.AreEqual(expected.Length, trees.Count);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], trees[i].Value);
        }
    }

    [Test]
    public void TestForEachInOrder()
    {
        string expected = "3, 9, 11, 17, 20, 25, 31";
        StringBuilder builder = new StringBuilder();

        this.tree.ForEachInOrder(key => builder.Append(key).Append(", "));
        string actual = builder.ToString();

        Assert.AreEqual(expected, actual.Substring(0, actual.LastIndexOf(", ")));
    }
}
