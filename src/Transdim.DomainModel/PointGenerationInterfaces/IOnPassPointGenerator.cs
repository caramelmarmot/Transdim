using System.Collections.Generic;

namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnPassPointGenerator
    {
        string PointsOnPassImagePath { get; }

        void AddPointsOnPass(List<int> pointCollections, int? pointsToAdd);
    }
}
