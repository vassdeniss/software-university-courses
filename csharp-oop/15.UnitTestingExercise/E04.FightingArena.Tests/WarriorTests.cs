using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [TestCaseSource("ConstructorInvalidCases")]
        public void Test_Constructor_With_Invalid_Data_Should_Throw_Argument_Exception_For_Each_Invalid_Argument(
            string name,
            int damage,
            int hp)
        {
            TestDelegate act = () => new Warrior(name, damage, hp);
            string failureMessage = "Passing in invalid arguments should throw their respective messages.";

            Assert.Throws<ArgumentException>(act, failureMessage);
        }

        [Test]
        public void Test_Constructor_With_Valid_Data_Should_Create_Object_Properly()
        {
            string name = "Denis";
            int damage = 10;
            int hp = 100;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name, "Name is not getting set properly.");
            Assert.AreEqual(damage, warrior.Damage, "Damage is not getting set properly.");
            Assert.AreEqual(hp, warrior.HP, "HP is not getting set properly.");
        }

        [TestCaseSource("AttackLowHpInvalidCases")]
        public void Test_Attack_With_Health_Lower_Than_Minimum_Should_Throw_Invalid_Operation_Exception(
            Warrior warrior,
            Warrior enemy)
        {
            TestDelegate act = () => warrior.Attack(enemy);
            string failureMessage = "Attacking while health is lower than the minimum should throw exception.";

            Assert.Throws<InvalidOperationException>(act, failureMessage);
        }

        [TestCaseSource("AttackEnemyLowHpInvalidCases")]
        public void Test_Attack_With_Enemy_Health_Lower_Than_Minimum_Should_Throw_Invalid_Operation_Exception(
            Warrior warrior,
            Warrior enemy)
        {
            TestDelegate act = () => warrior.Attack(enemy);
            string failureMessage = "Attacking while enemys health is lower than the minimum should throw exception.";

            Assert.Throws<InvalidOperationException>(act, failureMessage);
        }

        [TestCaseSource("AttackEnemyLowerHpThanAttackCases")]
        public void Test_Attack_With_Hp_Lower_Than_Enemy_Attack_Should_Throw_Invalid_Operation_Exception(
            Warrior warrior,
            Warrior enemy)
        {
            TestDelegate act = () => warrior.Attack(enemy);
            string failureMessage = "Attacking while health is lower than the enemys attack should throw exception.";

            Assert.Throws<InvalidOperationException>(act, failureMessage);
        }

        [TestCaseSource("AttackLoseHpCases")]
        public void Test_Attack_Should_Decrease_Health_Correctly(
            Warrior warrior,
            Warrior enemy,
            int expected)
        {
            warrior.Attack(enemy);
            string failureMessage = "Attacking does not update hp properly.";

            Assert.AreEqual(expected, warrior.HP, failureMessage);
        }

        [TestCaseSource("AttackEnemyLoseHpCases")]
        public void Test_Attack_Enemy_Should_Decrease_Health_Correctly(
            Warrior warrior,
            Warrior enemy,
            int expected)
        {
            warrior.Attack(enemy);
            string failureMessage = "Attacking does not update enemy hp properly.";

            Assert.AreEqual(expected, enemy.HP, failureMessage);
        }

        [TestCaseSource("AttackHighDamageEnemyLoseHpCases")]
        public void Test_Attack_With_More_Than_Enemys_Health_Should_Decrease_Health_To_Zero_Correctly(
            Warrior warrior,
            Warrior enemy,
            int expected)
        {
            warrior.Attack(enemy);
            string failureMessage = "Attacking does not set enemy hp to 0.";

            Assert.AreEqual(expected, enemy.HP, failureMessage);
        }

        public static IEnumerable<TestCaseData> AttackHighDamageEnemyLoseHpCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Warrior("Brom", 101, 100), new Warrior("Razgar", 100, 100), 0),
                new TestCaseData(new Warrior("Brom", 150, 100), new Warrior("Razgar", 100, 100), 0),
                new TestCaseData(new Warrior("Brom", 800, 100), new Warrior("Razgar", 100, 100), 0),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> AttackEnemyLoseHpCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Warrior("Brom", 30, 100), new Warrior("Razgar", 100, 100), 70),
                new TestCaseData(new Warrior("Brom", 1, 100), new Warrior("Razgar", 100, 100), 99),
                new TestCaseData(new Warrior("Brom", 100, 100), new Warrior("Razgar", 100, 100), 0),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> AttackLoseHpCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Warrior("Brom", 20, 100), new Warrior("Razgar", 30, 100), 70),
                new TestCaseData(new Warrior("Brom", 20, 100), new Warrior("Razgar", 1, 100), 99),
                new TestCaseData(new Warrior("Brom", 20, 100), new Warrior("Razgar", 100, 100), 0),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> AttackEnemyLowerHpThanAttackCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Warrior("Brom", 20, 31), new Warrior("Razgar", 100, 200)),
                new TestCaseData(new Warrior("Brom", 20, 50), new Warrior("Razgar", 100, 200)),
                new TestCaseData(new Warrior("Brom", 20, 99), new Warrior("Razgar", 100, 200)),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> AttackEnemyLowHpInvalidCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Warrior("Brom", 20, 200), new Warrior("Razgar", 10, 0)),
                new TestCaseData(new Warrior("Brom", 20, 200), new Warrior("Razgar", 10, 10)),
                new TestCaseData(new Warrior("Brom", 20, 200), new Warrior("Razgar", 10, 30)),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> AttackLowHpInvalidCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Warrior("Brom", 10, 0), new Warrior("Razgar", 20, 200)),
                new TestCaseData(new Warrior("Brom", 10, 10), new Warrior("Razgar", 20, 200)),
                new TestCaseData(new Warrior("Brom", 10, 30), new Warrior("Razgar", 20, 200)),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> ConstructorInvalidCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData("", 10, 100),
                new TestCaseData(" ", 10, 100),
                new TestCaseData(null, 10, 100),
                new TestCaseData("Denis", -10, 100),
                new TestCaseData("Denis", 0, 100),
                new TestCaseData("Denis", 10, -100),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }
    }
}
