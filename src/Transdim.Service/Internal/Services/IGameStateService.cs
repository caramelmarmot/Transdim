using System;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    internal interface IGameStateService
    {
        Game GetGame(Guid gameId);

        void SaveGame(Game game);
    }
}
