using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Controllers.Shared
{
    public interface IGameComponentController
    {
        void Activate(IGameComponent component);
    }
}