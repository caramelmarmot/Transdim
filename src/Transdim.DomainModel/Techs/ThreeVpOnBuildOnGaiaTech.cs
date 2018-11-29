using Transdim.DomainModel.PointGenerationInterfaces;

namespace Transdim.DomainModel.Techs
{
    public class ThreeVpOnBuildOnGaiaTech : ITech, IOnBuildPointGenerator
    {
        internal const string ImagePath = "/Images/tech-3-vp-on-build-gaia.png";

        internal const bool IsAdvancedTechValue = false;

        public string TechImagePath { get => ImagePath; }

        public bool IsAdvancedTech { get => IsAdvancedTechValue; }

        public string PointsOnBuildImagePath { get => TechImagePath; }

        public void AddPointsOnBuild(int points)
        {
            points = points + 3;
        }
    }
}
