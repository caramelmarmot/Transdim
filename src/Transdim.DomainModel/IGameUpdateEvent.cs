using System;

namespace Transdim.DomainModel
{
    public interface IGameUpdateEvent : IUiEvent
    {
        Action EventToPerform { get; set; }
    }
}
