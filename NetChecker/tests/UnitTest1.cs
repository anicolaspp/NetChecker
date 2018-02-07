using System;
using System.Linq;
using FluentAssertions;
using NetChecker;
using Xunit;

namespace tests
{
   public class PropertyTest
   {

      [Fact]
      public void CreateProperty()
      {
          var property = new Property("true", () => true);

          property.Name.Should().Be("true");
          property.Check().Should().Be(true);
      }

       [Fact]
       public void FailedProperty()
       {
           var property = new Property("failed", () => 5 == 4);

           property.Check().Should().BeFalse();
       }

       [Fact]
       public void TrueProperty()
       {
           var property = new Property("pass", () => 5 == 5);

           property.Check().Should().BeTrue();
       }
   }

    public class GenTest
    {
        [Fact]
        public void EmptyGen()
        {
            var gen = Gen<int>.Empty();

            gen.Generate().Count().Should().Be(0);
        }
    }
}