using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Transdim.Service.Helpers;

namespace Transdim.Service.UnitTests.Internal.Helpers
{
    [TestClass]
    public class RandomizerTests
    {
        [TestMethod]
        public void Pluck_WhenExecuted_RemovesPluckedItem()
        {
            // Arrange
            var sut = new Randomizer<string>(new List<string> { "a", "b", "c" });

            // Act
            var firstResult = sut.PluckRandomItem();
            var secondResult = sut.PluckRandomItem();
            var thirdResult = sut.PluckRandomItem();

            // Assert
            //Assert.That(result.Count, Doe)
        }
    }
}
