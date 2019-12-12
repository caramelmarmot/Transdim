using System;

namespace Transdim.DomainModel
{
    public class GameEvent : IGameEvent
    {
        public Action EventToPerform { get; set; }
    }
}
