using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IFactionService
    {
        Faction GetByIdentifier(FactionIdentifier factionIdentifier);
    }
}
