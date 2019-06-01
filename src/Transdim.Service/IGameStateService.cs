using System;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IGameStateService
    {
        event Action OnChange;

        Game LoadGame(Guid gameId);

        void SaveGame(Game game);

        Game GetGame();

        void UpdateGame(Game game);

        void AddAction(GameAction action);

        Player GetActivePlayer();

        void EndTurn();
    }
}
