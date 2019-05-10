using Blazored.Modal.Services;
using System;

namespace Transdim.DomainModel.GameComponents.PowerActions
{
    public class PointsForPlanetsQicAction : IGameComponent
    {
        private readonly IModalService modalService;
        private readonly Type pointSelectorModalType;

        public PointsForPlanetsQicAction(IModalService modalService, Type pointSelectorModalType)
        {
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
            this.pointSelectorModalType = pointSelectorModalType ?? throw new ArgumentNullException(nameof(pointSelectorModalType));
        }

        internal const string _ImagePath = "/Images/tech-seven-points-on-acquire.png";

        public string ImagePath => _ImagePath;

        public void OnActivate(Game game)
        {
            modalService.Cancel();

            modalService.OnClose += PointSelectorModalClosed;
            modalService.Show("Power Action", pointSelectorModalType);
        }

        void PointSelectorModalClosed(ModalResult modalResult)
        {
            modalService.OnClose -= PointSelectorModalClosed;

            if (modalResult.Cancelled)
            {
                Console.WriteLine("Modal was cancelled");
            }
            else
            {
                Console.WriteLine(modalResult.Data);
            }
        }
    }
}
