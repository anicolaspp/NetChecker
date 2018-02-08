using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetChecker
{
    public static class PropertyGenerator
    {
        public static IEnumerable<Property> GenerateProperties<T>(string groupName, Gen<T> generator, Func<T, Boolean> fn) 
            => generator
                .Generate()
                .Select(item => new Property(groupName + item, () => fn(item)));
    }
    
    
}