using System.Collections.Generic;

namespace Transdim.DomainModel
{
    public class Round
    {
        public RoundState State { get; set; }

        public List<Player> ActivePlayers { get; set; }

        public List<Player> PassedPlayers { get; set; }
    }
}
