using System.Collections.Generic;

using NUnit.Framework;

namespace _01.RedBlackTree.Tests.CorrectnessTests
{
    [TestFixture]
    public class InsertSecond
    {
        [Test]
        public void Insert_MultipleElements_ShouldBeInsertedCorrectly()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(5);
            rbt.Insert(12);
            rbt.Insert(18);
            rbt.Insert(37);
            rbt.Insert(48);
            rbt.Insert(60);
            rbt.Insert(80);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);

            // Assert
            int[] expectedNodes = { 5, 12, 18, 37, 48, 60, 80 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
    }
}
