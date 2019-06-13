using System;
using Transdim.DomainModel;
using Transdim.Service.Services;

namespace Transdim.Service.Controllers.CurrentGame
{
    internal class BaseGameController : IBaseGameController
    {
        private readonly IGameStateService gameStateService;

        public BaseGameController(IGameStateService gameStateService)
        {
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public void OnInit(Guid gameId)
        {
            gameStateService.LoadGame(gameId);
        }
    }
}
