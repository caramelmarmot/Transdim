using System;
using System.Collections.Generic;

namespace Transdim.DomainModel
{
    public class Round
    {
        public RoundState State { get; set; }

        public List<Guid> OrderedPlayerIds { get; set; }
    }
}
