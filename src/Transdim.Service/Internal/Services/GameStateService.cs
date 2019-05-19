using System;
using Transdim.DomainModel;
using Transdim.DomainModel.Exceptions;
using Transdim.Persistence;

namespace Transdim.Service.Internal.Services
{
    internal class GameStateService : IGameStateService
    {
        private readonly IGameRepository gameRepository;

        public Game Game { get; set; }

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

            Game = game;
            return game;
        }

        // TODO: Get rid of the parameter
        public void SaveGame(Game game)
        {
            gameRepository.SaveGame(game);
        }

        public void UpdateGame(Game game)
        {
            Game = game;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
