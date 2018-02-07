using System;
using System.Collections.Generic;
using System.Linq;

namespace NetChecker
{
    public static class GenExt
    {
        public static Gen<T> ToGen<T>(this IEnumerable<T> items) => new Gen<T>(items);

        public static Gen<T> ChooseFrom<T>(this IEnumerator<T> producer, int count = 100)
        {
            var produced = Choose(producer, count);
            
            return new Gen<T>(produced);
        }

        public static Gen<T> ChooseFrom<T>(this IEnumerable<T> items)
        {
            var selected = Choose(items.ToList());
            
            return new Gen<T>(selected);
        }

        private static IEnumerable<T> Choose<T>(IEnumerator<T> producer, int count = 100)
        {
            while (count-- > 0 && producer.MoveNext())
            {
                yield return producer.Current;
            }
        }

        private static IEnumerable<T> Choose<T>(List<T> from, int count = 100)
        {
            for (int i = 0; i < count; i++)
            {
                yield return from[new Random().Next(from.Count)];
            }
        } 
    }
}