using System.Collections;
using System.Collections.Generic;

namespace NetChecker
{
    public interface IProducer<out T> : IEnumerable<T>
    {
      
    }
    
    public class TupleProducer<T, K> : IProducer<(T, K)>
    {
        private readonly IProducer<T> _tProducer;
        private readonly IProducer<K> _kproducer;

        public TupleProducer(IProducer<T> tProducer, IProducer<K> kproducer)
        {
            _tProducer = tProducer;
            _kproducer = kproducer;
        }
        
        public IEnumerator<(T, K)> GetEnumerator()
        {
            var tenum = _tProducer.GetEnumerator();
            var kenum = _kproducer.GetEnumerator();

            while (tenum.MoveNext() && kenum.MoveNext())
            {
                yield return (tenum.Current, kenum.Current);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}