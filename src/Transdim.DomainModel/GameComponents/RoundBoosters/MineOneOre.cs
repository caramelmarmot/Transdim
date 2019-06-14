using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.RoundBoosters
{
    public class MineOneOre : IGameComponent, IAdjustablePointsOnPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.MineOneOre;

        internal const string _ImagePath = "/Images/booster-mine-one-ore.png";

        internal const string _FriendlyName = "Mine/1 Ore";

        public MineOneOre() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
