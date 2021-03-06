﻿using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.RoundBoosters
{
    public class MineOneOre : IGameComponent, IRoundBooster, IAdjustablePointsScorer, IOnPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.MineOneOre;

        internal const string _ImagePath = "/Images/booster-mine-one-ore.png";

        internal const string _FriendlyName = "Mine/1 Ore round booster";

        public MineOneOre() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
