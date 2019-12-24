using System;

namespace FuSEx.Option.Extensions
{
    public static class ObjectExtensions
    {
        public static Option<T> When<T>(this T obj, bool condition) =>
            condition ? (Option<T>)new Some<T>(obj) : None.Value;

        public static Option<T> When<T>(this T obj, Func<T, bool> predicate) =>
            obj.When(predicate(obj));

        public static Option<T> NoneIfNull<T>(this T obj) =>
            obj.When(!object.ReferenceEquals(obj, null));

        public static Option<T> ToOption<T>(this T obj) => NoneIfNull(obj);
    }
}
