using System;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Utilities
{
    public class UiComponentScoringUtility
    {
        internal event Action<IGameComponent, int> OnScore;

        public void Score(IGameComponent component, int points)
        {
            OnScore?.Invoke(component, points);
        }
    }
}
