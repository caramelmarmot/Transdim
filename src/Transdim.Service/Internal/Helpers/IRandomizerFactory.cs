using System.Collections.Generic;

namespace Transdim.Service.Internal.Helpers
{
    internal interface IRandomizerFactory
    {
        IRandomizer<T> GetRandomizer<T>(List<T> valuesToRandomize) where T : class;
    }
}
