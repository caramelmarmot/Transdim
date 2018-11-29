using System;
using System.Collections.Generic;
using Transdim.DomainModel;
using Transdim.DomainModel.Techs;

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
                    new Player { FactionIdentifier = FactionIdentifier.Ambas, IsAutoma = false },
                    new Player { FactionIdentifier = FactionIdentifier.BalTaks, IsAutoma = true }
                }
            };
        }

        public List<TechTrack> GetInitializedTechTrack()
        {
            return new List<TechTrack>
            {
                new TechTrack {
                    Identifier = TechTrackIdentifier.Terraforming,
                    StandardTech = new BetterBigBuildingsTech(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Navigation,
                    StandardTech = new BetterBigBuildingsTech(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.ArtificialIntellegence,
                    StandardTech = new BetterBigBuildingsTech(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Gaiaforming,
                    StandardTech = new BetterBigBuildingsTech(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Economy,
                    StandardTech = new BetterBigBuildingsTech(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Science,
                    StandardTech = new BetterBigBuildingsTech(),
                    AdvancedTech = new ThreeVpOnBuildOnGaiaTech()
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Wild,
                    StandardTech = new BetterBigBuildingsTech(),
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Wild,
                    StandardTech = new BetterBigBuildingsTech(),
                },
                new TechTrack {
                    Identifier = TechTrackIdentifier.Wild,
                    StandardTech = new BetterBigBuildingsTech(),
                }
            };
        }
    }
}
