namespace Transdim.DomainModel.Techs
{
    public class OneOreOneQicOnAcquireTechTile : ITech
    {
        internal const string ImagePath = "/Images/tech-one-ore-one-qic.png";

        internal const bool IsAdvancedTechValue = false;

        public TechIdentifier Identifier => TechIdentifier.OneOreOneQicOnAcquire;

        public string TechImagePath => ImagePath;

        public bool IsAdvancedTech => IsAdvancedTechValue;
    }
}
