using System.Collections.Generic;

namespace Transdim.DomainModel
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public List<GameAction> GameActions { get; set; }

        public List<Round> Rounds { get; set; }

        // TODO: This is temporary
        public Player PhasingPlayer { get; set; }
    }
}
