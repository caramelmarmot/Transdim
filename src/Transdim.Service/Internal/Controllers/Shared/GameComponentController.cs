using System;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.Internal.Controllers.Shared
{
    internal class GameComponentController : IGameComponentController
    {
        private IGameComponentFactory gameComponentFactory;

        public GameComponentController(IGameComponentFactory gameComponentFactory)
        {
            this.gameComponentFactory = gameComponentFactory ?? throw new ArgumentNullException(nameof(gameComponentFactory));
        }

        public string GetImageSrc(GameComponentIdentifier gameComponentIdentifier)
        {
            //// TODO: Get from ComponentFactory
            var component = gameComponentFactory.GetById(gameComponentIdentifier);
            return component.ImagePath;
        }
    }
}
