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

        public Game GetGame(Guid gameId)
        {
            return gameStateService.LoadGame(gameId);
        }
    }
}
