using Transdim.DomainModel.GameComponents;

namespace Transdim.Service
{
    public interface IComponentService
    {
        void Activate(IGameComponent component);
    }
}