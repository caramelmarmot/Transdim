using System;
using System.Collections.Generic;
using Transdim.DomainModel.GameComponents;

namespace Transdim.Service.ComponentActivators
{
    internal class CompositeComponentActivator : IComponentActivator
    {
        private readonly List<IComponentActivator> componentActivators;

        public CompositeComponentActivator(List<IComponentActivator> componentActivators)
        {
            this.componentActivators = componentActivators ?? throw new ArgumentNullException(nameof(componentActivators));
        }

        public void Activate(IGameComponent component)
        {
            foreach (var activator in componentActivators)
            {
                activator.Activate(component);
            }
        }
    }
}
