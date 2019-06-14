using Transdim.DomainModel.GameComponents.Actions;
using Transdim.DomainModel.GameComponents.PowerActions;
using Transdim.DomainModel.GameComponents.RoundBoosters;

namespace Transdim.DomainModel.GameComponents
{
    public static class GameComponents
    {
        // Actions
        public static IGameComponent ActionPowerAction { get => new PowerAction(); }

        // Power Actions
        public static IGameComponent PowerActionQicPointsForPlanets { get => new QicPointsForPlanets(); }
        public static IGameComponent PowerActionTwoOre { get => new PowerTwoOre(); }

        // Round Boosters
        public static IGameComponent AcademyFourPower { get => new AcademyFourPower(); }
        public static IGameComponent GaiaFourCredit { get => new GaiaFourCredit(); }
        public static IGameComponent MineOneOre { get => new MineOneOre(); }
        public static IGameComponent ResearchLabOneKnowledge { get => new ResearchLabOneKnowledge(); }
        public static IGameComponent TradingStationOneOre { get => new TradingStationOneOre(); }
    }
}
