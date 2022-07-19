using System.Diagnostics;

using NUnit.Framework;

namespace _01.Hierarchy.Tests.Performance
{
    public class GetParentPerformance
    {
        [Test]
        public void PerformanceGetParent_With50000ElementsWith1ParentInReversedOrder()
        {
            Hierarchy<int> hierarchy = new Hierarchy<int>(0);

            for (int i = 1; i < 50001; i++)
            {
                hierarchy.Add(0, i);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 50000; i > 0; i--)
            {
                Assert.AreEqual(0, hierarchy.GetParent(i), "Expected parent did not match!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);
        }

        [Test]
        public void PerformanceGetParent_With50000ElementsWith5000Parents()
        {
            int counter = 5001;
            Hierarchy<int> hierarchy = new Hierarchy<int>(-88);
            for (int i = 1; i <= 5000; i++)
            {
                hierarchy.Add(-88, i);
                for (int j = 0; j < 10; j++)
                {
                    hierarchy.Add(i, counter++);
                }
            }

            counter = 5001;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 1; i <= 5000; i++)
            {
                Assert.AreEqual(-88, hierarchy.GetParent(i), "Expected parent did not match!");
                for (int j = 0; j < 10; j++)
                {
                    Assert.AreEqual(i, hierarchy.GetParent(counter++), "Expected parent did not match!");
                }
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }
    }
}
