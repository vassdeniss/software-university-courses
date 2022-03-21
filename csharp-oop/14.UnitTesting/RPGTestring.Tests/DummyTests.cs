using NUnit.Framework;
using System.Reflection;

namespace RPGTestring.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Dummy_Is_Attacked_Should_Lose_Health()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(0), "Dummy should lose health when attacked");
        }

        [Test]
        public void Dummy_Is_Attacked_When_Dead_Should_Throw_Invalid_Operation_Exception()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(-5, 10);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException, "Dummy cannot be attacked when it is dead.");
        }

        [Test]
        public void Dummy_Is_Alive_Should_Not_Give_Experience()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Dummy can't give experience when it is alive.");
        }

        [Test]
        public void Dummy_Is_Dead_Should_Give_Experience()
        {
            Dummy dummy = new Dummy(-5, 10);
            
            object expField = typeof(Dummy).GetField("experience", BindingFlags.Instance | BindingFlags.Public |BindingFlags.NonPublic | BindingFlags.Static).GetValue(dummy);

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(expField), "Dummy should return its experience field when dead.");
        }
    }
}
