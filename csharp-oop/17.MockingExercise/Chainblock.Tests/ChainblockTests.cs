using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Chainblock.Contracts;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Chainblock chainblock; 
        private ITransaction transactionOne;
        private ITransaction transactionTwo;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();

            transactionOne = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 250
            };

            transactionTwo = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Andrej",
                To = "Denis",
                Amount = 300
            };
        }

        [Test]
        public void Test_Add_Should_Add_Correctly()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 250
            };

            chainblock.Add(transaction);

            Assert.AreEqual(1, chainblock.Count, "Count does not match.");
        }

        [Test]
        public void Test_Contains_Should_Work_Properly()
        {
            chainblock.Add(transactionOne);

            Assert.True(chainblock.Contains(transactionOne), "Transaction should be contained.");
            Assert.True(chainblock.Contains(transactionOne.Id), "Transaction should be contained.");
            Assert.False(chainblock.Contains(transactionTwo), "Transaction should not be contained.");
            Assert.False(chainblock.Contains(transactionTwo.Id), "Transaction should not be contained.");
        }

        [Test]
        public void Test_Change_Transaction_Status_Invalid_Should_Throw_Argument_Exception()
        {
            Assert.Throws<ArgumentException>(
                () => chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed), 
                "Method should throw exception if transaction id does not exist.");
        }

        [Test]
        public void Test_Change_Transaction_Status_Should_Change_Correctly()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);
            chainblock.ChangeTransactionStatus(2, TransactionStatus.Unauthorized);

            Assert.AreEqual(TransactionStatus.Failed, transactionOne.Status);
            Assert.AreEqual(TransactionStatus.Unauthorized, transactionTwo.Status);
        }

        [Test]
        public void Test_Remove_By_Id_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.RemoveTransactionById(1),
                "Method should throw exception if transaction id does not exist.");
        }

        [Test]
        public void Test_Remove_By_Id_Should_Remove_Correctly()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            chainblock.RemoveTransactionById(1);
            chainblock.RemoveTransactionById(2);

            Assert.AreEqual(0, chainblock.Count, "Removing transactions does not work properly.");
        }

        [Test]
        public void Test_Get_By_Id_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetById(1),
                "Method should throw exception if transaction id does not exist.");
        }

        [Test]
        public void Test_Get_By_Id_Should_Return_Correctly()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            chainblock.GetById(2);

            Assert.AreEqual(transactionTwo, 
                chainblock.GetById(2), 
                "Getting transactions does not work properly.");
        }

        [Test]
        public void Test_Get_By_Transaction_Status_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByTransactionStatus(TransactionStatus.Failed),
                "Method should throw exception if transaction id does not exist.");
        }

        [Test]
        public void Test_Get_By_Transaction_Status_Should_Return_Correctly()
        {
            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown",
                To = "Unknown",
                Amount = 20
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown",
                To = "Unknown",
                Amount = 150
            };

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            List<ITransaction> expected = new List<ITransaction>() { transactionFour, transactionThree };
            List<ITransaction> actual = chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized).ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of transactions was not recieved.");
        }

        [Test]
        public void Test_Get_All_Senders_With_Transaction_Status_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed),
                "Method should throw exception if no matches were found.");
        }

        [Test]
        public void Test_Get_All_Senders_With_Transaction_Status_Should_Return_Correctly()
        {
            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown",
                To = "Someone",
                Amount = 20
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown Again",
                To = "Someone",
                Amount = 150
            };

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            List<string> expected = new List<string>() { "Unknown", "Unknown Again" };
            List<string> actual = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized).ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of names was not recieved.");
        }

        [Test]
        public void Test_Get_All_Recievers_With_Transaction_Status_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed),
                "Method should throw exception if no matches were found.");
        }

        [Test]
        public void Test_Get_All_Recievers_With_Transaction_Status_Should_Return_Correctly()
        {
            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown",
                To = "Someone",
                Amount = 20
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown Again",
                To = "Someone Again",
                Amount = 150
            };

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            List<string> expected = new List<string>() { "Someone", "Someone Again" };
            List<string> actual = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized).ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of names was not recieved.");
        }

        [Test]
        public void Test_Get_All_Ordered_By_Amount_Descending_Then_By_Id_Should_Return_Correctly()
        {
            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown",
                To = "Someone",
                Amount = 20
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Unauthorized,
                From = "Unknown Again",
                To = "Someone Again",
                Amount = 150
            };

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            List<ITransaction> expected = new List<ITransaction>() 
            { transactionTwo, transactionOne, transactionFour, transactionThree };
            List<ITransaction> actual = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            CollectionAssert.AreEqual(expected.OrderByDescending(x => x.Amount).ThenBy(x => x.Id), actual,
                "Expected list of transactions was not recieved.");
        }

        [Test]
        public void Test_Get_By_Sender_Ordered_By_Amount_Descending_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderOrderedByAmountDescending("Ivan"),
                "Method should throw exception if no matches were found.");
        }

        [Test]
        public void Test_Get_By_Sender_Ordered_By_Amount_Descending_Should_Return_Correctly()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 50
            };

            chainblock.Add(transactionThree);

            List<ITransaction> expected = new List<ITransaction>() { transactionOne, transactionThree };
            List<ITransaction> actual = chainblock.GetBySenderOrderedByAmountDescending("Denis").ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of transactions was not recieved.");
        }

        [Test]
        public void Test_Get_By_Reciever_Ordered_By_Amount_Then_By_Id_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverOrderedByAmountThenById("Ivan"),
                "Method should throw exception if no matches were found.");
        }

        [Test]
        public void Test_Get_By_Reciever_Ordered_By_Amount_Then_By_Id_Should_Return_Correctly()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 50
            };

            chainblock.Add(transactionThree);

            List<ITransaction> expected = new List<ITransaction>() { transactionOne, transactionThree };
            List<ITransaction> actual = chainblock.GetByReceiverOrderedByAmountThenById("Andrej").ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of transactions was not recieved.");
        }

        [Test]
        public void Test_Get_By_Transaction_Status_And_Maximum_Amount_Should_Return_Correctly()
        {
            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Successfull,
                From = "Andrej",
                To = "Denis",
                Amount = 100
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Andrej",
                To = "Denis",
                Amount = 500
            };

            ITransaction transactionFive = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Denis",
                To = "Grandma",
                Amount = 100
            };

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);
            chainblock.Add(transactionFive);

            List<ITransaction> expected = new List<ITransaction>() { transactionTwo, transactionOne, transactionThree };
            List<ITransaction> actual = chainblock.GetByTransactionStatusAndMaximumAmount(
                TransactionStatus.Successfull,
                300).ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of transactions was not recieved.");
        }

        [Test]
        public void Test_Get_By_Sender_And_Minimum_Amount_Should_Return_Correctly()
        {
            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Successfull,
                From = "Andrej",
                To = "Denis",
                Amount = 100
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Andrej",
                To = "Denis",
                Amount = 500
            };

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            List<ITransaction> expected = new List<ITransaction>() { transactionFour, transactionTwo };
            List<ITransaction> actual = chainblock.GetBySenderAndMinimumAmountDescending("Andrej", 270).ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of transactions was not recieved.");
        }

        [Test]
        public void Test_Get_By_Reciever_And_Amount_Range_Should_Throw_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverAndAmountRange("Ivan", 200, 500),
                "Method should throw exception if no matches were found.");
        }

        [Test]
        public void Test_Get_By_Reciever_And_Amount_Range_Should_Return_Correctly()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 100
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 300
            };

            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            List<ITransaction> expected = new List<ITransaction>() { transactionOne, transactionThree };
            List<ITransaction> actual = chainblock.GetByReceiverAndAmountRange("Andrej", 100, 300).ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of transactions was not recieved.");
        }

        [Test]
        public void Test_Get_All_In_Amount_Range_Should_Return_Correctly()
        {
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            ITransaction transactionThree = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 50
            };

            ITransaction transactionFour = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Denis",
                To = "Andrej",
                Amount = 500
            };

            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            List<ITransaction> expected = new List<ITransaction>() { transactionOne, transactionTwo };
            List<ITransaction> actual = chainblock.GetAllInAmountRange(100, 300).ToList();

            CollectionAssert.AreEqual(expected, actual,
                "Expected list of transactions was not recieved.");
        }
    }
}
