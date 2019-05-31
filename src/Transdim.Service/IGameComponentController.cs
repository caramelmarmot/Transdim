using Transdim.DomainModel.GameComponents;

namespace Transdim.Service
{
    public interface IGameComponentController
    {
        void Activate(IGameComponent component);
    }
}