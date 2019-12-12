using NUnit.Framework;
using Moq;
using Transdim.Service.Services;
using Transdim.Service.ComponentActivators.Actions;
using Transdim.DomainModel.GameComponents.RoundBoosters;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents.Actions;

namespace Transdim.Service.UnitTests.ComponentActivators.Actions
{
    [TestFixture]
    public class PowerActionTakerTests
    {
        private MockRepository moq;
        private Mock<IQueueManagementService> _mockQueueManagementService;
        private Mock<IGameStateService> _mockGameStateService;

        private PowerActionTaker sut;

        [SetUp]
        public void SetUp()
        {
            moq = new MockRepository(MockBehavior.Strict);
            _mockQueueManagementService = moq.Create<IQueueManagementService>();
            _mockGameStateService = moq.Create<IGameStateService>();

            sut = new PowerActionTaker(_mockQueueManagementService.Object, _mockGameStateService.Object);
        }

        [TearDown]
        public void TearDown() => moq.VerifyAll();

        [Test]
        public void Activate_ComponentIsNotPowerActionTaker_DoesNothing()
        {
            //Arrange
            var notAPowerActionTakerComponentButARoundBoosterInstead = new AcademyFourPower();

            //Act
            sut.Activate(notAPowerActionTakerComponentButARoundBoosterInstead);

            //Assert
            _mockQueueManagementService.Verify(m => m.Add(It.IsAny<IUiEvent>()), Times.Never);
            _mockQueueManagementService.Verify(m => m.Execute(), Times.Never);
        }

        [Test]
        // Expected actions are: an immediate log event, an eventual PowerActionPicker modal, a final EndTurn event, and an execute
        public void Activate_ComponentIsPowerActionTaker_AddsExpectedActionsToActionQueueAndExecutes()
        {
            //Arrange
            var powerActionComponent = new PowerAction();

            // Set up the AddImmediate method. It runs the action passed to it as a parameter, so that strict mocks can verify it was correct.
            _mockGameStateService.Setup(m => m.LogAction("took a power action", default, default, true));
            _mockQueueManagementService.Setup(m => m.AddImmediate(It.IsAny<IUiEvent>()))
                .Callback((IUiEvent uiEventPassedAsParameter) =>
                {
                    //
                    var parameterAsGameEvent = uiEventPassedAsParameter as GameEvent;
                    parameterAsGameEvent.EventToPerform();
                });

            //// Set up the Add
            _mockQueueManagementService.Setup(m => m.Add(It.Is<UiModalEvent>(
                e => e.Title == "Power action" &&
                e.ModalIdentifier == ModalIdentifier.PowerActionPicker)
            ));

            // Set up the AddFinal method. It runs the action passed to it as a parameter, so that strict mocks can verify it was correct.
            _mockGameStateService.Setup(m => m.EndTurn());
            _mockQueueManagementService.Setup(m => m.AddFinal(It.IsAny<IUiEvent>()))
                .Callback((IUiEvent uiEventPassedAsParameter) =>
                {
                    var parameterAsGameEvent = uiEventPassedAsParameter as GameEvent;
                    parameterAsGameEvent.EventToPerform();
                });

            // Set up the execute
            _mockQueueManagementService.Setup(m => m.Execute());

            //Act
            sut.Activate(powerActionComponent);

            //Assert - handled by strict mock assertion in teardown
        }
    }
}
