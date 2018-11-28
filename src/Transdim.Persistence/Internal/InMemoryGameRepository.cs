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
    }
}
