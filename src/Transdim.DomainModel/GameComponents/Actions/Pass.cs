using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.Actions
{
    public class Pass : IGameComponent, IPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.ActionPass;

        internal const string _ImagePath = "/Images/action-pass.png";

        internal const string _FriendlyName = "Pass";

        public Pass() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
