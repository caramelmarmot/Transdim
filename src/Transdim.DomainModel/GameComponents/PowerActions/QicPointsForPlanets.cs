using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.PowerActions
{
    public class QicPointsForPlanets : IGameComponent, IAdjustablePointsScorer
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.PowerActionQicPointsForPlanets;

        internal const string _ImagePath = "/Images/power-action-qic-points-for-planets.png";

        public QicPointsForPlanets() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;
    }
}
