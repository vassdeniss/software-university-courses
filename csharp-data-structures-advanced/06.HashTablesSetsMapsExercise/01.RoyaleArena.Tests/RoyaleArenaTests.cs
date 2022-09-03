using System.Collections.Generic;

using NUnit.Framework;

namespace _01.RoyaleArena.Tests
{
    public class RoyaleArenaTests
    {
        [Test]
        public void Add_SingleElement_ShouldWorkCorrectly() 
        {
            IArena arena = new RoyaleArena();
            BattleCard cd = new BattleCard(5, CardType.Spell, "joro", 5, 5);
            arena.Add(cd);

            //Assert
            foreach (BattleCard card in arena) 
            {
                Assert.AreEqual(card, cd);
            }
        }

        [Test]
        public void Contains_OnExistingElement_ShouldReturnTrue()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 6, 5);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "joro", 7, 5);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 8, 5);

            //Act
            arena.Add(cd1);
            arena.Add(cd2);
            arena.Add(cd3);

            //Assert
            Assert.True(arena.Contains(cd1));
            Assert.False(arena.Contains(new BattleCard(3, CardType.Building, "ta", 6, 52.2)));
            Assert.True(arena.Contains(cd2));
            Assert.False(arena.Contains(new BattleCard(0, CardType.Ranged, "b", 7, 5)));
        }

        [Test]
        public void Count_Should_IncreaseOnMultiple_Elements()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 3, 5);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "joro", 8, 5);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 9, 5);

            //Act
            arena.Add(cd1);
            arena.Add(cd2);
            arena.Add(cd3);

            //Assert
            Assert.AreEqual(3, arena.Count);
        }

        [Test]
        public void GetById_On_ExistingElement_ShouldWorkCorrectly()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 10, 5);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "joro", 10, 5);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 10, 5);

            //Act
            arena.Add(cd1);
            arena.Add(cd2);
            arena.Add(cd3);

            //Assert
            Assert.AreEqual(cd1, arena.GetById(5));
            Assert.AreNotEqual(
                new BattleCard(53, CardType.Ranged, "a", 10, 5),
                arena.GetById(7)
            );
        }

        [Test]
        public void ChangeCardType_ShouldWorkCorrectly_On_Existingcd()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 10, 5);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "joro", 10, 5);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 10, 5);

            //Act
            arena.Add(cd1);
            arena.Add(cd2);
            arena.Add(cd3);
            arena.ChangeCardType(5, CardType.Melee);

            //Assert
            Assert.AreEqual(CardType.Melee, cd1.Type);
            Assert.AreEqual(3, arena.Count);
        }

        [Test]
        public void RA_ShouldBeEnumeratedIn_InsertionOrder()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 5, 5);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "joro", 6, 5);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 7, 5);
            List<BattleCard> expected = new List<BattleCard>() {cd1,cd3,cd2};

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);

            List<BattleCard> actual = new List<BattleCard>();

            foreach (BattleCard battlecard in arena) 
            {
                actual.Add(battlecard);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void RA_ShouldReturn_BattlecardsInCorrectOrder_AfterDelete() 
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 10, 5);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "joro", 11, 5);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 12, 5);
            List<BattleCard> expected = new List<BattleCard>() {cd2} ;

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);
            arena.RemoveById(5);
            arena.RemoveById(7);

            List<BattleCard> actual = new List<BattleCard>();
            foreach (BattleCard battlecard in arena) 
            {
                actual.Add(battlecard);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetInSwagRange_ShouldReturn_CorrectBattlecards()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "dragon", 8, 1);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "raa", 7, 2);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "maga", 6, 5.5);
            BattleCard cd4 = new BattleCard(12, CardType.Spell, "shuba", 5, 15.6);
            BattleCard cd5 = new BattleCard(15, CardType.Spell, "tanuki", 5, 7.8);
            List<BattleCard> expected = new List<BattleCard>() {cd5, cd4};

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);
            arena.Add(cd4);
            arena.Add(cd5);
            IEnumerable<BattleCard> battlecards = arena.GetAllInSwagRange(7, 16);
            List<BattleCard> actual = new List<BattleCard>();

            foreach (var b in battlecards) 
            {
                actual.Add(b);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindFirstLeastSwag_ShouldWorkCorrectly()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 6.0, 1.0);
            BattleCard cd2 = new BattleCard(6, CardType.Melee, "joro", 7.0, 5.5);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 11.0, 5.5);
            BattleCard cd4 = new BattleCard(12, CardType.Building, "joro", 12.0, 15.6);
            BattleCard cd5 = new BattleCard(15, CardType.Building, "moro", 13.0, 7.8);
            List<BattleCard> expected = new List<BattleCard>() {cd1,cd2,cd3,cd5};

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);
            arena.Add(cd4);
            arena.Add(cd5);
            IEnumerable<BattleCard> battlecards = arena.FindFirstLeastSwag(4);

            List<BattleCard> actual = new List<BattleCard>();
            foreach (var b in battlecards) 
            {
                actual.Add(b);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTypeAndDamageRangeOrderedByDamageThenById_ShouldWorkCorrectly_On_CorrectRange()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.Spell, "joro", 1, 5);
            BattleCard cd2 = new BattleCard(6, CardType.Spell, "joro", 5.5, 6);
            BattleCard cd3 = new BattleCard(7, CardType.Spell, "joro", 5.5, 7);
            BattleCard cd4 = new BattleCard(12, CardType.Spell, "joro", 15.6, 10);
            BattleCard cd5 = new BattleCard(15, CardType.Ranged, "joro", 7.8, 6);
            List<BattleCard> expected = new List<BattleCard>() {cd4, cd2, cd3, cd1};

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);
            arena.Add(cd4);
            arena.Add(cd5);

            //Assert
            IEnumerable<BattleCard> battlecards = arena.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.Spell, 0, 20);
            List<BattleCard> actual = new List<BattleCard>();
            foreach (var b in battlecards) 
            {
                actual.Add(b);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByName_ShouldWorkCorrectly()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(2, CardType.Spell, "joro", 5, 1);
            BattleCard cd2 = new BattleCard(1, CardType.Spell, "joro", 6, 1);
            BattleCard cd3 = new BattleCard(4, CardType.Spell, "joro", 7, 15.6);
            BattleCard cd4 = new BattleCard(3, CardType.Spell, "joro", 8, 15.6);
            BattleCard cd5 = new BattleCard(8, CardType.Ranged, "joro", 11, 17.8);
            List<BattleCard> expected = new List<BattleCard>() {cd5, cd4, cd3, cd2, cd1};

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);
            arena.Add(cd4);
            arena.Add(cd5);

            //Assert
            IEnumerable<BattleCard> joro = arena.GetByNameOrderedBySwagDescending("joro");
            List<BattleCard> actual = new List<BattleCard>();

            foreach (var item in joro)
            {
                actual.Add(item);
            }
            CollectionAssert.AreEquivalent(expected, actual);
        }


        [Test]
        public void GetByCardTypeAndMaximumDamage_ShouldWorkCorrectly_OnExistingSender()
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(2, CardType.Spell, "joro", 1, 5);
            BattleCard cd2 = new BattleCard(1, CardType.Spell, "valq", 14.8, 6);
            BattleCard cd3 = new BattleCard(3, CardType.Spell, "valq", 15.6, 12);
            BattleCard cd4 = new BattleCard(4, CardType.Spell, "valq", 15.6, 61);
            BattleCard cd5 = new BattleCard(8, CardType.Spell, "valq", 17.8, 13);
            List<BattleCard> expected = new List<BattleCard>() {cd3, cd4, cd2, cd1};

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);
            arena.Add(cd4);
            arena.Add(cd5);

            //Assert
            IEnumerable<BattleCard> battlecards = arena.GetByCardTypeAndMaximumDamage(CardType.Spell, 15.6);
            List<BattleCard> actual = new List<BattleCard>();
            foreach (var item in battlecards)
            {
                actual.Add(item);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByCardType_ShouldReturnCorrectResultAfterRemove() 
        {
            //Arrange
            IArena arena = new RoyaleArena();
            BattleCard cd1 = new BattleCard(2, CardType.Spell, "valq", 2, 14.8);
            BattleCard cd2 = new BattleCard(1, CardType.Spell, "valq", 2, 14.8);
            BattleCard cd3 = new BattleCard(4, CardType.Spell, "valq", 4, 15.6);
            BattleCard cd4 = new BattleCard(3, CardType.Spell, "valq", 3, 15.6);
            BattleCard cd5 = new BattleCard(8, CardType.Ranged, "valq", 8, 17.8);
            List<BattleCard> expected = new List<BattleCard>() {cd3, cd2, cd1};

            //Act
            arena.Add(cd1);
            arena.Add(cd3);
            arena.Add(cd2);
            arena.Add(cd4);
            arena.Add(cd5);
            arena.RemoveById(8);
            arena.RemoveById(3);

            //Assert
            IEnumerable<BattleCard> battlecards = arena.GetByCardType(CardType.Spell);
            List<BattleCard> actual = new List<BattleCard>();
            foreach (var item in battlecards)
            {
                actual.Add(item);
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
