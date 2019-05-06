using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface INewGameController
    {
        Game InitializeGame(); 

        void StartGame(Game gameToStart);

        bool AddPlayerButtonIsDisabled(Game game);

        bool RemovePlayerButtonIsDisabled(Game game);

        bool StartGameButtonIsDisabled(Game game);

        void AddPlayer(Game game);

        void RemovePlayer(Game game);

        List<FactionIdentifier> GetAvailableFactions();

        List<FactionIdentifier> GetUnusedFactions(Game game);

        Faction GetFactionByIdentifier(FactionIdentifier factionIdentifier);
    }
}
