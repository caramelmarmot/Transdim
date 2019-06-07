using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.PowerActions
{
    public class QicPointsForPlanets : IGameComponent, IAdjustablePointsScorer
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.PowerActionQicPointsForPlanets;

        internal const string _ImagePath = "/Images/power-action-qic-points-for-planets.png";

        internal const string _FriendlyName = "Two QIC: Points for Planet Types power action";

        public QicPointsForPlanets() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
