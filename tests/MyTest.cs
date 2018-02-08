using System.Linq;
using FluentAssertions;
using NetChecker;
using Xunit;

namespace tests
{
    public class MyTest
    {
        private T id<T>(T x) => x;

        [Fact]
        public void Identity()
        {
            (new IntProducer()).ChooseFrom().ForAll(x => id(x) == x).Should().BeTrue();
        }

        [Fact]
        public void SomeSquares()
        {
            Gen<int>.FromEnumerable(Enumerable.Range(1, 100)).Any(x => x * x == x).Should().BeTrue();
        }
    }
}