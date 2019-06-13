using System.Collections.Generic;
using Transdim.Service.Helpers;

namespace Transdim.Service.Helpers
{
    internal interface IRandomizerFactory
    {
        IRandomizer<T> GetRandomizer<T>(List<T> valuesToRandomize) where T : class;
    }
}
