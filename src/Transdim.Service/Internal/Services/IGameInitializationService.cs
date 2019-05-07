using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    internal interface IGameInitializationService
    {
        Game InitializeGame();

        List<TechTrack> GetInitializedTechTrack();

        void StartGame(Game gameToStart);
    }
}
