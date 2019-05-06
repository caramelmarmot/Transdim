using System;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IBoardSetupController
    {
        Game GetGame(Guid gameId);
    }
}
