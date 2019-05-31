using System;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service
{
    public interface IScoreAnimationService
    {
        event Action<IGameComponent, int> OnScore;

        event Action OnFinishAnimation;

        void FinishAnimation();

        void Score(IGameComponent component, int points);
    }
}