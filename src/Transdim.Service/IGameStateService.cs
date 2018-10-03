using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IGameStateService
    {
        void InitializeGame();

        Game GetGameState();
    }
}
