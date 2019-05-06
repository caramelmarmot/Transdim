using Transdim.DomainModel;

namespace Transdim.Service.Internal.Controllers
{
    internal class GameLogController : IGameLogController
    {
        public GameLogController() { }

        public string GetLogText(Game game, int distanceFromEnd)
        {

            if (game == null || game.GameActions.Count <= distanceFromEnd)
            {
                return string.Empty;
            }

            var indexToReport = game.GameActions.Count - distanceFromEnd - 1;

            return game.GameActions[indexToReport].LogText;
        }
    }
}
