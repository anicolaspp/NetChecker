using System;
using System.Collections;
using System.Collections.Generic;

namespace NetChecker
{
    public class IntProducer : IEnumerator<int>
    {
        public bool MoveNext()
        {
            return true;
        }

        public void Reset()
        {
           
        }

        object IEnumerator.Current => Current;

        public int Current => new Random().Next();


        public void Dispose()
        {
        }
    }
}