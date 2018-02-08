using System;
using System.Collections;
using System.Collections.Generic;

namespace NetChecker
{
    public class StringProducer : IProducer<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            while (true)
            {
                yield return new Random().Next().ToString();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}