using System;

using NUnit.Framework;

namespace _02.Two_Three.Tests
{
    public class TwoThreeTreeTests
    {
        [Test]
        public void TestInsertZero()
        {
            TwoThreeTree<string> tree = new TwoThreeTree<string>();
            Assert.AreEqual("", tree.ToString());
        }

        [Test]
        public void TestInsertSingle()
        {
            TwoThreeTree<string> tree = new TwoThreeTree<string>();
            tree.Insert("13");

            Assert.AreEqual("13 " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsertMany()
        {
            TwoThreeTree<string> tree = new TwoThreeTree<string>();
            tree.Insert("A");
            tree.Insert("B");
            tree.Insert("C");
            Assert.AreEqual("B " + Environment.NewLine +
                            "A " + Environment.NewLine +
                            "C " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsert13Elements()
        {
            TwoThreeTree<string> tree = new TwoThreeTree<string>();

            string[] arr = { "F", "C", "G", "A", "B", "D", "E", "K", "I", "G", "H", "J", "K" };
            for (int i = 0; i < 13; i++)
            {
                tree.Insert(arr[i]);
            }

            Assert.AreEqual("D G" + Environment.NewLine +
                            "B " + Environment.NewLine +
                            "A " + Environment.NewLine +
                            "C " + Environment.NewLine +
                            "F " + Environment.NewLine +
                            "E " + Environment.NewLine +
                            "G " + Environment.NewLine +
                            "I K" + Environment.NewLine +
                            "H " + Environment.NewLine +
                            "J " + Environment.NewLine +
                            "K " + Environment.NewLine, tree.ToString());
        }
    }
}
