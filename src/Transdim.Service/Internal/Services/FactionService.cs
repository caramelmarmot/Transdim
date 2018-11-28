using System.Linq;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    internal class FactionService : IFactionService
    {
        public Faction GetByIdentifier(FactionIdentifier factionIdentifier) =>
            Factions.AvailableFactions.FirstOrDefault(faction => faction.FactionIdentifier == factionIdentifier);
    }
}
