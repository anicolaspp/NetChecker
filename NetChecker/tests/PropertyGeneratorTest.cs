using System.Linq;
using FluentAssertions;
using NetChecker;
using Xunit;

namespace tests
{
    public class PropertyGeneratorTest
    {
        [Fact]
        public void GenerateProperties()
        {
            var gen = new IntProducer().ChooseFrom();

            var properties = PropertyGenerator.GenerateProperties("mustbetrue", gen, i => i == i).ToList();

            properties
                .Select(p => p.Check())
                .ToList()
                .TrueForAll(x => x)
                .Should()
                .BeTrue();
        }
    }
}