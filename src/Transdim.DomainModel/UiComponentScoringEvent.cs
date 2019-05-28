using Transdim.DomainModel.GameComponents;

namespace Transdim.DomainModel
{
    public class UiComponentScoringEvent : IUiComponentScoringEvent
    {
        public IGameComponent GameComponent { get; set; }
        public int Points { get; set; }

        public UiComponentScoringEvent(IGameComponent gameComponent, int points)
        {
            GameComponent = gameComponent;
            Points = points;
        }
    }
}
