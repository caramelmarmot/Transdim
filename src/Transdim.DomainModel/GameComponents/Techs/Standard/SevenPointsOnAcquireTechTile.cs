using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel.PointGenerationInterfaces;

namespace Transdim.DomainModel.GameComponents.Techs.Standard
{
    public class SevenPointsOnAcquireTechTile : ITech, IOnAcquireTechTilePointGenerator
    {
        internal const string ImagePath = "/Images/tech-seven-points-on-acquire.png";

        internal const bool IsAdvancedTechValue = false;

        public TechIdentifier Identifier => TechIdentifier.SevenPointsOnAcquireTechTile;

        public string TechImagePath => ImagePath;

        public bool IsAdvancedTech => IsAdvancedTechValue;

        public string PointsOnAcquireTechTileImagePath => ImagePath;

        public void AddPointsOnAcquireTechTile(List<int> pointCollections, int? pointsToAdd)
        {
            for (int i = 0; i < pointCollections.Count(); i++)
            {
                pointCollections[i] += 7;
            }
        }
    }
}
