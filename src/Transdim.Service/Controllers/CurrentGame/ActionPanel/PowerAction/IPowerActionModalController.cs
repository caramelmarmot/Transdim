using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Controllers.CurrentGame.ActionPanel.PowerAction
{
    public interface IPowerActionModalController
    {
        void CloseModal(IGameComponent gameComponent);
    }
}
