using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IGameComponentController
    {
        string GetImageSrc(string componentId);

        void Activate(string componentId, Game game);
    }
}
