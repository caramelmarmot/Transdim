using System;
using System.Linq;
using Transdim.DomainModel;
using Transdim.DomainModel.Exceptions;
using Transdim.Persistence;

namespace Transdim.Service.Internal.Services
{
    internal class GameStateService : IGameStateService
    {
        private readonly IGameRepository gameRepository;

        public Game CurrentGame { get; set; }

        public event Action OnChange;

        public GameStateService(IGameRepository gameRepository) {
            this.gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        // TODO: get rid of the return
        public Game LoadGame(Guid gameId) {
            var game = gameRepository.GetGame(gameId);

            if (game == null)
            {
                throw new NotFoundException("Unable to find game");
            }

            CurrentGame = game;
            return game;
        }

        // TODO: Get rid of the parameter
        public void SaveGame(Game game)
        {
            gameRepository.SaveGame(game);
        }

        public Game GetGame() => CurrentGame;

        public void UpdateGame(Game game)
        {
            CurrentGame = game;
            NotifyStateChanged();
        }

        public void EndTurn() {
            var orderedPlayerIds = CurrentGame.Rounds.First(r => r.State == RoundState.InProgress).OrderedPlayerIds;

            var currentPlayer = CurrentGame.Players.First(p => p.IsActive);
            var currentPlayerIndex = orderedPlayerIds.IndexOf(currentPlayer.Id);

            CurrentGame.GameActions.Add(new GameAction
            {
                Player = currentPlayer,
                LogText = $"{currentPlayer.Faction.FriendlyName} turn complete!"
            });

            var maxIndex = orderedPlayerIds.Count - 1;
            var nextPlayerIndex = (currentPlayerIndex == maxIndex) ? 
                0 : 
                currentPlayerIndex + 1;

            var nextPlayerId = orderedPlayerIds[nextPlayerIndex];

            foreach (var player in CurrentGame.Players)
            {
                player.IsActive = (player.Id == nextPlayerId);
            }

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
