using Xunit;
using FluentAssertions;

namespace FuSEx.Option.Extensions.Unit.Tests
{
    public class ObjectExtensionsTests
    {
        public class When
        {
            [Fact]
            public void ShouldReturnSomeWhenPredicateMatches()
            {
                3.When(i => i == 3).Should().Be(new Some<int>(3));
            }

            [Fact]
            public void ShouldReturnNoneWhenObjectDoesNotMatchPredicate()
            {
                3.When(i => i != 3).Should().Be(None.Value);
            }

            [Fact]
            public void ShouldReturnSomeWhenBooleanValueIsTrue()
            {
                3.When(true).Should().Be(new Some<int>(3));
            }

            [Fact]
            public void ShouldReturnNoneWhenBooleanValueIsFalse()
            {
                3.When(false).Should().Be(None.Value);
            }
        }
    }
}