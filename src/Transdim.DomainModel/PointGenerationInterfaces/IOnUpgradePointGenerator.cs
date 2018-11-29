using System.Collections.Generic;

namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnUpgradePointGenerator
    {
        string PointsOnUpgradeImagePath { get; }

        void AddPointsOnUpgrade(List<int> pointCollections);
    }
}
