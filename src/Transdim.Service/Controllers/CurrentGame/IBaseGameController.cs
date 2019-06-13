using System;
using Transdim.DomainModel;

namespace Transdim.Service.Controllers.CurrentGame
{
    public interface IBaseGameController
    {
        void OnInit(Guid gameId);
    }
}
