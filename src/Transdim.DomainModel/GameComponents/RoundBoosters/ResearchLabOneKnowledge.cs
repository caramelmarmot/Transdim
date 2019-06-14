using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.RoundBoosters
{
    public class ResearchLabOneKnowledge : IGameComponent, IRoundBooster, IAdjustablePointsOnPasser
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.ResearchLabOneKnowledge;

        internal const string _ImagePath = "/Images/booster-research-lab-one-knowledge.png";

        internal const string _FriendlyName = "Research Lab/1 Knowledge";

        public ResearchLabOneKnowledge() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public string FriendlyName => _FriendlyName;
    }
}
