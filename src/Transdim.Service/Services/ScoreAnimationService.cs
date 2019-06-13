using System;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Services
{
    internal class ScoreAnimationService : IScoreAnimationService
    {
        public event Action<IGameComponent, int> OnScore;

        public event Action OnFinishAnimation;

        public void Score(IGameComponent component, int points)
        {
            OnScore?.Invoke(component, points);
        }

        public void FinishAnimation()
        {
            OnFinishAnimation?.Invoke();
        }
    }
}
