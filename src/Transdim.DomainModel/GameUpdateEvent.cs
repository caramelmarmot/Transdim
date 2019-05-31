using System;

namespace Transdim.DomainModel
{
    public class GameUpdateEvent : IGameUpdateEvent
    {
        public Action EventToPerform { get; set; }
    }
}
