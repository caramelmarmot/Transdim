using System;
using System.Collections.Generic;
using Transdim.DomainModel;
using Transdim.DomainModel.Techs;
using Transdim.Service.Internal.Helpers;

namespace Transdim.Service.Internal.Services
{
    internal class GameInitializationService : IGameInitializationService
    {
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

        public List<TechTrack> GetInitializedTechTrack()
        {
            var randomizer = new Randomizer<ITech>(StandardTechList.Get());

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
