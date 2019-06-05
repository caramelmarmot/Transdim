using System;
using Transdim.DomainModel;

namespace Transdim.Persistence.Internal
{
    internal class InMemoryGameRepository : IGameRepository
    {
        public InMemoryGameRepository() { }

        // TODO: better caching? https://michaelscodingspot.com/cache-implementations-in-csharp-net/?utm_source=csharpdigest&utm_medium=email&utm_campaign=featured
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

        public void SaveGame(Game game)
        {
            inMemoryGame = game;
        }
    }
}
