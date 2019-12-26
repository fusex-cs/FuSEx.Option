using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace FuSEx.Option.Extensions.Unit.Tests
{
    public class EnumerableExtensionsTests
    {
        protected static List<string> testEnumerable = new List<string>
        {
            "itemA",
            "itemB",
            "itemC"
        };

        protected static List<Option<string>> testOptionsEnumerable = new List<Option<string>>
        {
            new Some<string>("item1"),
            None.Value,
            new Some<string>("item3")
        };

        public class FirstOrNone
        {
            [Fact]
            public void ShouldReturnSomeWithContentOfFirstValue()
            {
                testEnumerable.FirstOrNone().Should().Be(new Some<string>("itemA"));
            }

            [Fact]
            public void ShouldReturnSomeWithContentOfFirstValueMatchingPredicate()
            {
                testEnumerable.FirstOrNone(i => i.Contains('B')).Should().Be(new Some<string>("itemB"));
            }

            [Fact]
            public void ShouldReturnNoneWhenNoItemInList()
            {
                var emptyList = new List<string>();
                emptyList.FirstOrNone().Should().Be(None.Value);
            }

            [Fact]
            public void ShouldReturnNoneWhenNoItemInListMatchesPredicate()
            {
                testEnumerable.FirstOrNone(i => i == "itemNotInList").Should().Be(None.Value);
            }
        }

        public class LastOrNone
        {
            [Fact]
            public void ShouldReturnSomeWithContentOfLastValue()
            {
                testEnumerable.LastOrNone().Should().Be(new Some<string>("itemC"));
            }

            [Fact]
            public void ShouldReturnSomeWithContentOfLastValueMatchingPredicate()
            {
                testEnumerable.LastOrNone(i => i.Contains('B')).Should().Be(new Some<string>("itemB"));
            }

            [Fact]
            public void ShouldReturnNoneWhenNoItemInList()
            {
                var emptyList = new List<string>();
                emptyList.LastOrNone().Should().Be(None.Value);
            }

            [Fact]
            public void ShouldReturnNoneWhenNoItemInListMatchesPredicate()
            {
                testEnumerable.LastOrNone(i => i == "itemNotInList").Should().Be(None.Value);
            }
        }

        public class SelectOptional
        {
            [Fact]
            public void ShouldReturnTheContentOfAllSomesInTheList()
            {
                var selectedItems = testOptionsEnumerable.SelectOptional().ToList();

                selectedItems.Count.Should().Be(2);
                selectedItems.Should().Contain("item1", "item3");
            }

            [Fact]
            public void ShouldReturnTheTransformedContentOfAllSomesInTheList()
            {
                var selectedItems = testEnumerable
                    .SelectOptional(i => i == "itemB" ? i.ToOption() : None.Value)
                    .ToList();

                selectedItems.Count.Should().Be(1);
                selectedItems.Should().Contain("itemB");
            }
        }
    }
}