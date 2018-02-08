# NetChecker
.NET Minimalist Property Based Framework

Using  `NetChecker` we can write tests on the following way

```
namespace tests
{
    public class MyTest
    {
        private T id<T>(T x) => x;
        private int sqr(int x) => x * x;
        private string comcat(string a, string b) => a + b; 

        [Fact]
        public void Identity()
        {
            (new IntProducer())
              .ChooseFrom()
              .ForAll(x => id(x) == x)
              .Should()
              .BeTrue();
        }

        [Fact]
        public void SomeSquares()
        {
            Gen<int>
              .FromEnumerable(Enumerable.Range(1, 100))
              .Any(x => sqr(x) == x)
              .Should()
              .BeTrue();
        }

        [Fact]
        public void Comcat()
        {
           var stringProducer = new StringProducer(); 
           var producer = new TupleProducer<string, string>(stringProducer, stringProducer);

           producer
               .ChooseFrom()
               .ForAll(t => comcat(t.Item1, t.Item2).StartsWith(t.Item1) && comcat(t.Item1, t.Item2).EndsWith(t.Item2))
               .Should()
               .BeTrue();
        } 
    }
}
```
Please notice that each test or `assertion` of the form `x => sqr(x) == x` is executed `100` times by default. The method `ChooseFrom` is the one generating the sample data to be used on the test. By using `ForAll` and `ForAny` we can do different kind of assertions. `Should().BeTrue()` are just part of `xUnit` framework and you could be just doing simple assertions of the form:
```
 var result = Gen<int>
    .FromEnumerable(Enumerable.Range(1, 100))
    .Any(x => sqr(x) == x)
   
 assert (result == true);
```
