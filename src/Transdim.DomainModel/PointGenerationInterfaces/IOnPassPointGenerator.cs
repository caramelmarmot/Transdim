namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnPassPointGenerator
    {
        string PointsOnPassImagePath { get; set; }

        void AddPointsOnPass(int points);
    }
}
