using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.RoundBoosters
{
    public class AcademyFourPower : IGameComponent, IRoundBooster, IAdjustablePointsScorer, IOnPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.AcademyFourPower;

        internal const string _ImagePath = "/Images/booster-academy-four-power.png";

        internal const string _FriendlyName = "Academy/4 Power round booster";

        public AcademyFourPower() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
