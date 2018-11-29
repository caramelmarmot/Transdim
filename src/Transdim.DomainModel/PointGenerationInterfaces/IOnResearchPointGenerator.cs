using System.Collections.Generic;

namespace Transdim.DomainModel.PointGenerationInterfaces
{
    interface IOnResearchPointGenerator
    {
        string PointsOnResearchImagePath { get; }

        void AddPointsOnResearch(List<int> pointCollections);
    }
}
