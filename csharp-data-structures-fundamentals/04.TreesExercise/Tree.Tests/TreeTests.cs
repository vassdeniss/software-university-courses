namespace Tree.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Tree;

    public class TreeTests
    {
        private TreeFactory _treeFactory;
        private Tree<int> _tree;


        [SetUp]
        public void InitializeFactoryAndTree()
        {
            string[] input = new string[]
            {
                "7 19",
                "7 21",
                "7 14",
                "19 1",
                "19 12",
                "19 31",
                "14 23",
                "14 6"
            };

            this._treeFactory = new TreeFactory();
            this._tree = this._treeFactory.CreateTreeFromStrings(input);
        }

        [Test]
        public void TreeCreationShouldWorkSuccessfuly()
        {
            Assert.AreEqual(7, this._tree.Key);
            Assert.NotNull(this._tree.Children);
            Assert.AreEqual(3, this._tree.Children.Count);
        }

        [Test]
        public void TreeAsStringShouldWorkCorrectly()
        {
            string expectedOutput = "7\r\n" +
                "  19\r\n" +
                "    1\r\n" +
                "    12\r\n" +
                "    31\r\n" +
                "  21\r\n" +
                "  14\r\n" +
                "    23\r\n" +
                "    6";

            Assert.AreEqual(expectedOutput, this._tree.GetAsString());
        }

        [Test]
        public void TreeGetLeafKeysShouldWorkCorrectly()
        {
            int[] expected = new int[] { 1, 6, 12, 21, 23, 31 };
            List<int> leafKeys = this._tree.GetLeafKeys()
                .OrderBy(leaf => leaf)
                .ToList();


            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], leafKeys[i]);
            }
        }

        [Test]
        public void TreeMiddleNodesShouldWorkCorrectly()
        {
            int[] expected = new int[] { 14, 19 };
            List<int> middleKeys = this._tree.GetMiddleKeys()
                .OrderBy(leaf => leaf)
                .ToList();


            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], middleKeys[i]);
            }
        }

        [Test]
        public void TreeDeepestLeftmostNodeShouldWorkCorrectly()
        {
            // Nice typo softuni ;d
            Tree<int> deepestNode = this._tree.GetDeepestLeftomostNode();

            Assert.AreEqual(1, deepestNode.Key);
        }


        [Test]
        public void TreeLeftmostLongestPathShouldWorkCorrectly()
        {
            int[] expectedPath = new int[] { 7, 19, 1 };
            List<int> longestLeftmostPath = this._tree.GetLongestPath();

            for (int i = 0; i < expectedPath.Length; i++)
            {
                Assert.AreEqual(expectedPath[i], longestLeftmostPath[i]);
            }
        }

        [Test]
        public void TreePathsWithGivenSumShouldWorkCorrectly()
        {
            int[,] expected = new int[,]
            {
                { 7, 19, 1 },
                { 7, 14, 6 }
            };

            List<List<int>> paths = this._tree.PathsWithGivenSum(27);

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], paths[i][j]);
                }
            }
        }

        [Test]
        public void TreeAllSubtreesWithGivenSumShouldWorkCorrectly()
        {
            List<Tree<int>> subtrees = this._tree.SubTreesWithGivenSum(43);
            Assert.AreEqual(1, subtrees.Count);
            string treeAsString = subtrees[0].GetAsString();
            Assert.IsTrue(treeAsString.Contains("14"));
            Assert.IsTrue(treeAsString.Contains("23"));
            Assert.IsTrue(treeAsString.Contains("6"));
        }
    }
}
