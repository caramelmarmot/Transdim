using Transdim.DomainModel.GameComponents;

namespace Transdim.Service
{
    public interface IComponentActivationService
    {
        void Activate(IGameComponent component);
    }
}