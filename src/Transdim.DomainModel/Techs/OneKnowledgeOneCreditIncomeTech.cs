namespace Transdim.DomainModel.Techs
{
    public class OneKnowledgeOneCreditIncomeTech : ITech
    {
        internal const string ImagePath = "/Images/tech-one-knowledge-one-credit-income.png";

        internal const bool IsAdvancedTechValue = false;

        public TechIdentifier Identifier => TechIdentifier.OneKnowledgeOneCreditIncome;

        public string TechImagePath => ImagePath;

        public bool IsAdvancedTech => IsAdvancedTechValue;
    }
}
