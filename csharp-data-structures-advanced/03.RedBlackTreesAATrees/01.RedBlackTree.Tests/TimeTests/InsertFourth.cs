using NUnit.Framework;

namespace _01.RedBlackTree.Tests.TimeTests
{
    [TestFixture]
    public class InsertFourth
    {
        [Test]
        [Timeout(500)]
        public void Insert_MultipleElements_ShouldBeFast()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            for (int i = 0; i < 100_000; i++)
            {
                rbt.Insert(i);
            }
        }
    }
}
