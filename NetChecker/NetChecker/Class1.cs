using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NetChecker
{
    public class Class1
    {
    }



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

    public static class GenExt
    {
        public static Gen<T> ToGen<T>(this IEnumerable<T> items) => new Gen<T>(items);
    }
}