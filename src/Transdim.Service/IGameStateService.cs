using System;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IGameStateService
    {
        Game GetGame(Guid gameId);

        void SaveGame(Game game);
    }
}
