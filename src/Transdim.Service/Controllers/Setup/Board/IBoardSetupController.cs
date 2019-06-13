using System;
using Transdim.DomainModel;

namespace Transdim.Service.Controllers.Setup.Board
{
    public interface IBoardSetupController
    {
        Game GetGame(Guid gameId);
    }
}
