using System;
using System.Collections.Generic;
using System.Linq;

namespace FuSEx.Option.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Gets the first item in a sequence wrapped in an Option
        /// </summary>
        /// <returns>
        /// <c>Some</c> with the first item of the sequence if the sequence has at least one item in it.
        /// <c>None</c> if the sequence is empty.
        /// </returns>
        public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
            sequence.Select(x => (Option<T>)new Some<T>(x))
                .DefaultIfEmpty(None.Value)
                .First();

        /// <summary>
        /// Gets the first item in a sequence that matches the supplied predicate, wrapped in an Option
        /// </summary>
        /// <param name="predicate">The predicate to filter the list with.</param>
        /// <returns>
        /// <c>Some</c> with the first item of the sequence if the sequence has at least one item in it that matches the predicate.
        /// <c>None</c> if no items in the sequence match the predicate.
        /// </returns>
        public static Option<T> FirstOrNone<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate) =>
            sequence.Where(predicate).FirstOrNone();

        /// <summary>
        /// Gets the last item in a sequence wrapped in an Option
        /// </summary>
        /// <returns>
        /// <c>Some</c> with the last item of the sequence if the sequence has at least one item in it.
        /// <c>None</c> if the sequence is empty.
        /// </returns>
        public static Option<T> LastOrNone<T>(this IEnumerable<T> sequence) =>
            sequence.Select(x => (Option<T>)new Some<T>(x))
                .DefaultIfEmpty(None.Value)
                .Last();

        /// <summary>
        /// Gets the last item in a sequence that matches the supplied predicate, wrapped in an Option
        /// </summary>
        /// <param name="predicate">The predicate to filter the list with.</param>
        /// <returns>
        /// <c>Some</c> with the last item of the sequence if the sequence has at least one item in it that matches the predicate.
        /// <c>None</c> if no items in the sequence match the predicate.
        /// </returns>
        public static Option<T> LastOrNone<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate) =>
            sequence.Where(predicate).LastOrNone();

        /// <summary>
        /// Gets the contents of all <c>Some</c>'s in the sequence
        /// </summary>
        /// <returns>
        /// A sequence the Contents of all the <c>Some</c>'s in the original sequence.
        /// </returns>
        public static IEnumerable<T> SelectOptional<T>(
            this IEnumerable<Option<T>> sequence) =>
            sequence
                .OfType<Some<T>>()
                .Select(s => s.Content);

        /// <summary>
        /// Maps the sequence to a new sequence with the passed map function and returns the contents of all <c>Some</c>'s in the sequence
        /// </summary>
        /// <param name="map">The function to map over the list with.</param>
        /// <returns>
        /// A sequence the Contents of all the <c>Some</c>'s in the resulting mapped sequence.
        /// </returns>
        public static IEnumerable<TResult> SelectOptional<T, TResult>(
            this IEnumerable<T> sequence, Func<T, Option<TResult>> map) =>
            sequence.Select(map)
                .OfType<Some<TResult>>()
                .Select(some => some.Content);
    }
}
