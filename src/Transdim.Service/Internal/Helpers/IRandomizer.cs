using System;
using System.Collections.Generic;
using System.Text;

namespace Transdim.Service.Internal.Helpers
{
    internal interface IRandomizer<T>
    {
        T PluckRandomItem();
    }
}
