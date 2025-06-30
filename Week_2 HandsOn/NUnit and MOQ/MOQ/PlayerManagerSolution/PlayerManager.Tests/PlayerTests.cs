using NUnit.Framework;
using Moq;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _mockPlayerMapper;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockPlayerMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        [TestCase("Virat")]
        public void RegisterNewPlayer_ValidName_ShouldCreatePlayer(string name)
        {
            _mockPlayerMapper.Setup(x => x.IsPlayerNameExistsInDb(name)).Returns(false);
            _mockPlayerMapper.Setup(x => x.AddNewPlayerIntoDb(name));

            var player = Player.RegisterNewPlayer(name, _mockPlayerMapper.Object);

            Assert.IsNotNull(player);
            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(23, player.Age);
            Assert.AreEqual("India", player.Country);
            Assert.AreEqual(30, player.NoOfMatches);
        }

        [Test]
        [TestCase("")]
        public void RegisterNewPlayer_EmptyName_ShouldThrowException(string name)
        {
            var ex = Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(name, _mockPlayerMapper.Object));
            Assert.AreEqual("Player name can’t be empty.", ex.Message);
        }

        [Test]
        [TestCase("Rohit")]
        public void RegisterNewPlayer_ExistingName_ShouldThrowException(string name)
        {
            _mockPlayerMapper.Setup(x => x.IsPlayerNameExistsInDb(name)).Returns(true);
            var ex = Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(name, _mockPlayerMapper.Object));
            Assert.AreEqual("Player name already exists.", ex.Message);
        }
    }
}