using System;
using Transdim.DomainModel;
using Transdim.DomainModel.Exceptions;
using Transdim.Persistence;

namespace Transdim.Service.Internal.Services
{
    internal class GameStateService : IGameStateService
    {
        private readonly IGameRepository gameRepository;

        public GameStateService(IGameRepository gameRepository) {
            this.gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public Game GetGame(Guid gameId) {
            var game = gameRepository.GetGame(gameId);

            if (game == null)
            {
                throw new NotFoundException("Unable to find game");
            }

            return game;
        }

        public void SaveGame(Game game)
        {
            gameRepository.SaveGame(game);
        }
    }
}
