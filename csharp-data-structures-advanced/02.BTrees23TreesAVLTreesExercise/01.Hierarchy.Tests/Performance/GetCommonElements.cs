using NUnit.Framework;

using System.Diagnostics;
using System.Linq;

namespace _01.Hierarchy.Tests.Performance
{
    public class GetCommonElements
    {
        [Test]
        public void PerformanceGetCommonElements_WithNoCommonElements()
        {
            int start1 = 0;
            int start2 = 100000;
            Hierarchy<int> hierarchy = new Hierarchy<int>(start1);
            Hierarchy<int> hierarchy2 = new Hierarchy<int>(start2);

            for (int i = 1; i <= 50000; i++)
            {
                hierarchy.Add(start1, i);
                hierarchy2.Add(start2, start2 + i);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            CollectionAssert.AreEqual(new int[0], hierarchy.GetCommonElements(hierarchy2).ToArray(), "GetCommonElements method returned incorrect collection!");

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }

        [Test]
        public void PerformanceGetCommonElements_WithHalfCommonElementsInBothCollections()
        {
            int start1 = 0;
            int start2 = 75000;
            Hierarchy<int> hierarchy = new Hierarchy<int>(start1);
            Hierarchy<int> hierarchy2 = new Hierarchy<int>(start2);

            for (int i = 1; i <= 50000; i++)
            {
                hierarchy.Add(start1, i);
            }

            for (int i = start2 - 1; i > 25000; i--)
            {
                hierarchy2.Add(start2, i);
            }

            int[] common = Enumerable.Range(25001, 25000).ToArray();

            Stopwatch timer = new Stopwatch();
            timer.Start();

            CollectionAssert.AreEqual(common, hierarchy.GetCommonElements(hierarchy2).ToArray(), "GetCommonElements method returned incorrect collection!");

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }
    }
}
