using System;
using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service.Internal
{
    internal class GameStateService : IGameStateService
    {
        private Game currentGame;

        public GameStateService() {}

        public Game GetGameState() {
            if (currentGame == null)
            {
                throw new InvalidOperationException("Game is currently null");
            }

            return currentGame;
        }

        public void InitializeGame() =>
            currentGame = new Game {
                Players = new List<Player> {
                    new Player { Faction = new Faction { FactionIdentifier = FactionIdentifier.Ambas } },
                    new Player { Faction = new Faction { FactionIdentifier = FactionIdentifier.BalTaks } },
                }
            };
    }
}
