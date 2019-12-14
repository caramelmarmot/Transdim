using System;
using System.Threading.Tasks;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.Service.Services;
using Transdim.Service.Services.Modal;

namespace Transdim.Service.Controllers.CurrentGame.Common
{
    internal class AdjustablePointsScorerModalController : IAdjustablePointsScorerModalController
    {
        public IGameComponent GameComponent { get; set; }

        public string PointsImageSource { get; set; }

        private int points;

        private readonly IModalService modalService;
        private readonly IGameStateService gameStateService;
        private readonly IQueueManagementService queueManagementService;

        public AdjustablePointsScorerModalController(IModalService modalService, IGameStateService gameStateService, IQueueManagementService queueManagementService)
        {
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
        }

        public void OnInitialized(ModalParameters parameters)
        {
            GameComponent = parameters.Get<IGameComponent>(nameof(IGameComponent));
            points = 1;
            SetPointsImgSrc();
        }

        public void AdjustPoints(bool up, Action stateHasChanged)
        {
            if (up && points < 35)
            {
                points++;
                SetPointsImgSrc();
            }
            else if (points > 1)
            {
                points--;
                SetPointsImgSrc();
            }

            stateHasChanged.Invoke();
        }

        public void Close()
        {
            gameStateService.LogAction($"scoring {points} points!", points, true);

            queueManagementService.AddImmediate(new UiComponentScoringEvent(GameComponent, points));

            modalService.Close(ModalResult.Ok(points));
        }

        private void SetPointsImgSrc()
        {
            var pointsString = (points < 10) ? "0" + points.ToString() : points.ToString();
            PointsImageSource = $"/Images/points-{pointsString}.png";
        }
    }
}
