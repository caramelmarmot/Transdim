using System;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IGameStateService
    {
        Game Game { get; set; }

        event Action OnChange;

        Game LoadGame(Guid gameId);

        void SaveGame(Game game);

        void UpdateGame(Game game);
    }
}
