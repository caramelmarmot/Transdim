using System;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Utilities
{
    public class UiComponentScoringUtility
    {
        internal event Action<IGameComponent, int> OnScore;

        internal event Action OnFinishAnimation;

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
