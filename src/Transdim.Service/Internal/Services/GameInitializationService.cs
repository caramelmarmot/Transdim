using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;
using Transdim.DomainModel.Techs;
using Transdim.Persistence;
using Transdim.Service.Internal.Helpers;

namespace Transdim.Service.Internal.Services
{
    internal class GameInitializationService : IGameInitializationService
    {
        private readonly IRandomizerFactory randomizerFactory;

        private readonly IGameRepository gameRepository;

        public GameInitializationService(IRandomizerFactory randomizerFactory, IGameRepository gameRepository) {
            this.randomizerFactory = randomizerFactory ?? throw new ArgumentNullException(nameof(randomizerFactory));
            this.gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public Game InitializeGame()
        {
            return new Game()
            {
                Id = Guid.NewGuid(),
                Players = new List<Player> {
                    new Player { Id = Guid.NewGuid(), FactionIdentifier = FactionIdentifier.Ambas, IsAutoma = false },
                    new Player { Id = Guid.NewGuid(), FactionIdentifier = FactionIdentifier.BalTaks, IsAutoma = true }
                },
                GameActions = new List<GameAction>()
            };
        }

        public void StartGame(Game gameToStart) {
            // TODO: save game setup as preferences
            foreach (var player in gameToStart.Players)
            {
                gameToStart.GameActions.Add(new GameAction
                {
                    Player = player,
                    LogText = string.Empty,
                    Points = 10
                });
            }

            var nonAutomaPlayers = gameToStart.Players.Where(player => !player.IsAutoma).ToList();
            var randomizer = randomizerFactory.GetRandomizer(nonAutomaPlayers);

            gameToStart.ActivePlayer = randomizer.PluckRandomItem();

            gameRepository.CreateGame(gameToStart);
        }
        
        public List<TechTrack> GetInitializedTechTrack()
        {
            var randomizer = randomizerFactory.GetRandomizer(StandardTechList.Get());

            return new List<TechTrack>
            {
                new TechTrack {
                    Identifier = TechTrackIdentifier.Terraforming,
                    StandardTech = randomizer.PluckRandomItem(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Navigation,
                    StandardTech = randomizer.PluckRandomItem(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.ArtificialIntellegence,
                    StandardTech = randomizer.PluckRandomItem(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Gaiaforming,
                    StandardTech = randomizer.PluckRandomItem(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Economy,
                    StandardTech = randomizer.PluckRandomItem(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Science,
                    StandardTech = randomizer.PluckRandomItem(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Wild,
                    StandardTech = randomizer.PluckRandomItem(),
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Wild,
                    StandardTech = randomizer.PluckRandomItem(),
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Wild,
                    StandardTech = randomizer.PluckRandomItem(),
                }
            };
        }
    }
}
