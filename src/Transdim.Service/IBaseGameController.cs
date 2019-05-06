using System;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IBaseGameController
    {
        Game GetGame(Guid gameId);
    }
}
