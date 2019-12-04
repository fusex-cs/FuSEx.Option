using System;
using System.Collections.Generic;
using System.Linq;

namespace WT.Option.Extensions
{
    public static class EnumerableExtensions
    {
        public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
            sequence.Select(x => (Option<T>)new Some<T>(x))
                .DefaultIfEmpty(None.Value)
                .First();

        public static Option<T> FirstOrNone<T>(
            this IEnumerable<T> sequence, Func<T, bool> predicate) =>
            sequence.Where(predicate).FirstOrNone();

        public static IEnumerable<T> SelectOptional<T>(
            this IEnumerable<Option<T>> sequence) =>
            sequence
                .OfType<Some<T>>()
                .Select(s => s.Content);

        public static IEnumerable<TResult> SelectOptional<T, TResult>(
            this IEnumerable<T> sequence, Func<T, Option<TResult>> map) =>
            sequence.Select(map)
                .OfType<Some<TResult>>()
                .Select(some => some.Content);
    }
}
