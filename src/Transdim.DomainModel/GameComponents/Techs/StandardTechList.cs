using System.Collections.Generic;
using Transdim.DomainModel.GameComponents.Techs.Standard;

namespace Transdim.DomainModel.GameComponents.Techs
{
    public static class StandardTechList
    {
        //public static List<ITech> Get() => new List<ITech>
        //{
        //new BetterBigBuildingsTech(),
        //new SevenPointsOnAcquireTechTile(),
        //new FourCreditsIncomeTech(),
        //new ChargeFourPowerActionTech(),
        //new OneKnowledgeOneCreditIncomeTech(),
        //new OneOreOneQicOnAcquireTechTile(),
        //new ThreeVpOnBuildOnGaiaTech(),
        //new OneOreOnePowerIncomeTech(),
        //new ScienceForPlanetsOnAcquireTechTile()
        //};

        public static List<ITech> Get() => new List<ITech>
        {
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile(),
            new SevenPointsOnAcquireTechTile()
        };
    }
}
