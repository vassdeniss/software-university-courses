using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarManager.Tests
{
    [TestFixture]
    public class CarManagerTests
    {
        [TestCaseSource("ConstructorInvalidCases")]
        public void Constructor_With_Invalid_Data_Should_Throw_Argument_Exception_For_Each_Invalid_Argument(string make, string model, double consume, double capacity)
        {
            TestDelegate act = () => new Car(make, model, consume, capacity);
            string failureMessage = "Passing in invalid arguments should throw their respective messages.";

            Assert.Throws<ArgumentException>(act, failureMessage);
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_With_Invalid_Number_Should_Throw_Argument_Exception(double amount)
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            TestDelegate act = () => car.Refuel(amount);

            string failureMessage = "Refueling with a number lower or equal to zero should not be possible and should throw argument exception.";
            Assert.Throws<ArgumentException>(act, failureMessage);
        }

        [TestCase(15)]
        [TestCase(29.99)]
        public void Refuel_Car_Should_Refuel_Correctly(double amount)
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            car.Refuel(amount);

            double expected = amount;
            double actual = car.FuelAmount;

            string failureMessage = "Refueling should increase cars' fuel capacity correctly.";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        [Test]
        public void Refuel_Car_Higher_Than_Max_Should_Be_Set_To_Max()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            car.Refuel(50);

            double expected = car.FuelCapacity;
            double actual = car.FuelAmount;

            string failureMessage = "Refueling above the cars' max fuel capacity should set the fuel amount to the cars' max fuel capacity.";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        [Test]
        public void Drive_Car_Without_Enough_Fuel_Should_Throw_Invalid_Operation_Exception()
        {
            Car car = new Car("Ferrari", "812 GTS", 10, 30);
            double distance = 310;

            TestDelegate act = () => car.Drive(distance);

            string failureMessage = "Driving a car X amount of kilometers without enough fuel whould throw an invalid operation exception";
            Assert.Throws<InvalidOperationException>(act, failureMessage);
        }

        [Test]
        public void Drive_Car_Wit_Enough_Fuel_Should_Subtract_Correctly_From_Total_Fuel()
        {
            Car car = new Car("Ferrari", "812 GTS", 10, 30);
            double distance = 290;

            car.Refuel(30);
            car.Drive(distance);

            double expected = 1;
            double actual = car.FuelAmount;

            string failureMessage = "Driving a car X amount of kilometers with enough fuel should subtract that fuel from the total fuel.";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        [Test]
        public void Make_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            string expected = "Ferrari";
            string actual = car.Make;

            string failureMessage = "Make should return correct field";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        [Test]
        public void Model_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            string expected = "812 GTS";
            string actual = car.Model;

            string failureMessage = "Model should return correct field";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        [Test]
        public void Consume_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            double expected = 4;
            double actual = car.FuelConsumption;

            string failureMessage = "Fuel consumption should return correct field";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        [Test]
        public void Capacity_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            double expected = 30;
            double actual = car.FuelCapacity;

            string failureMessage = "Fuel capacity should return correct field";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        [Test]
        public void Amount_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            double expected = 0;
            double actual = car.FuelAmount;

            string failureMessage = "Fuel amount should return correct field";
            Assert.AreEqual(expected, actual, failureMessage);
        }

        public static IEnumerable<TestCaseData> ConstructorInvalidCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData("", "Model S", 20, 300),
                new TestCaseData(null, "812 GTS", 100.35, 500.12),
                new TestCaseData("Tesla", "", 20, 300),
                new TestCaseData("Ferrari", null, 100, 500),
                new TestCaseData("Tesla", "Model S", 0, 300),
                new TestCaseData("Ferrari", "812 GTS", -20, 500.57),
                new TestCaseData("Tesla", "Model S", 321, -800),
                new TestCaseData("Ferrari", "812 GTS", 4.0, 0)
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }
    }
}
