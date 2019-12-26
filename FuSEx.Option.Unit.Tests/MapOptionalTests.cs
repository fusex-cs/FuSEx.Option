using Xunit;
using FluentAssertions;
using FuSEx.Option.Extensions;

namespace FuSEx.Option.Unit.Tests
{
    public class MapOptionalTests
    {
        [Fact]
        public void MapOptionalShouldTransformSomeToSome()
        {
            false.ToOption().MapOptional(o => (!o).ToOption()).Should().Be(true.ToOption());
        }

        [Fact]
        public void MapOptionalShouldTransformNoneToNone()
        {
            Option<bool> none = None.Value;
            none.MapOptional(o => (!o).ToOption()).Should().Be(None.Value);
        }
    }
}
