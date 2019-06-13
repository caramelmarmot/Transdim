using System;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;
using Transdim.Service.Services;
using Transdim.Service.Services.Modal;

namespace Transdim.Service.Controllers.CurrentGame.ActionPanel.PowerAction
{
    internal class PowerActionModalController : IPowerActionModalController
    {
        private readonly IGameStateService gameStateService;

        private readonly IModalService modalService;

        public PowerActionModalController(IGameStateService gameStateService, IModalService modalService)
        {
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
        }

        public void CloseModal(IGameComponent gameComponent)
        {
            var optionalEllipses = (gameComponent is IAdjustablePointsScorer) ? "..." : string.Empty;

            gameStateService.AddAction($"chose the {gameComponent.FriendlyName}{optionalEllipses}");
            modalService.Close(ModalResult.Ok());
        }
    }
}
