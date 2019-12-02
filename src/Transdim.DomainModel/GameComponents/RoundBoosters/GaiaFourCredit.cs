using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.RoundBoosters
{
    public class GaiaFourCredit : IGameComponent, IRoundBooster, IAdjustablePointsScorer, IOnPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.GaiaFourCredit;

        internal const string _ImagePath = "/Images/booster-gaia-four-credit.png";

        internal const string _FriendlyName = "Gaia Planets/4 Credits round booster";

        public GaiaFourCredit() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
