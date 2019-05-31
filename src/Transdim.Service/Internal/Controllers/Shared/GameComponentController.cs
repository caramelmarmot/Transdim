using System;
using Transdim.DomainModel.GameComponents;
using Transdim.Service.Internal.ComponentActivators;

namespace Transdim.Service.Internal.Controllers.Shared
{
    internal class GameComponentController : IGameComponentController
    {
        private readonly IComponentActivator compositeComponentActivator;

        public GameComponentController(IComponentActivator compositeComponentActivator)
        {
            this.compositeComponentActivator = compositeComponentActivator ?? throw new ArgumentNullException(nameof(compositeComponentActivator));
        }

        public void Activate(IGameComponent component) => compositeComponentActivator.Activate(component);
    }
}
