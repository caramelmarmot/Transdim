using System;
using Transdim.DomainModel;
using Transdim.Service.Services;

namespace Transdim.Service.Controllers.Setup.Board
{
    internal class BoardSetupController : IBoardSetupController
    {
        private readonly IGameStateService gameStateService;

        public BoardSetupController(IGameStateService gameStateService)
        {
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public Game GetGame(Guid gameId)
        {
            return gameStateService.LoadGame(gameId);
        }
    }
}
