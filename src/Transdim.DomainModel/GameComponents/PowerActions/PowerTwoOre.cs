namespace Transdim.DomainModel.GameComponents.PowerActions
{
    public class PowerTwoOre : IGameComponent
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.PowerActionTwoOre;

        internal const string _ImagePath = "/Images/power-action-two-ore.png";

        internal const string _FriendlyName = "";

        public PowerTwoOre() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
