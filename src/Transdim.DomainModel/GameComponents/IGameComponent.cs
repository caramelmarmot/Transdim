namespace Transdim.DomainModel.GameComponents
{
    public interface IGameComponent
    {
        GameComponentIdentifier GameComponentIdentifier { get; }

        string ImagePath { get; }

        void OnActivate(Game game);
    }
}
