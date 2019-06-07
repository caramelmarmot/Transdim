using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;
using Transdim.DomainModel.Exceptions;
using Transdim.Persistence;

namespace Transdim.Service.Internal.Services
{
    internal class GameStateService : IGameStateService
    {
        private readonly IGameRepository gameRepository;

        // TODO: better caching? https://michaelscodingspot.com/cache-implementations-in-csharp-net/?utm_source=csharpdigest&utm_medium=email&utm_campaign=featured
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

        public Player GetActivePlayer() => CurrentGame.Players.First(p => p.IsActive);

        public Round GetCurrentRound() => CurrentGame.Rounds.First(r => r.State == RoundState.InProgress);

        public List<Player> GetCurrentRoundPlayersInOrder()
        {
            var orderedPlayerIds = GetCurrentRound().OrderedPlayerIds;

            var playerList = new List<Player>();

            foreach (var id in orderedPlayerIds)
            {
                playerList.Add(CurrentGame.Players.First(p => p.Id == id));
            }

            return playerList;
        }
        public void AddAction(string logText, int points = 0, bool omitPlayerNameFromLog = false, bool isUndoCheckpoint = false)
        {
            var activePlayer = GetActivePlayer();

            var optionalPlayerName = (omitPlayerNameFromLog) ? string.Empty : $"{activePlayer.Faction.FriendlyName} ";

            var action = new GameAction
            {
                IsUndoCheckpoint = isUndoCheckpoint,
                Player = activePlayer,
                LogText = $"{optionalPlayerName}{logText}",
                Points = points
            };

            CurrentGame.GameActions.Add(action);
            NotifyStateChanged();
        }

        public void EndTurn() {
            var orderedPlayerIds = GetCurrentRound().OrderedPlayerIds;

            var currentPlayer = GetActivePlayer();
            var currentPlayerIndex = orderedPlayerIds.IndexOf(currentPlayer.Id);

            CurrentGame.GameActions.Add(new GameAction
            {
                Player = currentPlayer,
                LogText = $"{currentPlayer.Faction.FriendlyName} turn complete"
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
