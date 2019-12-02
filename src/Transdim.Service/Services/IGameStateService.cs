using System;
using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service.Services
{
    public interface IGameStateService
    {
        event Action OnChange;

        Game LoadGame(Guid gameId);

        void SaveGame(Game game);

        Game GetGame();

        void UpdateGame(Game game);

        void AddAction(string logText, int points = 0, bool omitPlayerNameFromLog = false, bool isUndoCheckpoint = false);

        Player GetActivePlayer();

        Round GetCurrentRound();

        List<Player> GetCurrentRoundPlayersInOrder();

        void ScoreOnPass();

        void Pass();

        void EndTurn();
    }
}
