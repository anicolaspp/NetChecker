using System.Collections.Generic;

namespace NetChecker
{
    public interface IProducer<out T> : IEnumerable<T>
    {
      
    }
}