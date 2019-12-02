using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Controllers.CurrentGame.Common
{
    public interface IAdjustablePointsScorerModalController
    {
        IGameComponent GameComponent { get; set; }

        string PointsImageSource { get; set; }

        void OnInitialized(ModalParameters parameters);

        void AdjustPoints(bool up, Action stateHasChanged);

        void Close();
    }
}