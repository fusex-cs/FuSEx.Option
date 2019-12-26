using Xunit;
using FluentAssertions;
using FuSEx.Option.Extensions;

namespace FuSEx.Option.Unit.Tests
{
    public class ToStringTests
    {
        [Fact]
        public void ToStringOnSomeShouldReturnSomeBRContentBR()
        {
            true.ToOption().ToString().Should().Be("Some(True)");
        }

        [Fact]
        public void ToStringOnSomeShouldReturnSomeBRABRnullABRBR()
        {
            var nullSome = new Some<bool?>(null);
            nullSome.ToString().Should().Be("Some(<null>)");
        }

        [Fact]
        public void ToStringOnNoneShouldReturnNone()
        {
            ((Option<bool>)None.Value).ToString().Should().Be("None");
        }
    }
}
