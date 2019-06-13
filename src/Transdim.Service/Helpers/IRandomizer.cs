using System;
using System.Collections.Generic;
using System.Text;

namespace Transdim.Service.Helpers
{
    internal interface IRandomizer<T>
    {
        T PluckRandomItem();
    }
}
