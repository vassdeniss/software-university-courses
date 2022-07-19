using NUnit.Framework;

using System.Diagnostics;
using System.Linq;

namespace _01.Hierarchy.Tests.Performance
{
    public class AddPerformance
    {
        [Test]
        public void PerformanceAdd_WithOnly2ParentWith50000SplitElements()
        {
            int count = 3;
            int counter1 = 1;
            int counter2 = 25001;
            Hierarchy<int> hierarchy = new Hierarchy<int>(-1);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            hierarchy.Add(-1, 1);
            hierarchy.Add(-1, 25001);
            for (int i = 1; i < 25000; i++)
            {
                hierarchy.Add(1, ++counter1);
                hierarchy.Add(25001, ++counter2);
                count += 2;
                Assert.AreEqual(count, hierarchy.Count, "Count did not increase correctly!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
            counter1 = 1;
            counter2 = 25001;
            for (int i = 1; i < 25000; i++)
            {
                Assert.AreEqual(1, hierarchy.GetParent(++counter1), "Parent did not match!");
                Assert.AreEqual(25001, hierarchy.GetParent(++counter2), "Parent did not match!");
            }

            CollectionAssert.AreEqual(Enumerable.Range(2, 24999).ToArray(), hierarchy.GetChildren(1).ToArray(), "Children did not match!");
            CollectionAssert.AreEqual(Enumerable.Range(25002, 24999).ToArray(), hierarchy.GetChildren(25001).ToArray(), "Children did not match!");
        }

        [Test]
        public void PerformanceAdd_With40000ElementsInReverseOrderIn4Groups()
        {
            int counter1 = 10000;
            int counter2 = 30000;
            int counter3 = 50000;
            int counter4 = 70000;
            int count = 5;
            Hierarchy<int> hierarchy = new Hierarchy<int>(100000);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            hierarchy.Add(100000, 10000);
            hierarchy.Add(100000, 30000);
            hierarchy.Add(100000, 50000);
            hierarchy.Add(100000, 70000);
            for (int i = 1; i < 10000; i++)
            {
                hierarchy.Add(counter1, --counter1);
                hierarchy.Add(counter2, --counter2);
                hierarchy.Add(counter3, --counter3);
                hierarchy.Add(counter4, --counter4);
                count += 4;
                Assert.AreEqual(count, hierarchy.Count, "Count did not increase correctly!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);

            counter1 = 1;
            counter2 = 20001;
            counter3 = 40001;
            counter4 = 60001;
            for (int i = 1; i < 10000; i++)
            {
                Assert.AreEqual(counter1 + 1, hierarchy.GetParent(counter1), "Parent did not match!");
                Assert.AreEqual(counter2 + 1, hierarchy.GetParent(counter2), "Parent did not match!");
                Assert.AreEqual(counter3 + 1, hierarchy.GetParent(counter3), "Parent did not match!");
                Assert.AreEqual(counter4 + 1, hierarchy.GetParent(counter4), "Parent did not match!");
                Assert.AreEqual(counter1, hierarchy.GetChildren(counter1 + 1).FirstOrDefault(), "Children did not match!");
                Assert.AreEqual(counter2, hierarchy.GetChildren(counter2 + 1).FirstOrDefault(), "Children did not match!");
                Assert.AreEqual(counter3, hierarchy.GetChildren(counter3 + 1).FirstOrDefault(), "Children did not match!");
                Assert.AreEqual(counter4, hierarchy.GetChildren(counter4 + 1).FirstOrDefault(), "Children did not match!");
                counter1++;
                counter2++;
                counter3++;
                counter4++;
            }
        }
    }
}
