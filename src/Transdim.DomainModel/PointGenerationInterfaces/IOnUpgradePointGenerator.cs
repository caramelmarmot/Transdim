namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnUpgradePointGenerator
    {
        string PointsOnUpgradeImagePath { get; set; }

        void AddPointsOnUpgrade(int points);
    }
}
