namespace Transdim.DomainModel.Techs
{
    public class BetterBigBuildingsTech : ITech
    {
        internal const string ImagePath = "/Images/tech-better-buildings.png";

        internal const bool IsAdvancedTechValue = false;

        public string TechImagePath { get => ImagePath; }

        public bool IsAdvancedTech { get => IsAdvancedTechValue; }
    }
}
