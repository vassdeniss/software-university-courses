using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace CollectionOfPersons.Tests
{
    public class CorrectnessTests
    {
        [Test]
        public void AddPerson_ShouldWorkCorrectly()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();

            // Act
            bool isAdded =
                persons.AddPerson("pesho@gmail.com", "Peter", 18, "Sofia");

            // Assert
            Assert.IsTrue(isAdded);
            Assert.AreEqual(1, persons.Count);
        }

        [Test]
        public void AddPerson_DuplicatedEmail_ShouldWorkCorrectly()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();

            // Act
            bool isAddedFirst =
                persons.AddPerson("pesho@gmail.com", "Peter", 18, "Sofia");
            bool isAddedSecond =
                persons.AddPerson("pesho@gmail.com", "Maria", 24, "Plovdiv");

            // Assert
            Assert.IsTrue(isAddedFirst);
            Assert.IsFalse(isAddedSecond);
            Assert.AreEqual(1, persons.Count);
        }

        [Test]
        public void FindPerson_ExistingPerson_ShouldReturnPerson()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();

            persons.AddPerson("pesho@gmail.com", "Peter", 28, "Plovdiv");

            // Act
            Person person = persons.FindPerson("pesho@gmail.com");

            // Assert
            Assert.IsNotNull(person);
        }

        [Test]
        public void FindPerson_NonExistingPerson_ShouldReturnNothing()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();

            // Act
            Person person = persons.FindPerson("pesho@gmail.com");

            // Assert
            Assert.IsNull(person);
        }

        [Test]
        public void DeletePerson_ShouldWorkCorrectly()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            persons.AddPerson("pesho@gmail.com", "Peter", 28, "Plovdiv");

            // Act
            bool isDeletedExisting =
                persons.DeletePerson("pesho@gmail.com");
            bool isDeletedNonExisting =
                persons.DeletePerson("pesho@gmail.com");

            // Assert
            Assert.IsTrue(isDeletedExisting);
            Assert.IsFalse(isDeletedNonExisting);
            Assert.AreEqual(0, persons.Count);
        }

        [Test]
        public void FindPersonsByEmailDomain_ShouldReturnMatchingPersons()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();

            persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
            persons.AddPerson("mary@gmail.com", "Maria", 21, "Plovdiv");
            persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");

            // Act
            IEnumerable<Person> personsGmail = persons.FindPeople("gmail.com");
            IEnumerable<Person> personsYahoo = persons.FindPeople("yahoo.co.uk");
            IEnumerable<Person> personsHoo = persons.FindPeople("hoo.co.uk");

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com", "mary@gmail.com", "pesho@gmail.com" },
                personsGmail.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "kiro@yahoo.co.uk" },
                personsYahoo.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                personsHoo.Select(p => p.Email).ToList());
        }

        [Test]
        public void FindPersonsByNameAndTown_ShouldReturnMatchingPersons()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
            persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
            persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
            persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");

            // Act
            IEnumerable<Person> personsPeshoPlovdiv = persons.FindPeople("Pesho", "Plovdiv");
            IEnumerable<Person> personsLowercase = persons.FindPeople("pesho", "plovdiv");
            IEnumerable<Person> personsPeshoNoTown = persons.FindPeople("Pesho", null);
            IEnumerable<Person> personsAnnaBourgas = persons.FindPeople("Anna", "Bourgas");

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "pepi@gmail.com", "pepi2@yahoo.fr", "pesho@gmail.com" },
                personsPeshoPlovdiv.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                personsLowercase.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                personsPeshoNoTown.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com" },
                personsAnnaBourgas.Select(p => p.Email).ToList());
        }

        [Test]
        public void FindPersonsByAgeRange_ShouldReturnMatchingPersons()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
            persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
            persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
            persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
            persons.AddPerson("asen@gmail.com", "Asen", 21, "Rousse");

            // Act
            IEnumerable<Person> personsAgedFrom21to22 = persons.FindPeople(21, 22);
            IEnumerable<Person> personsAgedFrom10to11 = persons.FindPeople(10, 11);
            IEnumerable<Person> personsAged21 = persons.FindPeople(21, 21);
            IEnumerable<Person> personsAged19 = persons.FindPeople(19, 19);
            IEnumerable<Person> personsAgedFrom0to1000 = persons.FindPeople(0, 1000);

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
                personsAgedFrom21to22.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                personsAgedFrom10to11.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
                personsAged21.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com" },
                personsAged19.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com", "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
                personsAgedFrom0to1000.Select(p => p.Email).ToList());
        }

        [Test]
        public void FindPersonsByAgeRangeAndTown_ShouldReturnMatchingPersons()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            persons.AddPerson("kirosofia@yahoo.co.uk", "Kiril", 22, "Sofia");
            persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
            persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
            persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
            persons.AddPerson("ani17@gmail.com", "Anna", 17, "Bourgas");
            persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
            persons.AddPerson("asen.rousse@gmail.com", "Asen", 21, "Rousse");
            persons.AddPerson("asen@gmail.com", "Asen", 21, "Plovdiv");

            // Act
            IEnumerable<Person> personsAgedFrom21to22Plovdiv = persons.FindPeople(21, 22, "Plovdiv");
            IEnumerable<Person> personsAgedFrom10to11Sofia = persons.FindPeople(10, 11, "Sofia");
            IEnumerable<Person> personsAged21Plovdiv = persons.FindPeople(21, 21, "Plovdiv");
            IEnumerable<Person> personsAged19Bourgas = persons.FindPeople(19, 19, "Bourgas");
            IEnumerable<Person> personsAgedFrom0to1000Plovdiv = persons.FindPeople(0, 1000, "Plovdiv");
            IEnumerable<Person> personsAgedFrom0to1000NewYork = persons.FindPeople(0, 1000, "New York");

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
                personsAgedFrom21to22Plovdiv.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                personsAgedFrom10to11Sofia.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
                personsAged21Plovdiv.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com" },
                personsAged19Bourgas.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
                personsAgedFrom0to1000Plovdiv.Select(p => p.Email).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                personsAgedFrom0to1000NewYork.Select(p => p.Email).ToList());
        }

        [Test]
        public void FindDeletedPersons_ShouldReturnEmptyCollection()
        {
            // Arrange
            PersonCollection persons = new PersonCollection();
            persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            persons.AddPerson("kirosofia@yahoo.co.uk", "Kiril", 22, "Sofia");
            persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
            persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
            persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
            persons.AddPerson("ani17@gmail.com", "Anna", 17, "Bourgas");
            persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
            persons.AddPerson("asen.rousse@gmail.com", "Asen", 21, "Rousse");
            persons.AddPerson("asen@gmail.com", "Asen", 21, "Plovdiv");

            persons.DeletePerson("pesho@gmail.com");
            persons.DeletePerson("kirosofia@yahoo.co.uk");
            persons.DeletePerson("kiro@yahoo.co.uk");
            persons.DeletePerson("pepi@gmail.com");
            persons.DeletePerson("ani@gmail.com");
            persons.DeletePerson("ani17@gmail.com");
            persons.DeletePerson("pepi2@yahoo.fr");
            persons.DeletePerson("asen.rousse@gmail.com");
            persons.DeletePerson("asen@gmail.com");

            // Act
            Person personPeshoGmail = persons.FindPerson("pesho@gmail.com");

            IEnumerable<Person> personsGmail = persons.FindPeople("gmail.com");
            IEnumerable<Person> personsYahoo = persons.FindPeople("yahoo.co.uk");

            IEnumerable<Person> personsPeshoPlovdiv = persons.FindPeople("Pesho", "Plovdiv");

            IEnumerable<Person> personsAgedFrom21to22 = persons.FindPeople(21, 22);
            IEnumerable<Person> personsAgedFrom0to1000 = persons.FindPeople(0, 1000);

            IEnumerable<Person> personsAgedFrom21to22Plovdiv = persons.FindPeople(21, 22, "Plovdiv");
            IEnumerable<Person> personsAged19Bourgas = persons.FindPeople(19, 19, "Bourgas");

            // Assert
            Assert.AreEqual(null, personPeshoGmail);

            Assert.AreEqual(0, personsGmail.Count());
            Assert.AreEqual(0, personsYahoo.Count());

            Assert.AreEqual(0, personsPeshoPlovdiv.Count());

            Assert.AreEqual(0, personsAgedFrom21to22.Count());
            Assert.AreEqual(0, personsAgedFrom0to1000.Count());

            Assert.AreEqual(0, personsAgedFrom21to22Plovdiv.Count());
            Assert.AreEqual(0, personsAged19Bourgas.Count());
        }

        [Test]
        public void MultipleOperations_ShouldReturnWorkCorrectly()
        {
            PersonCollection persons = new PersonCollection();

            bool isAdded = persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            Assert.IsTrue(isAdded);
            Assert.AreEqual(1, persons.Count);

            isAdded = persons.AddPerson("pesho@gmail.com", "Pesho2", 222, "Plovdiv222");
            Assert.IsFalse(isAdded);
            Assert.AreEqual(1, persons.Count);

            persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
            Assert.AreEqual(2, persons.Count);

            persons.AddPerson("asen@gmail.com", "Asen", 22, "Sofia");
            Assert.AreEqual(3, persons.Count);

            Person person = persons.FindPerson("non-existing person");
            Assert.IsNull(person);

            person = persons.FindPerson("pesho@gmail.com");
            Assert.IsNotNull(person);
            Assert.AreEqual("pesho@gmail.com", person.Email);
            Assert.AreEqual("Pesho", person.Name);
            Assert.AreEqual(28, person.Age);
            Assert.AreEqual("Plovdiv", person.Town);

            IEnumerable<Person> personsGmail = persons.FindPeople("gmail.com");
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pesho@gmail.com" },
                personsGmail.Select(p => p.Email).ToList());

            IEnumerable<Person> personsPeshoPlovdiv = persons.FindPeople("Pesho", "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { "pesho@gmail.com" },
                personsPeshoPlovdiv.Select(p => p.Email).ToList());

            IEnumerable<Person> personsPeshoSofia = persons.FindPeople("Pesho", "Sofia");
            Assert.AreEqual(0, personsPeshoSofia.Count());

            IEnumerable<Person> personsKiroPlovdiv = persons.FindPeople("Kiro", "Plovdiv");
            Assert.AreEqual(0, personsKiroPlovdiv.Count());

            IEnumerable<Person> personsAge22To28 = persons.FindPeople(22, 28);
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "kiro@yahoo.co.uk", "pesho@gmail.com" },
                personsAge22To28.Select(p => p.Email).ToList());

            IEnumerable<Person> personsAge22To28Plovdiv = persons.FindPeople(22, 28, "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { "kiro@yahoo.co.uk", "pesho@gmail.com" },
                personsAge22To28Plovdiv.Select(p => p.Email).ToList());

            bool isDeleted = persons.DeletePerson("pesho@gmail.com");
            Assert.IsTrue(isDeleted);

            isDeleted = persons.DeletePerson("pesho@gmail.com");
            Assert.IsFalse(isDeleted);

            person = persons.FindPerson("pesho@gmail.com");
            Assert.IsNull(person);

            personsGmail = persons.FindPeople("gmail.com");
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com" },
                personsGmail.Select(p => p.Email).ToList());

            personsPeshoPlovdiv = persons.FindPeople("Pesho", "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { },
                personsPeshoPlovdiv.Select(p => p.Email).ToList());

            personsPeshoSofia = persons.FindPeople("Pesho", "Sofia");
            Assert.AreEqual(0, personsPeshoSofia.Count());

            personsKiroPlovdiv = persons.FindPeople("Kiro", "Plovdiv");
            Assert.AreEqual(0, personsKiroPlovdiv.Count());

            personsAge22To28 = persons.FindPeople(22, 28);
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "kiro@yahoo.co.uk" },
                personsAge22To28.Select(p => p.Email).ToList());

            personsAge22To28Plovdiv = persons.FindPeople(22, 28, "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { "kiro@yahoo.co.uk" },
                personsAge22To28Plovdiv.Select(p => p.Email).ToList());
        }
    }
}
