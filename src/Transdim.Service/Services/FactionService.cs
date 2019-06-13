using System.Linq;
using Transdim.DomainModel;

namespace Transdim.Service.Services
{
    internal class FactionService : IFactionService
    {
        public Faction GetByIdentifier(FactionIdentifier factionIdentifier) =>
            Factions.AllFactions.FirstOrDefault(faction => faction.FactionIdentifier == factionIdentifier);
    }
}
