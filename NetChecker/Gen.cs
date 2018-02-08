using System.Collections;
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
        
        public static Gen<T> FromEnumerable(IEnumerable<T> items) => items.ToGen();

        public static Gen<T> Repeat(T item, int count = 100) => Enumerable.Repeat(item, count).ToGen();
        
        public static Gen<T> Once(T item) => new[] {item}.ToGen();

        public static Gen<(T, K)> Join<T, K>(Gen<T> tGen, Gen<K> kGen) =>
            new TupleProducer<T, K>(GetProducerFrom(tGen), GetProducerFrom(kGen)).ToGen();

        private static IProducer<A> GetProducerFrom<A>(Gen<A> gen) => new SimpleProducer<A>(gen);   
    }

    public class DefaultGen<T> : Gen<T>
    {
        public DefaultGen(IEnumerable<T> items) : base(items)
        {
        }
    }

    internal class SimpleProducer<A> : IProducer<A>
    {
        private readonly Gen<A> _gen;

        public SimpleProducer(Gen<A> gen)
        {
            _gen = gen;
        }
            
        public IEnumerator<A> GetEnumerator()
        {
            return _gen.Generate().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}