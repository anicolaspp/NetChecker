using System;

namespace NetChecker
{
    public class Property
    {
        public string Name { get; }
       
        private Func<bool> predicate { get; }

        public Property(string name, Func<bool> predicate)
        {
            Name = name;
            this.predicate = predicate;
        }

        public bool Check() => predicate();
    }
}