namespace Transdim.DomainModel.PointGenerationInterfaces
{
    public interface IOnFederatePointGenerator
    {
        string PointsOnFederateImagePath { get; set; }

        void AddPointsOnFederate(int points);
    }
}
