using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace FuSEx.Option.Extensions.Unit.Tests
{
    public class DictionaryExtensionsTests
    {
        protected static Dictionary<string, bool> testDictionary = new Dictionary<string, bool>
        {
            {"keyA", true},
            {"keyB", true},
            {"keyC", false}
        };

        public class TryGetValue
        {
            [Fact]
            public void ShouldReturnSomeWithContentOfValueIfFound()
            {
                testDictionary.TryGetValue("keyA").Should().Be(new Some<bool>(true));
            }

            [Fact]
            public void ShouldReturnNoneIfNotFound()
            {
                testDictionary.TryGetValue("invalidKey").Should().Be(None.Value);
            }
        }
    }
}