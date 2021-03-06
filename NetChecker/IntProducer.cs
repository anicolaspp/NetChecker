﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NetChecker
{
    public class IntProducer : IProducer<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            while (true)
            {
                yield return new Random().Next();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}