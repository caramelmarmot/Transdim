namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnBuildPointGenerator
    {
        string PointsOnBuildImagePath { get; }

        void AddPointsOnBuild(int points);
    }
}
