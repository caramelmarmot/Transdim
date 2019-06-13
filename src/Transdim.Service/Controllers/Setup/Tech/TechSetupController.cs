using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;
using Transdim.Service.Services;

namespace Transdim.Service.Controllers.Setup.Tech
{
    internal class TechSetupController : ITechSetupController
    {
        private readonly IGameStateService gameStateService;
        private readonly IGameInitializationService gameInitializationService;

        public TechSetupController(IGameStateService gameStateService, IGameInitializationService gameInitializationService)
        {
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
            this.gameInitializationService = gameInitializationService ?? throw new ArgumentNullException(nameof(gameInitializationService));
        }

        public Game GetGameWithInitializedTech(Guid gameId)
        {
            var game = gameStateService.LoadGame(gameId);
            game.TechTrack = gameInitializationService.GetInitializedTechTrack();

            return game;
        }

        public List<TechTrack> GetTechTracks(Game game) => game.TechTrack.Where(t => t.Identifier != TechTrackIdentifier.Wild).OrderBy(t => t.Identifier).ToList();

        public List<TechTrack> GetWildTechs(Game game) => game.TechTrack.Where(t => t.Identifier == TechTrackIdentifier.Wild).ToList();

        public void ClearTech(Game game)
        {
            game.TechTrack = null;
            gameStateService.SaveGame(game);
        }
    }
}
