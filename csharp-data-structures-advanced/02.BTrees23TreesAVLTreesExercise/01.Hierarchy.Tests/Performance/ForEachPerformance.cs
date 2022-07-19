using NUnit.Framework;

using System.Collections.Generic;
using System.Diagnostics;

namespace _01.Hierarchy.Tests.Performance
{
    public class ForEachPerformance
    {
        [Test]
        public void PerformanceForEach_With55500Elements()
        {
            int start1 = 0;
            int start2 = 5000;
            int start3 = 100000;
            List<int> elements = new List<int>();
            elements.Add(start1);
            Hierarchy<int> hierarchy = new Hierarchy<int>(start1);

            for (int i = 1; i <= 500; i++)
            {
                elements.Add(i);
                hierarchy.Add(start1, i);
                for (int j = 0; j < 10; j++)
                {
                    elements.Add(start2);
                    hierarchy.Add(i, start2);
                    for (int k = 0; k < 10; k++)
                    {
                        elements.Add(start3);
                        hierarchy.Add(start2, start3++);
                    }
                    start2++;
                }
            }

            elements.Sort();
            int counter = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            foreach (int element in hierarchy)
            {
                Assert.AreEqual(elements[counter++], element, "Expected element did not match!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);

            Assert.AreEqual(counter, hierarchy.Count, "Incorect number of elements returned!");
        }

        [Test]
        public void PerformanceForEach_With55500ElementsInterconnected()
        {
            int start1 = 0;
            List<int> elements = new List<int>();
            elements.Add(start1);
            Hierarchy<int> hierarchy = new Hierarchy<int>(start1);

            for (int i = 1; i <= 51100; i = i + 511)
            {
                hierarchy.Add(start1, i);
                for (int j = i + 1; j <= i + 510; j = j + 51)
                {
                    hierarchy.Add(i, j);
                    for (int k = j + 1; k <= j + 50; k++)
                    {
                        hierarchy.Add(j, k);
                    }
                }
            }

            for (int i = 1; i <= 51100; i = i + 511)
            {
                elements.Add(i);
            }

            for (int i = 1; i <= 51100; i = i + 511)
            {
                for (int j = i + 1; j <= i + 510; j = j + 51)
                {
                    elements.Add(j);
                }
            }

            for (int i = 1; i <= 51100; i = i + 511)
            {
                for (int j = i + 1; j <= i + 510; j = j + 51)
                {
                    for (int k = j + 1; k <= j + 50; k++)
                    {
                        elements.Add(k);
                    }
                }
            }

            int counter = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            foreach (int element in hierarchy)
            {
                Assert.AreEqual(elements[counter++], element, "Expected element did not match!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 400);

            Assert.AreEqual(counter, hierarchy.Count, "Incorect number of elements returned!");
        }
    }
}
