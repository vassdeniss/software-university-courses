using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace E06.Collection.Tests
{
    public class CollectionTests
    {
        private Collection<int> collection;

        [SetUp]
        public void SetUp()
        {
            collection = new Collection<int>();
        }

        [TestCaseSource(nameof(ConstructorCases))]
        public void Test_Constructor_Should_Initialize_Correctly(int[] arr, int expected)
        {
            Collection<int> collection = new Collection<int>(arr);

            Assert.AreEqual(expected, collection.Capacity, "Collection count does not match.");
            Assert.AreEqual(arr.Length, collection.Count, "Collection capacity does not match.");
        }

        [Test]
        public void Test_Add_Should_Add_Elements_Correctly()
        {
            collection.Add(10);
            collection.Add(20);
            collection.Add(30);

            Assert.AreEqual(3, collection.Count, "Collections count mismatches with actual count.");
            Assert.True(collection.Capacity >= collection.Count, "Count overshot the collections capacity.");
        }

        [Test]
        public void Test_AddRange_Should_Add_Elements_Correctly()
        {
            int[] arr = new int[] { 10, 20, 30, 40, 50 };
            collection.AddRange(arr);

            Assert.AreEqual(5, collection.Count, "Collections count mismatches with actual count.");
            Assert.True(collection.Capacity >= collection.Count, "Count overshot the collections capacity.");
        }

        [Test]
        public void Test_Enqueue_Overflow_Should_Grow_Correctly()
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            Assert.AreEqual(20, collection.Count, "Collections count mismatches with actual count.");
            Assert.AreEqual(32, collection.Capacity, "Grow did not multiply correctly.");
        }

        [Test]
        public void Test_Index_Getter_Should_Return_Correct_Element([Values(0, 5, 19)] int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            Assert.AreEqual(idx + 1, collection[idx], "Getting an index did not return the correct number.");
        }

        [Test]
        public void Test_Index_Getter_Invalid_Range_Should_Throw_Argument_Out_Of_Range_Exception([Values(-1, 20)] int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int throws = collection[idx];
            }, "Cannot get an index that is outside of the expected range.");
        }

        [Test]
        public void Test_Index_Setter_Should_Set_Correct_Element()
        {
            collection.Add(1);
            collection[0] = 5;

            Assert.AreEqual(5, collection[0]);
        }

        [Test]
        public void Test_Index_Setter_Invalid_Range_Should_Throw_Argument_Out_Of_Range_Exception(
            [Values(-1, 1, 8, -5, int.MinValue, int.MaxValue)] int index)
        {
            collection.Add(10);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                collection[index] = 5;
            }, "Cannot set an index that is outside of the expected range.");
        }

        [Test]
        public void Test_Insert_At_Invalid_Range_Should_Throw_Argument_Out_Of_Range_Exception([Values(-1, 21)] int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(
                () => collection.InsertAt(idx, 5),
                "Cannot insert element at index that is not inside rangee.");
        }

        [TestCase(10, 4, 2134, 16, 11)]
        [TestCase(16, 0, 35, 32, 17)]
        [TestCase(20, 20, 100, 32, 21)]
        public void Test_Insert_At_Should_Insert_Correctly(
            int toAdd,
            int insertIdx,
            int element,
            int expectedSize,
            int expectedCount)
        {
            for (int i = 1; i <= toAdd; i++)
            {
                collection.Add(i);
            }

            collection.InsertAt(insertIdx, element);

            Assert.AreEqual(element, collection[insertIdx], "Insert element at index does not insert properly.");
            Assert.AreEqual(expectedSize, collection.Capacity, "Capacity does not match.");
            Assert.AreEqual(expectedCount, collection.Count, "Count does not match.");
        }

        [Test]
        public void Test_Exchange_Invalid_Should_Throw_Argument_Out_Of_Range_Exception([Values(-10, 20)] int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => collection.Exchange(idx, 5), "Index one was out of the expected range.");
            Assert.Throws<ArgumentOutOfRangeException>(() => collection.Exchange(5, idx), "Index two was out of the expected range.");
        }

        [TestCase(0, 19)]
        [TestCase(5, 12)]
        public void Test_Exchange_Should_Exchange_Correctly(int idx1, int idx2)
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            int first = collection[idx1];
            int second = collection[idx2];

            collection.Exchange(idx1, idx2);

            string failureMessage = "Exchange was not done properly.";
            Assert.AreEqual(first, collection[idx2], failureMessage);
            Assert.AreEqual(second, collection[idx1], failureMessage);
        }

        [Test]
        public void Test_Remove_At_Invalid_Should_Throw_Argument_Out_Of_Range_Exception([Values(-10, 20)] int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            string failureMessage = "Index was out of the expected range.";
            Assert.Throws<ArgumentOutOfRangeException>(() => collection.RemoveAt(idx), failureMessage);
            Assert.Throws<ArgumentOutOfRangeException>(() => collection.RemoveAt(idx), failureMessage);
        }

        [TestCase(0)]
        [TestCase(19)]
        [TestCase(5)]
        public void Test_Remove_At_Should_Remove_Correctly(int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                collection.Add(i);
            }

            int expected = collection[idx];
            int actual = collection.RemoveAt(idx);

            Assert.AreEqual(expected, actual, "Remove at was not done properly.");
            Assert.AreEqual(19, collection.Count, "Count does not match.");
        }

        [Test]
        public void Test_Clear_Should_Set_Count_To_Zero()
        {
            collection.Clear();

            Assert.AreEqual(0, collection.Count, "Clear does not clear the collection properly.");
        }

        [TestCaseSource(nameof(StringCases))]
        public void Test_To_String_Should_Return_Correct_String(int[] nums, string expected)
        {
            collection.AddRange(nums);

            Assert.AreEqual(expected, collection.ToString(), "ToString does not return correct string.");
        }

        private static IEnumerable<TestCaseData> ConstructorCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new int[] {  }, 16),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50 }, 16),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50, 60, 70, 80 }, 16),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 }, 20),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        private static IEnumerable<TestCaseData> StringCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new int[] {  }, "[]"),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50 }, "[10, 20, 30, 40, 50]"),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }, "[10, 20, 30, 40, 50, 60, 70, 80, 90]"),
                new TestCaseData(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180 }, "[10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180]")
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }
    }
}
