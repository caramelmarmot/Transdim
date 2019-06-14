using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.RoundBoosters
{
    public class TradingStationOneOre : IGameComponent, IAdjustablePointsOnPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.TradingStationOneOre;

        internal const string _ImagePath = "/Images/booster-trade-one-ore.png";

        internal const string _FriendlyName = "Trading Station/1 Ore";

        public TradingStationOneOre() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
