using System;
using Transdim.DomainModel;

namespace Transdim.Persistence.Internal
{
    internal class InMemoryGameRepository : IGameRepository
    {
        public InMemoryGameRepository() { }

        private Game inMemoryGame;

        public Game CreateGame(Game gameToCreate)
        {
            inMemoryGame = gameToCreate;

            return inMemoryGame;
        }

        public Game GetGame(Guid gameId)
        {
            return inMemoryGame;
        }
    }
}
