using System.Collections.Generic;

namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnBuildPointGenerator
    {
        string PointsOnBuildImagePath { get; }

        void AddPointsOnBuild(List<int> pointCollections);
    }
}
