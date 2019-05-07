using System;

namespace Transdim.DomainModel
{
    public class Player
    {
        public Guid Id { get; set; }

        public bool IsAutoma { get; set; }

        public FactionIdentifier FactionIdentifier { get; set; }

        public bool Passed { get; set; }
    }
}
