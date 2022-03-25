using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCasesConstructor")]
        public void Constructor_Should_Initialize_Properly(Person[] people, int expectedCount)
        {
            Database db = new Database(people);

            Assert.That(expectedCount, Is.EqualTo(db.Count), "The count in the database does not match with input array count.");
        }

        [Test]
        public void Constructor_Should_Throw_Argument_Exception_When_Input_Lenght_Is_Above_Sixteen()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Harold"),
                new Person(2, "Jeremy"),
                new Person(3, "Ethan"),
                new Person(4, "Walter"),
                new Person(5, "Peter"),
                new Person(6, "Nathan"),
                new Person(7, "Henry"),
                new Person(8, "Dennis"),
                new Person(9, "Andrej"),
                new Person(10, "Alexander"),
                new Person(11, "Larry"),
                new Person(12, "Eric"),
                new Person(13, "Garry"),
                new Person(14, "Sarah"),
                new Person(15, "Karen"),
                new Person(16, "Elizabeth"),
                new Person(17, "Steve"),
            };

            Assert.That(() => new Database(people), Throws.ArgumentException, "Database should throw argument exception when input is above sixteen elements.");
        }

        [TestCaseSource("TestCasesAdd")]
        public void Add_People_To_Database_Should_Increase_Size_Properly(Person[] ctor, Person[] toAdd, int expectedCount)
        {
            Database db = new Database(ctor);

            foreach (Person person in toAdd)
            {
                db.Add(person);
            }

            Assert.That(expectedCount, Is.EqualTo(db.Count), "People not added correctly - mismatching count between input and class.");
        }

        [TestCaseSource("TestCasesAddInvalid")]
        public void Add_To_Database_With_Invalid_Data_Should_Throw_Exception(Person[] ctor, Person[] arrToAdd, Person toAdd)
        {
            Database db = new Database(ctor);

            foreach (Person person in arrToAdd)
            {
                db.Add(person);
            }

            Assert.That(() => db.Add(toAdd), Throws.InvalidOperationException, "Invalid data does not throw an exception.");
        }

        [TestCaseSource("TestCasesRemove")]
        public void Remove_From_Database_Should_Have_Correct_Count(Person[] ctor, Person[] arrToAdd, int toRemove, int expectedCount)
        {
            Database db = new Database(ctor);

            foreach (Person person in arrToAdd)
            {
                db.Add(person);
            }

            for (int i = 0; i < toRemove; i++)
            {
                db.Remove();
            }

            Assert.That(expectedCount, Is.EqualTo(db.Count), "Database counter does not match expected count.");
        }

        [Test]
        public void Remove_From_Database_While_Empty_Should_Throw_Invalid_Operation_Exception()
        {
            Database db = new Database();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException, "If removing from an empty database it should throw exception.");
        }

        [Test]
        public void Find_By_Username_Should_Return_Correct_Person()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Harold"),
                new Person(2, "Jeremy"),
                new Person(3, "Ethan"),
                new Person(4, "Walter"),
                new Person(5, "Peter"),
                new Person(6, "Nathan"),
                new Person(7, "Henry"),
                new Person(8, "Dennis"),
                new Person(9, "Andrej"),
                new Person(10, "Alexander")
            };

            Database db = new Database(people);

            Assert.That(people[8], Is.EqualTo(db.FindByUsername("Andrej")));
        }

        [Test]
        public void Find_By_Username_With_Empty_String_Should_Throw_Argument_Null_Exception()
        {
            Database db = new Database();

            Assert.That(() => db.FindByUsername(string.Empty), Throws.ArgumentNullException, "Find by username should throw when given an empty string as an argument.");
        }

        [Test]
        public void Find_By_Username_With_Null_String_Should_Throw_Argument_Null_Exception()
        {
            Database db = new Database();

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException, "Find by username should throw when given null as an argument.");
        }

        [Test]
        public void Find_By_Username_With_Not_Existant_Name_Should_Throw_Invalid_Operation_Exception()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Harold"),
                new Person(2, "Jeremy"),
                new Person(3, "Ethan"),
                new Person(4, "Walter"),
                new Person(5, "Peter"),
                new Person(6, "Nathan"),
                new Person(7, "Henry"),
                new Person(8, "Dennis"),
                new Person(9, "Andrej"),
                new Person(10, "Alexander")
            };

            Database db = new Database();

            Assert.That(() => db.FindByUsername("Michael"), Throws.InvalidOperationException, "Find by username should throw when given a name which does not exist in the database as an argument.");
        }

        [Test]
        public void Find_By_Id_Should_Return_Correct_Person()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Harold"),
                new Person(2, "Jeremy"),
                new Person(3, "Ethan"),
                new Person(4, "Walter"),
                new Person(5, "Peter"),
                new Person(6, "Nathan"),
                new Person(7, "Henry"),
                new Person(316, "Dennis"),
                new Person(9, "Andrej"),
                new Person(10, "Alexander")
            };

            Database db = new Database(people);

            Assert.That(people[7], Is.EqualTo(db.FindById(316)));
        }

        [Test]
        public void Find_By_Id_With_Negative_Number_Should_Throw_Argument_Out_Of_Range_Exception()
        {
            Database db = new Database();

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-20), "Find by id should throw when given a negative number as an argument.");
        }

        [Test]
        public void Find_By_Id_With_Not_Existant_Id_Should_Throw_Invalid_Operation_Exception()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Harold"),
                new Person(2, "Jeremy"),
                new Person(3, "Ethan"),
                new Person(4, "Walter"),
                new Person(5, "Peter"),
                new Person(6, "Nathan"),
                new Person(7, "Henry"),
                new Person(8, "Dennis"),
                new Person(9, "Andrej"),
                new Person(10, "Alexander")
            };

            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.FindById(11), "Find by id should throw when given an id which does not exist in the database as an argument.");
        }

        public static IEnumerable<TestCaseData> TestCasesRemove()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[] {
                        new Person(1, "Ivan"),
                        new Person(2, "Franz"),
                        new Person(3, "James")
                    },
                    new Person[]
                    {
                        new Person(4, "Janess"),
                        new Person(5, "Mary"),
                        new Person(6, "Jennefer")
                    },
                    3,
                    3),
                new TestCaseData(
                    new Person[] { },
                    new Person[]
                    {
                        new Person(1, "Franz"),
                    },
                    1,
                    0)
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> TestCasesAddInvalid()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Harold"),
                        new Person(2, "Jeremy"),
                        new Person(3, "Ethan"),
                        new Person(4, "Walter"),
                        new Person(5, "Peter"),
                        new Person(6, "Nathan"),
                        new Person(7, "Henry"),
                        new Person(8, "Dennis"),
                        new Person(9, "Andrej"),
                        new Person(10, "Alexander"),
                        new Person(11, "Larry"),
                        new Person(12, "Eric"),
                        new Person(13, "Garry"),
                    },
                    new Person[]
                    {
                        new Person(14, "Sarah"),
                        new Person(15, "Karen"),
                        new Person(16, "Elizabeth"),
                    }, 
                    new Person(17, "Steve")),
                new TestCaseData(
                    new Person[] { },
                    new Person[] 
                    {
                        new Person(1, "Dennis"),
                        new Person(2, "Andrej"),
                    },
                    new Person(3, "Dennis")),
                new TestCaseData(
                    new Person[] { },
                    new Person[]
                    {
                        new Person(1, "Dennis"),
                        new Person(2, "Andrej"),
                    },
                    new Person(2, "Ethan")),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> TestCasesAdd()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[] {
                        new Person(1, "Ivan"),
                        new Person(2, "Franz"),
                        new Person(3, "James")
                    },
                    new Person[]
                    {
                        new Person(4, "Janess"),
                        new Person(5, "Mary"),
                        new Person(6, "Jennefer")
                    }, 
                    6),
                new TestCaseData(
                    new Person[] { },
                    new Person[]
                    {
                        new Person(4, "James"),
                        new Person(5, "Mary"),
                        new Person(6, "Jennefer"),
                    }, 
                    3),
                new TestCaseData(
                    new Person[] { },
                    new Person[] { }, 
                    0)
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        public static IEnumerable<TestCaseData> TestCasesConstructor()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[] {
                        new Person(1, "Ivan"),
                        new Person(2, "Franz"),
                        new Person(3, "James")
                }, 3),
                new TestCaseData(
                    new Person[] { }, 0)
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }
    }
}
