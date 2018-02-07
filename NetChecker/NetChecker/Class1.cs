using System;
using System.Globalization;

namespace NetChecker
{
    public class Class1
    {
    }



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