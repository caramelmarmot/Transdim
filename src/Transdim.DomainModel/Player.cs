using System;
using System.Collections.Generic;
using Transdim.DomainModel.GameComponents;

namespace Transdim.DomainModel
{
    public class Player
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsAutoma { get; set; }

        public Faction Faction { get; set; }

        public bool Passed { get; set; } = false;

        public List<IGameComponent> GameComponents { get; set; } = new List<IGameComponent>();
    }
}
