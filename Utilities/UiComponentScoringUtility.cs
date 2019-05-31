using System;
using Transdim.DomainModel.GameComponents;
using Transdim.Service;

namespace Transdim.Utilities
{
    public class UiComponentScoringUtility
    {
        internal event Action<IGameComponent, int> OnScore;

        // TODO: should not have a ModalResult parameter. This is a hack.
        internal event Action<ModalResult> OnFinishAnimation;

        public void Score(IGameComponent component, int points)
        {
            OnScore?.Invoke(component, points);
        }

        public void FinishAnimation()
        {
            // TODO: should not have a ModalResult parameter. This is a hack.
                OnFinishAnimation.Invoke(ModalResult.Ok(true));
        }
    }
}
