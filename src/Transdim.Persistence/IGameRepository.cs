using System;
using Transdim.DomainModel;

namespace Transdim.Persistence
{
    public interface IGameRepository
    {
        Game CreateGame(Game gameToCreate);

        Game GetGame(Guid gameId);
    }
}
