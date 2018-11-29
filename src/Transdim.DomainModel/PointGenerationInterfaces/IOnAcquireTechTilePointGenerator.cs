using System.Collections.Generic;

namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnAcquireTechTilePointGenerator
    {
        string PointsOnAcquireTechTileImagePath { get; }

        void AddPointsOnAcquireTechTile(List<int> pointCollections, int? pointsToAdd);
    }
}
