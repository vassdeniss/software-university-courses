using System;
using E02.LowestCommonAncestor;
using NUnit.Framework;

public class LCATests
{
    private IAbstractBinaryTree<int> binaryTree;

    [SetUp]
    public void Setup()
    {
        this.binaryTree = new BinaryTree<int>(
            12,
            new BinaryTree<int>(5,
                new BinaryTree<int>(1, null, null),
                new BinaryTree<int>(8, null, null)
            ),
            new BinaryTree<int>(19,
                new BinaryTree<int>(16, null, null),
                new BinaryTree<int>(23,
                    new BinaryTree<int>(21, null, null),
                    new BinaryTree<int>(30, null, null)
                )
            )
        );
    }

    [Test]
    [TestCase(19, 16, 21)]
    [TestCase(12, 1, 21)]
    [TestCase(23, 21, 30)]
    [TestCase(23, 23, 30)]
    [TestCase(12, 23, 8)]
    [TestCase(19, 19, 23)]
    public void FindLowestCommonAncestor_WithExistingNodes_ReturnsCorrectAncestor(int expected, int firstNode, int secondNode)
    {
        Assert.AreEqual(expected, this.binaryTree.FindLowestCommonAncestor(firstNode, secondNode));
    }

    [Test]
    [TestCase(5, 54)]
    [TestCase(54, 5)]
    [TestCase(51, 54)]
    public void FindLowestCommonAncestor_WithInvalidNode_ThrowsException(int firstNode, int secondNode)
    {
        Assert.Throws<InvalidOperationException>(() => this.binaryTree.FindLowestCommonAncestor(firstNode, secondNode));
    }
}
