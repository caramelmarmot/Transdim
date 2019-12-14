using System;
using System.Threading;
using System.Threading.Tasks;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Services
{
    internal class ScoreAnimationService : IScoreAnimationService
    {
        public ScoreAnimationService()
        {
        }

        public event Func<Task> StateHasChanged;

        public bool IsVisible { get; set; } = false;

        public bool IsInAnimatedDismissal { get; set; } = false;

        public bool FadeOutAfterDismissal { get; set; } = true;

        public string ImgSrc { get; set; }

        public string PointsImgSrc { get; set; }

        private readonly SemaphoreSlim signal = new SemaphoreSlim(0, 1);

        public async Task Score(IGameComponent component, int points)
        {
            InitializeServiceAsHidden();
            BindImages(component, points);

            await ShowScoredAndNotifyApp();

            // Wait until the component is clicked on to dismiss
            await signal.WaitAsync();

            await StartAnimatedDismissalAndNotifyApp();

            // Wait for animation to finish
            Thread.Sleep(600);

            InitializeServiceAsHidden();
            await StateHasChanged.Invoke();
        }

        public void Dismiss()
        {
            signal.Release();
        }

        internal void InitializeServiceAsHidden()
        {
            IsVisible = false;
            IsInAnimatedDismissal = false;
            FadeOutAfterDismissal = true;
        }

        internal void BindImages(IGameComponent component, int points)
        {
            ImgSrc = component.ImagePath;

            var pointsString = (points < 10) ? "0" + points.ToString() : points.ToString();
            PointsImgSrc = $"/Images/points-{pointsString}.png";
        }

        internal async Task ShowScoredAndNotifyApp()
        {
            IsVisible = true;
            IsInAnimatedDismissal = false;
            await StateHasChanged.Invoke();
        }

        internal async Task StartAnimatedDismissalAndNotifyApp()
        {
            IsInAnimatedDismissal = true;
            await StateHasChanged.Invoke();
        }
    }
}
