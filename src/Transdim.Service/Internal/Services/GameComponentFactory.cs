using System;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Actions;
//using Transdim.DomainModel.GameComponents.PowerActions;

namespace Transdim.Service.Internal.Services
{
    internal class GameComponentFactory : IGameComponentFactory
    {
        public IGameComponent GetById(GameComponentIdentifier gameComponent) {
            switch (gameComponent)
            {
                case GameComponentIdentifier.PowerAction:
                    return new PowerAction();
                case GameComponentIdentifier.PointsForPlanetsQicAction:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException($"The component '{gameComponent}' is not handled by the {nameof(GameComponentFactory)}");
            }
        }
    }
}
