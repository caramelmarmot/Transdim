using Transdim.DomainModel;

namespace Transdim.Service.Controllers.CurrentGame.ScoreTracker
{
    public interface IScoreTrackerComponentController
    {
        Game Game { get; set; }

        void OnInit();

        string GetColClass();

        Player GetPlayerByTurnOrder(int playerIndex);
    }
}