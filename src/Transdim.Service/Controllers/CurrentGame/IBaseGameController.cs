using System;
using Transdim.DomainModel;

namespace Transdim.Service.Controllers.CurrentGame
{
    public interface IBaseGameController
    {
        Game GetGame(Guid gameId);
    }
}
