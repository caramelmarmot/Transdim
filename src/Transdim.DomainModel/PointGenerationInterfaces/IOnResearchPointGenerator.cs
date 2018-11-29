namespace Transdim.DomainModel.PointGenerationInterfaces
{
    interface IOnResearchPointGenerator
    {
        string PointsOnResearchImagePath { get; set; }

        void AddPointsOnResearch(int points);
    }
}
