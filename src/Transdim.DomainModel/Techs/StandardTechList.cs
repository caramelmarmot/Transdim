using System.Collections.Generic;

namespace Transdim.DomainModel.Techs
{
    public static class StandardTechList
    {
        public static List<ITech> Get() => new List<ITech>
        {
            new BetterBigBuildingsTech(),
            new SevenPointsOnAcquireTechTile(),
            new FourCreditsIncomeTech(),
            new ChargeFourPowerActionTech(),
            new OneKnowledgeOneCreditIncomeTech(),
            new OneOreOneQicOnAcquireTechTile(),
            new ThreeVpOnBuildOnGaiaTech(),
            new OneOreOnePowerIncomeTech(),
            new ScienceForPlanetsOnAcquireTechTile()
        };
    }
}
