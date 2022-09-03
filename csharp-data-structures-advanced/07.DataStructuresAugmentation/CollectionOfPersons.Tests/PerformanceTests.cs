using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace CollectionOfPersons.Tests
{
    public class PerformanceTests
    {
        [Test]
        [Timeout(250)]
        public void TestPerformance_AddPerson()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();

            // Act
            AddPersons(5000, persons);
            Assert.AreEqual(5000, persons.Count);
            void AddPersons(int count, PersonCollection persons)
            {
                for (int i = 0; i < count; i++)
                {
                    persons.AddPerson(
                        email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                        name: "Pesho" + (i % 100),
                        age: i % 100,
                        town: "Sofia" + (i % 100));
                }
            }
        }

        [Test]
        [Timeout(200)]
        public void TestPerformance_FindPerson()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            AddPersons(5000, persons);

            // Act
            for (int i = 0; i < 100000; i++)
            {
                var existingPerson = persons.FindPerson("pesho1@gmail1.com");
                Assert.IsNotNull(existingPerson);
                var nonExistingPerson = persons.FindPerson("non-existing email");
                Assert.IsNull(nonExistingPerson);
            }

            void AddPersons(int count, PersonCollection persons)
            {
                for (int i = 0; i < count; i++)
                {
                    persons.AddPerson(
                        email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                        name: "Pesho" + (i % 100),
                        age: i % 100,
                        town: "Sofia" + (i % 100));
                }
            }
        }

        [Test]
        [Timeout(300)]
        public void TestPerformance_FindPersonsByEmailDomain()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            AddPersons(5000, persons);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                List<Person> existingPersons =
                    persons.FindPeople("gmail1.com").ToList();
                Assert.AreEqual(50, existingPersons.Count);
                List<Person> notExistingPersons =
                    persons.FindPeople("non-existing email").ToList();
                Assert.AreEqual(0, notExistingPersons.Count);
            }

            void AddPersons(int count, PersonCollection persons)
            {
                for (int i = 0; i < count; i++)
                {
                    persons.AddPerson(
                        email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                        name: "Pesho" + (i % 100),
                        age: i % 100,
                        town: "Sofia" + (i % 100));
                }
            }
        }

        [Test]
        [Timeout(300)]
        public void TestPerformance_FindPersonsByNameAndTown()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            AddPersons(5000, persons);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                List<Person> existingPersons =
                    persons.FindPeople("Pesho1", "Sofia1").ToList();
                Assert.AreEqual(50, existingPersons.Count);
                List<Person> notExistingPersons =
                    persons.FindPeople("Pesho1", "Sofia5").ToList();
                Assert.AreEqual(0, notExistingPersons.Count);
            }

            void AddPersons(int count, PersonCollection persons)
            {
                for (int i = 0; i < count; i++)
                {
                    persons.AddPerson(
                        email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                        name: "Pesho" + (i % 100),
                        age: i % 100,
                        town: "Sofia" + (i % 100));
                }
            }
        }

        [Test]
        [Timeout(300)]
        public void TestPerformance_FindPersonsByAgeRange()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            AddPersons(5000, persons);

            // Act
            for (int i = 0; i < 2000; i++)
            {
                List<Person> existingPersons =
                    persons.FindPeople(20, 21).ToList();
                Assert.AreEqual(100, existingPersons.Count);
                List<Person> notExistingPersons =
                    persons.FindPeople(500, 600).ToList();
                Assert.AreEqual(0, notExistingPersons.Count);
            }

            void AddPersons(int count, PersonCollection persons)
            {
                for (int i = 0; i < count; i++)
                {
                    persons.AddPerson(
                        email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                        name: "Pesho" + (i % 100),
                        age: i % 100,
                        town: "Sofia" + (i % 100));
                }
            }
        }

        [Test]
        [Timeout(300)]
        public void TestPerformance_FindPersonsByTownAndAgeRange()
        {
            // Arrange
            var persons = new PersonCollection();
            AddPersons(5000, persons);

            // Act
            for (int i = 0; i < 5000; i++)
            {
                List<Person> existingPersons =
                    persons.FindPeople(18, 22, "Sofia20").ToList();
                Assert.AreEqual(50, existingPersons.Count);
                List<Person> notExistingTownPersons =
                    persons.FindPeople(20, 30, "Missing town").ToList();
                Assert.AreEqual(0, notExistingTownPersons.Count);
                List<Person> notExistingAgePersons =
                    persons.FindPeople(200, 300, "Sofia1").ToList();
                Assert.AreEqual(0, notExistingTownPersons.Count);
            }

            void AddPersons(int count, PersonCollection persons)
            {
                for (int i = 0; i < count; i++)
                {
                    persons.AddPerson(
                        email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                        name: "Pesho" + (i % 100),
                        age: i % 100,
                        town: "Sofia" + (i % 100));
                }
            }
        }
    }
}
