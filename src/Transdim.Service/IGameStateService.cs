using System;
using System.Collections.Generic;
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

        Round GetCurrentRound();

        List<Player> GetCurrentRoundPlayersInOrder();

        void EndTurn();
    }
}
