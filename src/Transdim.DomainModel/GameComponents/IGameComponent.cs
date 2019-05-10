namespace Transdim.DomainModel.GameComponents
{
    public interface IGameComponent
    {
        string ImagePath { get; }

        void OnActivate(Game game);
    }
}
