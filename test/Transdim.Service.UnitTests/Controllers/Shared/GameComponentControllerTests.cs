using NUnit.Framework;
using Moq;
using Transdim.Service.Controllers.Shared;
using Transdim.Service.ComponentActivators;
using Transdim.DomainModel.GameComponents.PowerActions;

namespace Transdim.Service.UnitTests.Controllers.Shared
{
    [TestFixture]
    public class GameComponentControllerTests
    {
        private MockRepository moq;
        private Mock<IComponentActivator> _mockCompositeComponentActivator;
        private GameComponentController sut;

        [SetUp]
        public void SetUp()
        {
            moq = new MockRepository(MockBehavior.Strict);
            _mockCompositeComponentActivator = moq.Create<IComponentActivator>();

            sut = new GameComponentController(_mockCompositeComponentActivator.Object);
        }

        [TearDown]
        public void TearDown() => moq.VerifyAll();

        [Test]
        public void Activate_Always_ActivatesCompositeComponentActivatorWithTheActivatedComponent()
        {
            //Arrange
            var activatedComponent = new QicPointsForPlanets();

            _mockCompositeComponentActivator.Setup(m => m.Activate(activatedComponent));

            //Act
            sut.Activate(activatedComponent);

            //Assert handled by teardown moq.VerifyAll... prove it was hit.
        }
    }
}
