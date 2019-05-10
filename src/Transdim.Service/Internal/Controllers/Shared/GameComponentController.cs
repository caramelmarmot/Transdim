using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents.PowerActions;

namespace Transdim.Service.Internal.Controllers.Shared
{
    internal class GameComponentController : IGameComponentController
    {
        private PointsForPlanetsQicAction pointsForPlanetsQicAction;

        public GameComponentController(PointsForPlanetsQicAction pointsForPlanetsQicAction)
        {
            this.pointsForPlanetsQicAction = pointsForPlanetsQicAction ?? throw new ArgumentNullException(nameof(pointsForPlanetsQicAction));
        }

        public string GetImageSrc(string componentId)
        {
            //// TODO: Get from ComponentFactory
            var component = pointsForPlanetsQicAction;
            return component.ImagePath;
        }

        public void Activate(string componentId, Game game) {
            //// TODO: Get from ComponentFactory
            var component = pointsForPlanetsQicAction;
            component.OnActivate(game);
        }
    }
}
