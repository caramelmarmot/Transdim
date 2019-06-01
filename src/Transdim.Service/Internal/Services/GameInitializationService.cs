using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents.Techs;
using Transdim.DomainModel.GameComponents.Techs.Advanced;
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
                    new Player { Id = Guid.NewGuid(), Faction = Factions.Ambas, IsAutoma = false },
                    new Player { Id = Guid.NewGuid(), Faction = Factions.BalTaks, IsAutoma = true }
                },
                GameActions = new List<GameAction>()
            };
        }

        public void StartGame(Game gameToStart) {
            foreach (var player in gameToStart.Players)
            {
                gameToStart.GameActions.Add(new GameAction
                {
                    Player = player,
                    LogText = string.Empty,
                    Points = 10
                });
            }

            // TODO: Make rounds bettera
            SetUpDummyRound(gameToStart);

            gameRepository.CreateGame(gameToStart);
        }

        public void SetUpDummyRound(Game gameToStart)
        {
            var nonAutomaPlayers = gameToStart.Players.Where(player => !player.IsAutoma).ToList();
            var automaPlayers = gameToStart.Players.Where(player => player.IsAutoma).ToList();

            var nonAutomaRandomizer = randomizerFactory.GetRandomizer(nonAutomaPlayers);
            var automaRandomizer = randomizerFactory.GetRandomizer(automaPlayers);

            var orderedPlayerIdList = new List<Guid>();

            var nonAutomaCount = nonAutomaPlayers.Count;
            var automaCount = automaPlayers.Count;

            for (int i = 0; i < nonAutomaCount; i++)
            {
                orderedPlayerIdList.Add(nonAutomaRandomizer.PluckRandomItem().Id);
            }

            for (int i = 0; i < automaCount; i++)
            {
                orderedPlayerIdList.Add(automaRandomizer.PluckRandomItem().Id);
            }

            gameToStart.Rounds = new List<Round> {
                new Round { OrderedPlayerIds = orderedPlayerIdList, State = RoundState.InProgress }
            };

            gameToStart.Players.First(p => p.Id == orderedPlayerIdList.First()).IsActive = true;
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
