using Xunit;
using FluentAssertions;
using FuSEx.Option.Extensions;

namespace FuSEx.Option.Unit.Tests
{
    public class ReduceTests
    {
        [Fact]
        public void ReduceWithPredicateShouldTransformSomeToContent()
        {
            true.ToOption().Reduce(() => false).Should().Be(true);
        }

        [Fact]
        public void ReduceWithPredicateShouldTransformNoneToPredicateReturn()
        {
            ((Option<bool>)None.Value).Reduce(() => false).Should().Be(false);
        }

        [Fact]
        public void ReduceWithValueShouldTransformSomeToContent()
        {
            true.ToOption().Reduce(false).Should().Be(true);
        }

        [Fact]
        public void ReduceWithValueShouldTransformNoneToValue()
        {
            ((Option<bool>)None.Value).Reduce(false).Should().Be(false);
        }
    }
}
