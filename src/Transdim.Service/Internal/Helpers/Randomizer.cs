using System;
using System.Collections.Generic;
using System.Linq;

namespace Transdim.Service.Internal.Helpers
{
    public class Randomizer<T> where T : class
    {
        private List<T> itemList;
        
        private Random randomizer;

        public Randomizer(List<T> itemList) {
            this.itemList = itemList ?? throw new ArgumentNullException(nameof(itemList));
            randomizer = new Random();
        }

        public T PluckRandomItem()
        {
            var i = randomizer.Next(0, itemList.Count() - 1);

            var item = itemList[i];

            itemList.RemoveAt(i);

            return item;
        }
    }
}
