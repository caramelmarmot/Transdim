using System;

namespace Transdim.DomainModel
{
    public interface IGameEvent : IUiEvent
    {
        Action EventToPerform { get; set; }
    }
}
