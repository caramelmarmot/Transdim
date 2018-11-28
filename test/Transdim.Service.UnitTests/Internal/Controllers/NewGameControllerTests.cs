using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transdim.Service.Internal.Controllers;
using Transdim.DomainModel;

namespace Transdim.Service.UnitTests.Internal.Controllers
{
    [TestClass]
    public class NewGameControllerTests
    {
        private NewGameController sut;

        [TestInitialize]
        public void SetUp() => sut = new NewGameController();

        [TestMethod]
        public void Something_WhenSomething_DoesSomething()
        {
            // Arrange

            var game = new Game()
            {
                Players = new List<Player> {
                    new Player { FactionIdentifier = FactionIdentifier.Ambas, IsAutoma = false },
                    new Player { FactionIdentifier = FactionIdentifier.BalTaks, IsAutoma = true }
                }
            };

            // Act
            var result = sut.GetAvailableFactions(game);

            // Assert
            //Assert.That(result.Count, Doe)
        }
    }
}
