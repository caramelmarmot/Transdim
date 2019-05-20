using Transdim.DomainModel.GameComponents.Actions;
using Transdim.DomainModel.GameComponents.PowerActions;

namespace Transdim.DomainModel.GameComponents
{
    public static class GameComponents
    {
        // Actions
        public static IGameComponent ActionPowerAction { get => new PowerAction(); }

        // Power Actions
        public static IGameComponent PowerActionQicPointsForPlanets { get => new QicPointsForPlanets(); }
        public static IGameComponent PowerActionTwoOre { get => new PowerTwoOre(); }
    }
}
