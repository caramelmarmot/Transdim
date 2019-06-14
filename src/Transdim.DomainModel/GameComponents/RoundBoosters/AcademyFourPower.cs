using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.RoundBoosters
{
    public class AcademyFourPower : IGameComponent, IAdjustablePointsOnPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.PowerActionTwoOre;

        internal const string _ImagePath = "/Images/booster-academy-four-power.png";

        internal const string _FriendlyName = "Academy/4 Power";

        public AcademyFourPower() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
