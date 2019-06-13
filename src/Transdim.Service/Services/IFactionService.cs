using Transdim.DomainModel;

namespace Transdim.Service.Services
{
    public interface IFactionService
    {
        Faction GetByIdentifier(FactionIdentifier factionIdentifier);
    }
}
