﻿using NUnit.Framework;

namespace _01.RedBlackTree.Tests.TimeTests
{
    [TestFixture]
    public class FifthTest
    {
        [Test]
        [Timeout(600)]
        public void Insert_MultipleElements_ShouldHaveQuickFind()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            for (int i = 0; i < 100_000; i++)
            {
                rbt.Insert(i);
            }

            Assert.AreEqual(true, rbt.Contains(99_999));
        }
    }
}
