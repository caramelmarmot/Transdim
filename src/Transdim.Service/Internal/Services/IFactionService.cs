using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    public interface IFactionService
    {
        Faction GetByIdentifier(FactionIdentifier factionIdentifier);
    }
}
