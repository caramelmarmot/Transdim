using System;
using Transdim.DomainModel;
using Transdim.Service.Services;

namespace Transdim.Service.Controllers.CurrentGame.ScoreTracker
{
    internal class ScoreTrackerComponentController : IScoreTrackerComponentController
    {
        private readonly IGameStateService gameStateService;

        public ScoreTrackerComponentController(IGameStateService gameStateService)
        {
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public Game Game { get; set; }

        public void OnInit()
        {
            Game = gameStateService.GetGame();
        }

        public string GetColClass()
        {
            if (Game.Players.Count == 2)
            {
                return "col-6";
            }

            if (Game.Players.Count == 3)
            {
                return "col-4";
            }

            if (Game.Players.Count == 4)
            {
                return "col-3";
            }

            throw new InvalidOperationException("Must have between 2 and 4 players");
        }

        public Player GetPlayerByTurnOrder(int playerIndex)
        {
            var playersInOrder = gameStateService.GetCurrentRoundPlayersInOrder();

            return playersInOrder[playerIndex];
        }
    }
}
