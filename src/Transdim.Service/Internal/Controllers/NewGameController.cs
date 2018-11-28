using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Controllers
{
    internal class NewGameController : INewGameController
    {
        public void StartGame(Game gameToStart)
        {
            Console.WriteLine(gameToStart.Players.First().FactionIdentifier.ToString());
        }

        public void AddPlayer(Game game) =>
            game.Players.Add(new Player { FactionIdentifier = GetAvailableFactions(game).First() });

        public void RemovePlayer(Game game) =>
            game.Players.RemoveAt(game.Players.Count - 1);

        public bool AddPlayerButtonIsDisabled(Game game) =>
            game.Players.Count == 4;

        public bool RemovePlayerButtonIsDisabled(Game game) =>
            game.Players.Count <= 2;

        public List<FactionIdentifier> GetAvailableFactions(Game game)
        {
            var factionIdentifiers = Enum.GetValues(typeof(FactionIdentifier)).Cast<FactionIdentifier>();
            return factionIdentifiers.Where(factionIdentifier => !game.Players.Any(player => player.FactionIdentifier == factionIdentifier)).OrderBy(f => f.ToString()).ToList();
        }
    }
}
