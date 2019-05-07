using System.Collections.Generic;

namespace Transdim.Service.Internal.Helpers
{
    internal class RandomizerFactory : IRandomizerFactory
    {
        public IRandomizer<T> GetRandomizer<T>(List<T> valuesToRandomize) where T: class {
            return new Randomizer<T>(valuesToRandomize);
        }
    }
}
