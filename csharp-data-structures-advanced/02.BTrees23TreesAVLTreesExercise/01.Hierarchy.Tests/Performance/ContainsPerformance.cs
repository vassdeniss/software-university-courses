using NUnit.Framework;

using System.Diagnostics;

namespace _01.Hierarchy.Tests.Performance
{
    public class ContainsPerformance
    {
        [Test]
        public void PerformanceContains_With50000LookUpsInReversedOrderWith50000ElementsWith1Parent()
        {
            Hierarchy<int> hierarchy = new Hierarchy<int>(-3);

            for (int i = 1; i < 50001; i++)
            {
                hierarchy.Add(-3, i);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 50000; i > 0; i--)
            {
                Assert.IsTrue(hierarchy.Contains(i), "Contains method returned wrong value!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 50);
        }


        [Test]
        public void PerformanceContains_With25000ExistingAnd25000NonexistentElements()
        {
            Hierarchy<int> hierarchy = new Hierarchy<int>(-1);

            for (int i = 1; i < 50001; i = i + 2)
            {
                hierarchy.Add(i - 2, i);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 1; i < 50001; i = i + 2)
            {
                Assert.IsTrue(hierarchy.Contains(i), "Contains method returned wrong value!");
                Assert.IsFalse(hierarchy.Contains(i + 1), "Contains method returned wrong value!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100);
        }
    }
}
