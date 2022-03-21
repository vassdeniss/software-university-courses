using NUnit.Framework;

namespace RPGTestring.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Attack_With_Axe_Should_Decrease_Durability()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe should drop durability by one after every attack.");
        }

        [Test]
        public void Attack_With_Zero_Durability_Should_Throw_Invalid_Operation_Exception()
        {
            Axe axe = new Axe(10, -5);
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException, "Axe cannot attack with zero durability.");
        }
    }
}