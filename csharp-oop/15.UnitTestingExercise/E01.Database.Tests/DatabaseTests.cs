using NUnit.Framework;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Set_Up()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            database = new Database(arr);
        }

        [Test]
        public void Adding_To_Database_Should_Place_Element_At_Last_Index()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 30 };

            database.Add(30);

            int[] actual = database.Fetch();

            Assert.That(actual, Is.EqualTo(expected), "Adding an element to the databse should add said element to the end of the array.");
        }

        [Test]
        public void Adding_To_Database_Should_Increase_Count()
        {
            int expected = database.Count + 1;

            database.Add(36);

            int actual = database.Count;

            Assert.That(actual, Is.EqualTo(expected), "Adding elements should increase the count.");
        }

        [Test]
        public void Adding_Elements_Above_Sixteen_Should_Throw_Invalid_Operation_Exception()
        {
            database.Add(35);

            Assert.That(() => database.Add(36), Throws.InvalidOperationException, "Adding above sixteen elements should throw an invalid operation exception"); 
        }

        [Test]
        public void Removing_From_Database_Should_Remove_Element_From_Last_Index()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            database.Remove();

            int[] actual = database.Fetch();

            Assert.That(actual, Is.EqualTo(expected), "Removing an element from the databse should remove the last element from the array.");
        }

        [Test]
        public void Removing_From_Database_Should_Decrease_Count()
        {
            int expected = database.Count - 1;

            database.Remove();

            int actual = database.Count;

            Assert.That(actual, Is.EqualTo(expected), "Removing elements should decrease the count.");
        }

        [Test]
        public void Removing_Elements_From_An_Empty_Database_Should_Throw_Invalid_Operation_Exception()
        {
            database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException, "Removing from an empty database should throw an invalid operation exception");
        }

        [Test]
        public void Fetch_Should_Return_Database_As_Array()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            int[] actual = database.Fetch();

            Assert.That(actual, Is.EqualTo(expected), "Fetching should return all elements as an array.");
        }
    }
}
