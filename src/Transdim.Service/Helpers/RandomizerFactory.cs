using System.Collections.Generic;
using Transdim.Service.Helpers;

namespace Transdim.Service.Helpers
{
    internal class RandomizerFactory : IRandomizerFactory
    {
        public IRandomizer<T> GetRandomizer<T>(List<T> valuesToRandomize) where T : class
        {
            return new Randomizer<T>(valuesToRandomize);
        }
    }
}
