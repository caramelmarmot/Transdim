    using System;
using System.Collections.Generic;
using System.Linq;

namespace Transdim.DomainModel
{
    public class Game
    {
        public Guid Id { get; set; }

        public List<Player> Players { get; set; }

        public Player ActivePlayer { get => Players.First(p => p.IsActive == true); }

        public List<GameAction> GameActions { get; set; }

        public List<Round> Rounds { get; set; }

        public string MapLink { get; set; }

        public List<TechTrack> TechTrack { get; set; }
    }
}
