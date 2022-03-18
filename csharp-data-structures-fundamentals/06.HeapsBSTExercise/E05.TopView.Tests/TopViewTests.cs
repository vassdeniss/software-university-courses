using NUnit.Framework;
using E05.TopView;
using System.Linq;

public class Tests
{
    [Test]
    public void TestFirstTopView()
    {
        var binaryTree =
            new BinaryTree<int>(1,
                    new BinaryTree<int>(2,
                            new BinaryTree<int>(4, null, null),
                            new BinaryTree<int>(5, null, null)),
                    new BinaryTree<int>(3,
                            new BinaryTree<int>(6, null, null),
                            new BinaryTree<int>(7, null, null)));

        var topViewActual = binaryTree.TopView()
            .OrderBy(n => n)
            .ToArray();

        int[] topViewExpected = { 1, 2, 3, 4, 7 };

        Assert.AreEqual(topViewExpected.Length, topViewActual.Length);
        for (int i = 0; i < topViewExpected.Length; i++)
        {
            Assert.AreEqual(topViewExpected[i], topViewActual[i]);
        }
    }

    [Test]
    public void TestSecondTopView()
    {
        var binaryTree =
          new BinaryTree<int>(1,
                  new BinaryTree<int>(2,
                          new BinaryTree<int>(4, null, null),
                          new BinaryTree<int>(5, null, null)),
                  new BinaryTree<int>(3, null, null));

        var topViewActual = binaryTree.TopView()
            .OrderBy(n => n)
            .ToArray();

        int[] topViewExpected = { 1, 2, 3, 4 };

        Assert.AreEqual(topViewExpected.Length, topViewActual.Length);
        for (int i = 0; i < topViewExpected.Length; i++)
        {
            Assert.AreEqual(topViewExpected[i], topViewActual[i]);
        }
    }

    [Test]
    public void TestThirdTopView()
    {
        var binaryTree =
          new BinaryTree<int>(1,
                  new BinaryTree<int>(2, null, null),
                  new BinaryTree<int>(3,
                            new BinaryTree<int>(6, null, null),
                            new BinaryTree<int>(7, null, null)));

        var topViewActual = binaryTree.TopView()
            .OrderBy(n => n)
            .ToArray();

        int[] topViewExpected = { 1, 2, 3, 7 };

        Assert.AreEqual(topViewExpected.Length, topViewActual.Length);
        for (int i = 0; i < topViewExpected.Length; i++)
        {
            Assert.AreEqual(topViewExpected[i], topViewActual[i]);
        }
    }
}
