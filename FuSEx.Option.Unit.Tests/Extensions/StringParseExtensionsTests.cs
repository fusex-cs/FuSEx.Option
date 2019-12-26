using Xunit;
using FluentAssertions;
using System;

namespace FuSEx.Option.Extensions.Unit.Tests
{
    public class StringParseExtensionsTests
    {
        public class ParseIntOptional
        {
            [Fact]
            public void ShouldReturnSomeWhenValidStringParsedAsInt()
            {
                "12341".ParseIntOptional().Should().Be(new Some<int>(12341));
            }

            [Fact]
            public void ShouldReturnNoneWhenInvalidStringParsedAsInt()
            {
                "213@21".ParseIntOptional().Should().Be(None.Value);
            }
        }

        public class ParseFloatOptional
        {
            [Fact]
            public void ShouldReturnSomeWhenValidStringParsedAsFloat()
            {
                "1234.231".ParseFloatOptional().Should().Be(new Some<float>(1234.231f));
            }

            [Fact]
            public void ShouldReturnNoneWhenInvalidStringParsedAsFloat()
            {
                "213@21".ParseFloatOptional().Should().Be(None.Value);
            }
        }

        public class ParseDecimalOptional
        {
            [Fact]
            public void ShouldReturnSomeWhenValidStringParsedAsDecimal()
            {
                "12341.21".ParseDecimalOptional().Should().Be(new Some<decimal>(12341.21m));
            }

            [Fact]
            public void ShouldReturnNoneWhenInvalidStringParsedAsDecimal()
            {
                "213@21".ParseDecimalOptional().Should().Be(None.Value);
            }
        }

        public class ParseDoubleOptional
        {
            [Fact]
            public void ShouldReturnSomeWhenValidStringParsedAsDouble()
            {
                "12341.21".ParseDoubleOptional().Should().Be(new Some<double>(12341.21));
            }

            [Fact]
            public void ShouldReturnNoneWhenInvalidStringParsedAsDouble()
            {
                "213@21".ParseDoubleOptional().Should().Be(None.Value);
            }
        }

        public class ParseDateTimeOptional
        {
            [Fact]
            public void ShouldReturnSomeWhenValidStringParsedAsDateTime()
            {
                "1995-07-22".ParseDateTimeOptional()
                    .Should().Be(DateTime.Parse("1995-07-22").ToOption());
            }

            [Fact]
            public void ShouldReturnNoneWhenInvalidStringParsedAsDateTime()
            {
                "213@21".ParseDateTimeOptional().Should().Be(None.Value);
            }
        }

        public class ParseBooleanOptional
        {
            [Fact]
            public void ShouldReturnSomeWhenValidStringParsedAsFloat()
            {
                "false".ParseBooleanOptional().Should().Be(new Some<bool>(false));
            }

            [Fact]
            public void ShouldReturnNoneWhenInvalidStringParsedAsInt()
            {
                "213@21".ParseBooleanOptional().Should().Be(None.Value);
            }
        }
    }
}