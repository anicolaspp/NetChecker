using System;
using System.Collections.Generic;
using System.Linq;

namespace NetChecker
{
    public static class GenExt
    {
        public static Gen<T> ToGen<T>(this IEnumerable<T> items) => new DefaultGen<T>(items);

        public static Gen<T> ChooseFrom<T>(this IProducer<T> producer, int count = 100)
        {
            var produced = Choose(producer, count);
            
            return new DefaultGen<T>(produced);
        }

        public static Gen<T> ChooseFrom<T>(this IEnumerable<T> items, int count = 100)
        {
            var selected = Choose(items.ToList(), count);
            
            return new DefaultGen<T>(selected);
        }

        public static bool ForAll<T>(this Gen<T> gen, Func<T, Boolean> fn) => 
            PropertyGenerator
                .GenerateProperties("", gen, fn)
                .All(p => p.Check());

        public static bool Any<T>(this Gen<T> gen, Func<T, Boolean> fn) =>
            PropertyGenerator
                .GenerateProperties("", gen, fn)
                .Any(p => p.Check());

        private static IEnumerable<T> Choose<T>(IProducer<T> producer, int count) => producer.Take(count);
        
        private static IEnumerable<T> Choose<T>(List<T> from, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return from[new Random().Next(from.Count)];
            }
        } 
    }
}