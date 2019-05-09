using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel.PointGenerationInterfaces;

namespace Transdim.DomainModel.GameComponents.Techs.Advanced
{
    public class ThreeVpOnBuildOnGaiaTech : ITech, IOnBuildPointGenerator
    {
        internal const string ImagePath = "/Images/tech-3-vp-on-build-gaia.png";

        internal const bool IsAdvancedTechValue = false;

        public TechIdentifier Identifier => TechIdentifier.ThreeVpOnBuildOnGaia;

        public string TechImagePath => ImagePath;

        public bool IsAdvancedTech => IsAdvancedTechValue;

        public string PointsOnBuildImagePath => TechImagePath;

        public void AddPointsOnBuild(List<int> pointCollections)
        {
            for (int i = 0; i < pointCollections.Count(); i++)
            {
                pointCollections[i] += 3;
            }
        }
    }
}
