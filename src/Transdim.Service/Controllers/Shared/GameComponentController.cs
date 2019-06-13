using System;
using Transdim.DomainModel.GameComponents;
using Transdim.Service.ComponentActivators;

namespace Transdim.Service.Controllers.Shared
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
