using System;
using System.Collections.Generic;
using Transdim.DomainModel;

namespace Transdim.Service.Controllers.Setup.Tech
{
    public interface ITechSetupController
    {
        Game GetGameWithInitializedTech(Guid gameId);

        List<TechTrack> GetTechTracks(Game game);

        List<TechTrack> GetWildTechs(Game game);

        void ClearTech(Game game);
    }
}
