using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IGameInitializationService
    {
        Game InitializeGame();

        List<TechTrack> GetInitializedTechTrack();
    }
}
