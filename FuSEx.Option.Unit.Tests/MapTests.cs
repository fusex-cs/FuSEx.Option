using Xunit;
using FluentAssertions;
using FuSEx.Option.Extensions;

namespace FuSEx.Option.Unit.Tests
{
    public class MapTests
    {
        [Fact]
        public void MapShouldTransformSomeToSome()
        {
            false.ToOption().Map(o => !o).Should().Be(true.ToOption());
        }

        [Fact]
        public void MapShouldTransformNoneToNone()
        {
            ((Option<bool>)None.Value).Map(o => !o).Should().Be(None.Value);
        }
    }
}
