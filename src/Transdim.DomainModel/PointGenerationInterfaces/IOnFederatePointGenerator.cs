using System.Collections.Generic;

namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnFederatePointGenerator
    {
        string PointsOnFederateImagePath { get; }

        void AddPointsOnFederate(List<int> pointCollections);
    }
}
