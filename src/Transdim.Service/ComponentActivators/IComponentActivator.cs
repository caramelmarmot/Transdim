using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.ComponentActivators
{
    internal interface IComponentActivator
    {
        void Activate(IGameComponent component);
    }
}
