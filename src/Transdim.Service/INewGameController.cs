using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface INewGameController
    {
        Game InitializeGame(); 

        void StartGame(Game gameToStart);

        bool IsAddPlayerButtonDisabled(Game game);

        bool IsRemovePlayerButtonDisabled(Game game);

        bool IsStartGameDisabled(Game game);

        void AddPlayer(Game game);

        void RemovePlayer(Game game);

        List<Faction> GetAvailableFactions();

        List<Faction> GetUnusedFactions(Game game);

        Faction GetFactionByIdentifier(FactionIdentifier factionIdentifier);
    }
}
