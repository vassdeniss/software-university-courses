using INStock.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Tests
{
    public class ProductStockTests
    {
        private IProductStock stock;
        private Mock<IProduct> mock;

        [SetUp]
        public void SetUp()
        {
            stock = new ProductStock();
            mock = new Mock<IProduct>();
            mock.Setup(x => x.Label).Returns("fake");
            mock.Setup(x => x.Price).Returns(1);
        }

        [Test]
        public void Test_Add__Should_Add_Correctly([Values(0, 5, 20, 1000)] int qty)
        {
            for (int i = 0; i < qty; i++)
            {
                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(2m);
                fake.Setup(x => x.Quantity).Returns(2);

                stock.Add(fake.Object);
            }

            Assert.AreEqual(qty, stock.Count, "Collections count mismatches with actual count.");
        }

        [TestCaseSource(nameof(AddInvalidCases))]
        public void Test_Add_Invalid_Data_Should_Throw_Invalid_Operation_Exception(string label, decimal price, int qty)
        {
            Mock<IProduct> fake = new Mock<IProduct>();
            fake.Setup(x => x.Label).Returns(label);
            fake.Setup(x => x.Price).Returns(price);
            fake.Setup(x => x.Quantity).Returns(qty);

            Assert.Throws<InvalidOperationException>(() => stock.Add(fake.Object), "Cannot add invalid elements to the list.");
        }

        [Test]
        public void Test_Index_Getter_Should_Return_Correct_Element([Values(0, 5, 19)] int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i == idx + 1)
                {
                    stock.Add(mock.Object);
                    continue;
                }

                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(2m);
                fake.Setup(x => x.Quantity).Returns(2);

                stock.Add(fake.Object);
            }

            Assert.AreEqual(mock.Object, stock[idx], "Getting an index did not return the correct number.");
        }

        [Test]
        public void Test_Index_Getter_Invalid_Range_Should_Throw_Argument_Out_Of_Range_Exception([Values(-1, 20)] int idx)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i == idx)
                {
                    stock.Add(mock.Object);
                    continue;
                }

                Mock<IProduct> toAdd = new Mock<IProduct>();
                toAdd.Setup(x => x.Label).Returns("fakeAdd");
                toAdd.Setup(x => x.Price).Returns(100);
                stock.Add(toAdd.Object);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IProduct throws = stock[idx];
            }, "Cannot get an index that is outside of the expected range.");
        }

        [Test]
        public void Test_Index_Setter_Should_Set_Correct_Element()
        {
            Mock<IProduct> fake = new Mock<IProduct>();
            fake.Setup(x => x.Label).Returns("fakeAdd");
            fake.Setup(x => x.Price).Returns(100);
            stock.Add(fake.Object);

            stock[0] = mock.Object;

            Assert.AreEqual(mock.Object, stock[0], "Setter is not setting the element properly.");
        }

        [Test]
        public void Test_Index_Setter_Invalid_Range_Should_Throw_Argument_Out_Of_Range_Exception(
            [Values(-1, 1, 8, -5, int.MinValue, int.MaxValue)] int index)
        {
            stock.Add(mock.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                stock[index] = new Mock<IProduct>().Object;
            }, "Cannot set an index that is outside of the expected range.");
        }

        [TestCase(0, false)]
        [TestCase(5, false)]
        [TestCase(5, true, true)]
        public void Test_Contains_Should_Work_Correctly(int qty, bool expected, bool includeDefault = false)
        {
            for (int i = 1; i <= qty; i++)
            {
                if (includeDefault)
                {
                    stock.Add(mock.Object);
                    continue;
                }

                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(2m);
                fake.Setup(x => x.Quantity).Returns(2);

                stock.Add(fake.Object);
            }

            Assert.AreEqual(expected, stock.Contains(mock.Object), "Contains not returning correct boolean.");
        }

        [Test]
        public void Test_Find_Returns_Correct_Element([Values(5, 0, 9)] int idx)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i == idx + 1)
                {
                    stock.Add(mock.Object);
                    continue;
                }

                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(2m);
                fake.Setup(x => x.Quantity).Returns(2);

                stock.Add(fake.Object);
            }

            Assert.AreEqual(mock.Object, stock.Find(idx), "Element at index is not the one expected.");
        }

        [Test]
        public void Test_Find_Invalid_Should_Throw_Invalid_Operation_Exception([Values(10, 0, 5)] int qty)
        {
            for (int i = 1; i <= qty; i++)
            {
                stock.Add(mock.Object);
            }

            Assert.Throws<InvalidOperationException>(() => stock.Find(qty), "Index is not supposed to exist in the list.");
        }

        [TestCaseSource(nameof(FindAllByPriceCases))]
        public void Test_Find_All_By_Price_Should_Work_Properly(decimal price)
        {
            List<IProduct> expected = new List<IProduct>();

            for (int i = 1; i <= 10; i++)
            {
                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(i);
                fake.Setup(x => x.Quantity).Returns(2);
                stock.Add(fake.Object);

                Mock<IProduct> fakeTwo = new Mock<IProduct>();
                fakeTwo.Setup(x => x.Label).Returns($"itemDual{i}");
                fakeTwo.Setup(x => x.Price).Returns(i);
                fakeTwo.Setup(x => x.Quantity).Returns(2);
                stock.Add(fakeTwo.Object);

                if (i == price)
                {
                    expected.Add(fake.Object);
                    expected.Add(fakeTwo.Object);
                }
            }

            CollectionAssert.AreEqual(expected, stock.FindAllByPrice(price), "Expected collection not recieved.");
        }

        [TestCaseSource(nameof(FindAllByQuantityCases))]
        public void Test_Find_All_By_Quantity_Should_Work_Properly(int qty)
        {
            List<IProduct> expected = new List<IProduct>();

            for (int i = 1; i <= 10; i++)
            {
                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(2m);
                fake.Setup(x => x.Quantity).Returns(i);
                stock.Add(fake.Object);

                Mock<IProduct> fakeTwo = new Mock<IProduct>();
                fakeTwo.Setup(x => x.Label).Returns($"itemDual{i}");
                fakeTwo.Setup(x => x.Price).Returns(2m);
                fakeTwo.Setup(x => x.Quantity).Returns(i);
                stock.Add(fakeTwo.Object);

                if (i == qty)
                {
                    expected.Add(fake.Object);
                    expected.Add(fakeTwo.Object);
                }
            }

            CollectionAssert.AreEqual(expected, stock.FindAllByQuantity(qty), "Expected collection not recieved.");
        }

        [TestCaseSource(nameof(FindAllInRangeCases))]
        public void Test_Find_All_In_Range_Should_Work_Properly(decimal low, decimal high, int expected)
        {
            for (int i = 1; i <= 10; i++)
            {
                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(i);
                fake.Setup(x => x.Quantity).Returns(2);
                stock.Add(fake.Object);
            }

            List<IProduct> list = stock.FindAllInRange(low, high).ToList();

            Assert.AreEqual(expected, list.Count, "Expected elements not recieved.");
        }

        [Test]
        public void Test_Find_By_Label_Should_Return_Correct_Element()
        {
            stock.Add(mock.Object);

            Assert.AreEqual(mock.Object, stock.FindByLabel(mock.Object.Label), "Find by laebl did not return expected element.");
        }

        [Test]
        public void Test_Find_By_Label_Invalid_Should_Throw_Argument_Exception()
        {
            stock.Add(mock.Object);

            Assert.Throws<ArgumentException>(() => stock.FindByLabel("Savex"), "Find by laebl cannot return an element which does not exist.");
        }

        [Test]
        public void Test_Find_Most_Expensive_Product_Should_Return_Correct_Element([Values(10, 20)] int qty)
        {
            Mock<IProduct> expected = null;

            for (int i = 1; i <= qty; i++)
            {
                Mock<IProduct> fake = new Mock<IProduct>();
                fake.Setup(x => x.Label).Returns($"item{i}");
                fake.Setup(x => x.Price).Returns(i);
                fake.Setup(x => x.Quantity).Returns(2);

                if (i == qty) expected = fake;

                stock.Add(fake.Object);
            }

            Assert.AreEqual(expected.Object, stock.FindMostExpensiveProduct(), "Find most expensive product did not return expected element.");
        }

        [Test]
        public void Test_Find_Most_Expensive_Product_Invalid_Should_Return_Null()
        {
            Assert.Throws<InvalidOperationException>(() => stock.FindMostExpensiveProduct(), "Find most expensive product has to throw on empty collection.");
        }

        [Test]
        public void Test_Remove_Should_Work_Properly()
        {
            stock.Add(mock.Object);

            Assert.True(stock.Remove(mock.Object), "Existing element is not getting removed properly.");
        }

        [Test]
        public void Test_Remove_Empty_Should_Work_Properly()
        {
            Assert.False(stock.Remove(mock.Object), "Removing cannot work on an empty collection.");
        }

        private static IEnumerable<TestCaseData> FindAllByQuantityCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(0),
                new TestCaseData(5),
                new TestCaseData(10),
                new TestCaseData(15),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        private static IEnumerable<TestCaseData> FindAllByPriceCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(0m),
                new TestCaseData(5m),
                new TestCaseData(10m),
                new TestCaseData(15m),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        private static IEnumerable<TestCaseData> FindAllInRangeCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(0m, 5m, 5),
                new TestCaseData(7m, 15m, 4),
                new TestCaseData(-20m, 0m, 0),
                new TestCaseData(10m, 20m, 1),
                new TestCaseData(1m, 10m, 10),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        private static IEnumerable<TestCaseData> AddInvalidCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData("", 2m, 2),
                new TestCaseData(" ", 2m, 2),
                new TestCaseData(null, 2m, 2),
                new TestCaseData("item", -100.20m, 2),
                new TestCaseData("item", 0m, 2),
                new TestCaseData("item", 2m, -200)
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }
    }
}
