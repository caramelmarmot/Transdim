using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Internal.ComponentActivators
{
    internal interface IComponentActivator
    {
        void Activate(IGameComponent component);
    }
}
