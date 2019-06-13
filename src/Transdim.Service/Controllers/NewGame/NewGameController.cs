using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;
using Transdim.Service.Services;

namespace Transdim.Service.Controllers.NewGame
{
    internal class NewGameController : INewGameController
    {
        private readonly IGameInitializationService gameInitializationService;

        private readonly IFactionService factionService;

        public NewGameController(IGameInitializationService gameInitializationService, IFactionService factionService)
        {
            this.gameInitializationService = gameInitializationService ?? throw new ArgumentNullException(nameof(gameInitializationService));
            this.factionService = factionService ?? throw new ArgumentNullException(nameof(factionService));
        }

        public Game InitializeGame()
        {
            return gameInitializationService.InitializeGame();
        }

        public void StartGame(Game gameToStart)
        {
            gameInitializationService.StartGame(gameToStart);
        }

        public void AddPlayer(Game game) =>
            game.Players.Add(new Player { Faction = GetUnusedFactions(game).First(), Id = Guid.NewGuid() });

        public void RemovePlayer(Game game) =>
            game.Players.RemoveAt(game.Players.Count - 1);

        public bool IsAddPlayerButtonDisabled(Game game) =>
            game.Players.Count == 4;

        public bool IsRemovePlayerButtonDisabled(Game game) =>
            game.Players.Count <= 2;

        public bool IsStartGameDisabled(Game game)
        {
            var moreThanOneAutoma = game.Players.Where(p => p.IsAutoma).Count() > 1;

            var duplicatePlayers = game.Players.GroupBy(p => p.Faction).Where(group => group.Count() > 1).Any();

            return moreThanOneAutoma | duplicatePlayers;
        }

        public List<Faction> GetAvailableFactions()
        {
            return Factions.AllFactions;
        }

        public List<Faction> GetUnusedFactions(Game game)
        {

            return Factions.AllFactions.Where(faction => !game.Players.Any(player => player.Faction.FactionIdentifier == faction.FactionIdentifier)).OrderBy(f => f.FriendlyName).ToList();
        }

        public Faction GetFactionByIdentifier(FactionIdentifier factionIdentifier) =>
            factionService.GetByIdentifier(factionIdentifier);
    }
}
