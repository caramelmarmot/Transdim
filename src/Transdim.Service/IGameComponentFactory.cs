using Transdim.DomainModel.GameComponents;

namespace Transdim.Service
{
    public interface IGameComponentFactory
    {
        IGameComponent GetById(GameComponentIdentifier gameComponent);
    }
}
