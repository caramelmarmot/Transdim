using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IGameLogController
    {
        string GetLogText(Game game, int distanceFromEnd);
    }
}
