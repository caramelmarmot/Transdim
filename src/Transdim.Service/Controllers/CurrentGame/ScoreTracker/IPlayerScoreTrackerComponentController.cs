using System;
using Transdim.DomainModel;

namespace Transdim.Service.Controllers.CurrentGame.ScoreTracker
{
    public interface IPlayerScoreTrackerComponentController
    {
        void OnInitialized(Action stateHasChanged, Player player);

        string GetColor(Player player);

        int GetScore(Player player);

        string GetActiveClass(Player player);
    }
}