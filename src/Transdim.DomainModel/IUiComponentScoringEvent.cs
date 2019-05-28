using Transdim.DomainModel.GameComponents;

namespace Transdim.DomainModel
{
    public interface IUiComponentScoringEvent : IUiEvent
    {
        IGameComponent GameComponent { get; set; }
        int Points { get; set; }
    }
}
