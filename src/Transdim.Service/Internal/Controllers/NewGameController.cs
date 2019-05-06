using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;
using Transdim.Persistence;
using Transdim.Service.Internal.Services;

namespace Transdim.Service.Internal.Controllers
{
    internal class NewGameController : INewGameController
    {
        private readonly IGameRepository gameRepository;

        private readonly IGameInitializationService gameInitializationService;

        private readonly IFactionService factionService;

        public NewGameController(IGameRepository gameRepository, IGameInitializationService gameInitializationService, IFactionService factionService)
        {
            this.gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            this.gameInitializationService = gameInitializationService ?? throw new ArgumentNullException(nameof(gameInitializationService));
            this.factionService = factionService ?? throw new ArgumentNullException(nameof(factionService));
        }

        public Game InitializeGame() {
            // TODO: load game setup and prepopulate configuration

            return gameInitializationService.InitializeGame();
        }

        public void StartGame(Game gameToStart) {
            // TODO: save game setup as preferences
            gameRepository.CreateGame(gameToStart);
        }

        public void AddPlayer(Game game) =>
            game.Players.Add(new Player { FactionIdentifier = GetUnusedFactions(game).First() });

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

        public List<FactionIdentifier> GetAvailableFactions()
        {
            var factionIdentifiers = Enum.GetValues(typeof(FactionIdentifier)).Cast<FactionIdentifier>();
            return factionIdentifiers.OrderBy(f => f.ToString()).ToList();
        }

        public List<FactionIdentifier> GetUnusedFactions(Game game)
        {
            var factionIdentifiers = Enum.GetValues(typeof(FactionIdentifier)).Cast<FactionIdentifier>();
            return factionIdentifiers.Where(factionIdentifier => !game.Players.Any(player => player.FactionIdentifier == factionIdentifier)).OrderBy(f => f.ToString()).ToList();
        }

        public Faction GetFactionByIdentifier(FactionIdentifier factionIdentifier) =>
            factionService.GetByIdentifier(factionIdentifier);
    }
}
