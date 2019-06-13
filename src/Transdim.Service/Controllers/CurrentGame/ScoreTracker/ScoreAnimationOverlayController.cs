using System;
using System.Threading.Tasks;
using System.Timers;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.Service.Services;

namespace Transdim.Service.Controllers.CurrentGame.ScoreTracker
{
    internal class ScoreAnimationOverlayController : IScoreAnimationOverlayController
    {
        private readonly IScoreAnimationService scoreAnimationService;
        private readonly IGameStateService gameStateService;
        private readonly IQueueManagementService queueManagementService;

        public bool ShowStatic { get; set; } = false;

        public bool ShowAnimated { get; set; } = false;

        public bool FadeOutAfterDisplay { get; set; } = true;

        public string ImgSrc { get; set; }

        public string PointsImgSrc { get; set; }

        private Timer timer;

        private Action stateHasChanged;

        private Func<Action, Task> invoke;

        public ScoreAnimationOverlayController(IScoreAnimationService scoreAnimationService, IGameStateService gameStateService, IQueueManagementService queueManagementService)
        {
            this.scoreAnimationService = scoreAnimationService ?? throw new ArgumentNullException(nameof(scoreAnimationService));
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
        }

        public void OnInit(Action stateHasChanged, Func<Action, Task> invoke)
        {
            this.stateHasChanged = stateHasChanged;
            this.invoke = invoke;

            timer = new Timer(600);
            scoreAnimationService.OnScore += ShowScoredComponent;
            scoreAnimationService.OnFinishAnimation += OnFinishAnimation;
            gameStateService.OnChange += stateHasChanged;
        }

        public void ShowScoredComponent(IGameComponent gameComponent, int points)
        {
            ImgSrc = gameComponent.ImagePath;

            var pointsString = (points < 10) ? "0" + points.ToString() : points.ToString();
            PointsImgSrc = $"/Images/points-{pointsString}.png";

            ShowStatic = true;
            ShowAnimated = false;
            stateHasChanged.Invoke();
        }

        public void StartAnimation()
        {
            FadeOutAfterDisplay = !(queueManagementService.PreviewNextEvent() is IUiComponentScoringEvent);

            ShowStatic = false;
            ShowAnimated = true;

            timer.Elapsed += FinishAnimation;
            timer.Enabled = true;

            stateHasChanged.Invoke();
        }

        private void FinishAnimation(Object source, ElapsedEventArgs e)
        {
            invoke(() =>
            {
                timer.Elapsed -= FinishAnimation;
                timer.Enabled = false;

                ShowStatic = false;
                ShowAnimated = false;
                FadeOutAfterDisplay = false;
                scoreAnimationService.FinishAnimation();
            });
        }

        private void OnFinishAnimation()
        {
            stateHasChanged.Invoke();
        }
    }
}
