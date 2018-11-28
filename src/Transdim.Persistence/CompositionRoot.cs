using System;
using Microsoft.Extensions.DependencyInjection;
using Transdim.Persistence.Internal;

namespace Transdim.Persistence
{
    public static class CompositionRoot
    {
        public static void AddTransdimPersistence(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<IGameRepository, InMemoryGameRepository>();
        }
    }
}
