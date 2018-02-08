using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NetChecker;
using Xunit;

namespace tests
{
    public class GenTest
    {
        [Fact]
        public void EmptyGen()
        {
            var gen = Gen<int>.Empty();

            gen.Generate().Count().Should().Be(0);
        }

        [Fact]
        public void RandomGen()
        {
            var gen = new List<int>(new[]{1,2,3,4,5,6,7,8,9,10}).ChooseFrom();

            var items = gen.Generate();

            items.Count().Should().Be(100);
            
            foreach (var item in new[]{1,2,3,4,5,6,7,8,9,10})
            {
                items.Contains(item).Should().BeTrue();
            }
        }

        [Fact]
        public void ChooseFromWithProducer()
        {
            var producer = new IntProducer();

            var items = producer.ChooseFrom().Generate();

            items.Count().Should().Be(100);
        }

        [Fact]
        public void ChosseFromWithProducerWithSize()
        {
            var producer = new IntProducer();

            var items = producer.ChooseFrom(20).Generate();

            items.Count().Should().Be(20);
        }
    }
}