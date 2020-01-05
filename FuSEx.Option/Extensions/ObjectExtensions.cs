using System;

namespace FuSEx.Option.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get's a <c>Some</c> or <c>None</c> depending on a boolean condition.
        /// </summary>
        /// <param name="condition">A bool to indicate whether to return Some or None.</param>
        /// <returns>
        /// <c>Some</c> of the object if condition is true.
        /// <c>None</c> if the condition is false.
        /// </returns>
        public static Option<T> When<T>(this T obj, bool condition) =>
            condition ? (Option<T>)new Some<T>(obj) : None.Value;

        /// <summary>
        /// Get's a <c>Some</c> or <c>None</c> depending on a boolean condition.
        /// </summary>
        /// <param name="predicate">A predicate to indicate whether to return Some or None.</param>
        /// <returns>
        /// <c>Some</c> of the object if the predicate is true.
        /// <c>None</c> if the predicate is false.
        /// </returns>
        public static Option<T> When<T>(this T obj, Func<T, bool> predicate) =>
            obj.When(predicate(obj));

        /// <summary>
        /// Wraps the object in an Option
        /// </summary>
        /// <returns>
        /// <c>Some</c> of the object if the object is not null.
        /// <c>None</c> if the object is null.
        /// </returns>
        public static Option<T> NoneIfNull<T>(this T obj) =>
            obj.When(!object.ReferenceEquals(obj, null));

        /// <summary>
        /// Wraps the object in an Option
        /// </summary>
        /// <returns>
        /// <c>Some</c> of the object if the object is not null.
        /// <c>None</c> if the object is null.
        /// </returns>
        public static Option<T> ToOption<T>(this T obj) => NoneIfNull(obj);
    }
}
