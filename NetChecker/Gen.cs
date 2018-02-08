using System.Collections.Generic;
using System.Linq;

namespace NetChecker
{
    public class Gen<T>
    {
        private IEnumerable<T> Items { get; }

        public Gen(IEnumerable<T> items)
        {
            Items = items;
        }

        public IEnumerable<T> Generate() => Items;
        
        public static Gen<T> Empty() => Enumerable.Empty<T>().ToGen();
    }
}