using System;
using System.Threading.Tasks;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Controllers.CurrentGame.ScoreTracker
{
    public interface IScoreAnimationOverlayController
    {
        bool ShowStatic { get; set; }

        bool ShowAnimated { get; set; }

        bool FadeOutAfterDisplay { get; set; }

        string ImgSrc { get; set; }

        string PointsImgSrc { get; set; }

        void OnInitialized(Action stateHasChanged, Func<Action, Task> invoke);

        void ShowScoredComponent(IGameComponent gameComponent, int points);

        void StartAnimation();
    }
}