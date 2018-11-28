using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface INewGameController
    {
        void StartGame(Game gameToStart);

        bool AddPlayerButtonIsDisabled(Game game);

        bool RemovePlayerButtonIsDisabled(Game game);

        void AddPlayer(Game game);

        void RemovePlayer(Game game);

        List<FactionIdentifier> GetAvailableFactions(Game game);
    }
}
