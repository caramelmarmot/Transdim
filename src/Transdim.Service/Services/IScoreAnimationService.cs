using System;
using System.Threading.Tasks;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Services
{
    public interface IScoreAnimationService
    {
        event Func<Task> StateHasChanged;

        bool IsVisible { get; }

        bool IsInAnimatedDismissal { get; }

        bool FadeOutAfterDismissal { get; set; }

        string ImgSrc { get; }

        string PointsImgSrc { get; }

        Task Score(IGameComponent component, int points);

        void Dismiss();
    }
}