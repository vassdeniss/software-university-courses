using Moq;
using NUnit.Framework;

namespace L02.RPG.Tests
{
    public class HeroTests
    {
        private Hero hero;
        private Mock<IWeapon> evoker;
        private Mock<ITarget> shadow;

        [SetUp]
        public void SetUp()
        {
            shadow = new Mock<ITarget>();
            shadow.SetupGet(x => x.Health).Returns(0);
            shadow.Setup(x => x.GiveExperience()).Returns(45);
            shadow.Setup(x => x.IsDead()).Returns(true);

            evoker = new Mock<IWeapon>();

            hero = new Hero("Dennis", evoker.Object);
        }

        [Test]
        public void Test_Get_Experience_Should_Increase_Correctly()
        {
            hero.Attack(shadow.Object);

            Assert.AreEqual(45, hero.Experience);
        }
    }
}
