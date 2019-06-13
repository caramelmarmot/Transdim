using System;
using System.Linq;
using Transdim.DomainModel;
using Transdim.Service.Services;

namespace Transdim.Service.Controllers.CurrentGame.ScoreTracker
{
    internal class PlayerScoreTrackerComponentController : IPlayerScoreTrackerComponentController
    {
        private readonly IGameStateService gameStateService;

        private Game game;

        public PlayerScoreTrackerComponentController(IGameStateService gameStateService)
        {
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public void OnInit(Action stateHasChanged, Player player)
        {
            game = gameStateService.GetGame();
            gameStateService.OnChange += stateHasChanged;
        }

        public string GetColor(Player player)
        {
            return player.Faction.Color.ToString();
        }

        // TODO: This needs to be done much better
        public int GetScore(Player player)
        {
            var actions = game.GameActions.Where(action => action.Player.Id == player.Id);

            var score = 0;

            foreach (var action in actions)
            {
                score = score + action.Points;
            }

            return score;
        }

        public string GetActiveClass(Player player) =>
            (player.IsActive) ? "active" : "";
    }
}
