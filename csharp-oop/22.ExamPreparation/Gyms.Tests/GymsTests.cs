using System;

using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Test_Constructor_Should_Initialise_Correctly()
        {
            string name = "BestGym";
            int size = 50;

            Gym gym = new Gym(name, size);

            Assert.AreEqual(name, gym.Name, "Name does not match.");
            Assert.AreEqual(size, gym.Capacity, "Capacity does not match.");
            Assert.AreEqual(0, gym.Count, "Collection not initialised.");
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_Constructor_Invalid_Name_Should_Throw_Argument_Null_Exception(string name)
        {
            Assert.Throws<ArgumentNullException>(
                () => new Gym(name, 20), 
                "Constructor should throw exception when name is invalid.");
        }

        [Test]
        public void Test_Constructor_Invalid_Size_Should_Throw_Argument_Exception()
        {
            Assert.Throws<ArgumentException>(
                () => new Gym("Valid", -1),
                "Constructor should throw exception when size is invalid.");
        }

        [Test]
        public void Test_Add_Athlete_Should_Add_Correctly()
        {
            Gym gym = new Gym("Best Gym", 2);
            Athlete athleteOne = new Athlete("Dennis");
            Athlete athleteTwo = new Athlete("Andrej");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);

            Assert.AreEqual(2, gym.Count, "Add did not add to the collection properly.");
        }

        [Test]
        public void Test_Add_Athlete_Overflow_Should_Throw_Invalid_Operation_Exception()
        {
            Gym gym = new Gym("Best Gym", 1);
            Athlete athleteOne = new Athlete("Dennis");
            Athlete athleteTwo = new Athlete("Andrej");

            gym.AddAthlete(athleteOne);

            Assert.Throws<InvalidOperationException>(
                () => gym.AddAthlete(athleteTwo),
                "Add should throw when there is no room for a new athlete.");
        }

        [Test]
        public void Test_Remove_Athlete_Should_Remove_Correctly()
        {
            Gym gym = new Gym("Best Gym", 2);
            Athlete athleteOne = new Athlete("Dennis");
            Athlete athleteTwo = new Athlete("Andrej");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.RemoveAthlete("Dennis");

            Assert.AreEqual(1, gym.Count, "Remove did not remove from the collection properly.");
        }

        [Test]
        public void Test_Remove_Athlete_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Gym gym = new Gym("Best Gym", 1);
            Athlete athleteOne = new Athlete("Dennis");

            gym.AddAthlete(athleteOne);

            Assert.Throws<InvalidOperationException>(
                () => gym.RemoveAthlete("Andrej"),
                "Remove should throw when there is no matching athlete.");
        }

        [Test]
        public void Test_Injure_Athlete_Should_Injure_Correctly()
        {
            Gym gym = new Gym("Best Gym", 1);
            Athlete athleteOne = new Athlete("Dennis");

            gym.AddAthlete(athleteOne);

            Assert.AreEqual(
                athleteOne, gym.InjureAthlete("Dennis"), 
                "Injure did not return the correct athlete.");
            Assert.IsTrue(athleteOne.IsInjured, "Athlete was not injured when he should have been.");
        }

        [Test]
        public void Test_Injure_Athlete_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Gym gym = new Gym("Best Gym", 1);
            Athlete athleteOne = new Athlete("Dennis");

            gym.AddAthlete(athleteOne);

            Assert.Throws<InvalidOperationException>(
                () => gym.InjureAthlete("Andrej"),
                "Injure should throw when there is no matching athlete.");
        }

        [Test]
        public void Test_Report_Should_Return_Correct_String()
        {
            Gym gym = new Gym("Best Gym", 3);
            Athlete athleteOne = new Athlete("Dennis");
            Athlete athleteTwo = new Athlete("Andrej");
            Athlete athleteThree = new Athlete("Alexander");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.AddAthlete(athleteThree);
            gym.InjureAthlete("Alexander");

            string expected = $"Active athletes at {gym.Name}: {athleteOne.FullName}, {athleteTwo.FullName}";
            string actual = gym.Report();

            Assert.AreEqual(expected, actual, "Strings do not match.");
        }
    }
}
