using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service
{
    public interface IGameComponentController
    {
        string GetImageSrc(GameComponentIdentifier gameComponentIdentifier);
    }
}
