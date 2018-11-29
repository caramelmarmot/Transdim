using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;
using Transdim.Persistence;

namespace Transdim.Service.Internal.Controllers
{
    internal class NewGameController : INewGameController
    {
        private readonly IGameRepository gameRepository;

        public Game InitializeGame() {
            // TODO: load game setup and prepopulate configuration
            
            return new Game()
            {
                Id = Guid.NewGuid(),
                Players = new List<Player> {
                    new Player { FactionIdentifier = FactionIdentifier.Ambas, IsAutoma = false },
                    new Player { FactionIdentifier = FactionIdentifier.BalTaks, IsAutoma = true }
                }
            };
        }
        public NewGameController(IGameRepository gameRepository) {
            this.gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public void StartGame(Game gameToStart) {
            // TODO: save game setup as preferences
            gameRepository.CreateGame(gameToStart);
        }

        public void AddPlayer(Game game) =>
            game.Players.Add(new Player { FactionIdentifier = GetAvailableFactions(game).First() });

        public void RemovePlayer(Game game) =>
            game.Players.RemoveAt(game.Players.Count - 1);

        public bool AddPlayerButtonIsDisabled(Game game) =>
            game.Players.Count == 4;

        public bool RemovePlayerButtonIsDisabled(Game game) =>
            game.Players.Count <= 2;

        public bool StartGameButtonIsDisabled(Game game)
        {
            var moreThanOneAutoma = game.Players.Where(p => p.IsAutoma).Count() > 1;

            var duplicatePlayers = game.Players.GroupBy(p => p.FactionIdentifier).Where(group => group.Count() > 1).Any();

            return moreThanOneAutoma | duplicatePlayers;
        }

        public List<FactionIdentifier> GetAvailableFactions(Game game)
        {
            var factionIdentifiers = Enum.GetValues(typeof(FactionIdentifier)).Cast<FactionIdentifier>();
            return factionIdentifiers.OrderBy(f => f.ToString()).ToList();
        }

    }
}
