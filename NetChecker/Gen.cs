using System.Collections.Generic;
using System.Linq;

namespace NetChecker
{
    public abstract class Gen<T>
    {
        private IEnumerable<T> Items { get; }

        protected Gen(IEnumerable<T> items)
        {
            Items = items;
        }

        public IEnumerable<T> Generate() => Items;
        
        public static Gen<T> Empty() => Enumerable.Empty<T>().ToGen();
        
        public static Gen<T> FromEnumerable(IEnumerable<T> items) => new DefaultGen<T>(items);
    }

    public class DefaultGen<T> : Gen<T>
    {
        public DefaultGen(IEnumerable<T> items) : base(items)
        {
        }
    }
}