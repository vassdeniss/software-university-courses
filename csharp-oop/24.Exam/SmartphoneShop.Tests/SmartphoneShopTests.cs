using System;

using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_Constructor_Invalid_Should_Throw_Argument_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-2), "Contructor should throw with invalid capacity.");
        }

        [Test]
        public void Test_Constructor_Should_Initialize_Properly()
        {
            Shop shop = new Shop(50);

            Assert.AreEqual(50, shop.Capacity, "Capacity does not match.");
            Assert.AreEqual(0, shop.Count, "Count does not match");
        }

        [Test]
        public void Test_Add_Phone_Exist_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(10);
            Smartphone phone = new Smartphone("A52", 100);
            
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone), 
                "Method should throw when adding the same model of phone.");
        }

        [Test]
        public void Test_Add_Store_Full_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(0);
            Smartphone phone = new Smartphone("A52", 100);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone), 
                "Method should throw when adding a phone to a full store.");
        }

        [Test]
        public void Test_Add_Should_Work_Correctly()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 100);

            shop.Add(phone);

            Assert.AreEqual(1, shop.Count, "Add does not work properly - mismatch count.");
        }

        [Test]
        public void Test_Remove_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(1);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("A52"),
                "Method should throw when phone model does not exist.");
        }

        [Test]
        public void Test_Remove_Should_Work_Correctly()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 100);

            shop.Add(phone);
            shop.Remove("A52");

            Assert.AreEqual(0, shop.Count, "Method remove does not work properly.");
        }

        [Test]
        public void Test_Test_Phone_Not_Exist_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(1);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("A52", 100),
                "Method should throw when phone model does not exist.");
        }

        [Test]
        public void Test_Test_Phone_Low_Battery_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 50);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("A52", 51),
                "Method should throw when phone battery is lower than the given battery.");
        }

        [Test]
        public void Test_Test_Phone_Should_Work_Correctly()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 100);

            shop.Add(phone);

            shop.TestPhone("A52", 52);

            Assert.AreEqual(48, phone.CurrentBateryCharge, "Phones battery does not get reduced correctly.");
        }

        [Test]
        public void Test_Charge_Phone_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(1);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("A52"),
                "Method should throw when phone model does not exist.");
        }

        [Test]
        public void Test_Charge_Phone_Should_Work_Correctly()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 100);

            phone.CurrentBateryCharge = 10;
            shop.Add(phone);
            shop.ChargePhone("A52");

            Assert.AreEqual(100, phone.CurrentBateryCharge, "Phones battery does not get filled properly.");
        }
    }
}
