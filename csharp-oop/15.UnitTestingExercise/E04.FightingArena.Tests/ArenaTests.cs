using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void Test_Constructor_Should_Initialize_Properly()
        {
            Assert.IsNotNull(arena.Warriors, "Warriors list is null.");
            Assert.AreEqual(arena.Warriors.Count, arena.Count, "List count and count do not match.");
            Assert.AreEqual(0, arena.Count, "Count does not match.");
        }

        [Test]
        public void Test_Enroll_Should_Add_Correctly()
        {
            Warrior warrior = new Warrior("Brom", 50, 200);

            arena.Enroll(warrior);
            bool act = arena.Warriors.Any(x => x.Name == "Brom");
            string failureMessage = "Adding a warrior does not add it correctly.";

            Assert.True(act, failureMessage);
        }

        [Test]
        public void Test_Enroll_Repeated_Warrior_Should_Throw_Invalid_Operation_Exception()
        {
            Warrior warrior = new Warrior("Brom", 50, 200);

            arena.Enroll(warrior);
            TestDelegate act = () => arena.Enroll(warrior);
            string failureMessage = "Adding the same warrior twice should throw exception.";

            Assert.Throws<InvalidOperationException>(act, failureMessage);
        }

        [Test]
        public void Test_Fight_With_Non_Existing_Warriors_Should_Throw_Invalid_Operation_Exception()
        {
            TestDelegate act = () => arena.Fight("Brom", "Razgar");

            Assert.Throws<InvalidOperationException>(act, "First given warrior does not exist should throw exception.");

            arena.Enroll(new Warrior("Brom", 30, 100));

            Assert.Throws<InvalidOperationException>(act, "Second given warrior does not exist should throw exception.");
        }

        [Test]
        public void Test_Fight_With_Existing_Warriors_Should_Not_Throw_Exception()
        {
            Warrior warrior = new Warrior("Brom", 50, 90);
            Warrior defender = new Warrior("Razgar", 50, 100);
            arena.Enroll(warrior);
            arena.Enroll(defender);

            arena.Fight("Brom", "Razgar");

            Assert.AreEqual(40, warrior.HP, "First warrior HP does not match.");
            Assert.AreEqual(50, defender.HP, "Second warrior HP does not match.");
        }
    }
}
