using System;

namespace FuSEx.Option
{
    public abstract class Option<T>
    {
        public static implicit operator Option<T>(T value) =>
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();

        /// <summary>
        /// Maps <c>Option{T}</c> to <c>Option{TResult}</c> using the supplied function.
        /// </summary>
        /// <param name="map">A map function to transform the <c>Option{T}</c> to an <c>Option{TResult}</c>.</param>
        /// <returns>
        /// <c>Some{TResult}</c> if the <c>Option{T}</c> was originally a <c>Some{T}</c>. <br/>
        /// <c>None{TResult}</c> if the <c>Option{T}</c> was originally a None{T}</c>.
        /// </returns>
        /// <remarks>The map function is not evaluated if this <c>Option{T}</c> is a <c>None{T}</c>.</remarks>
        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);

        /// <summary>
        /// Maps <c>Option{T}</c> to <c>Option{TResult}</c> using the supplied function.
        /// </summary>
        /// <param name="map">A map function to transform the <c>Option{T}</c> to an <c>Option{TResult}</c>.</param>
        /// <returns>
        /// <c>Some{TResult}</c> if the <c>Option{T}</c> was originally a <c>Some{T}</c>. <br/>
        /// <c>None{TResult}</c> if the <c>Option{T}</c> was originally a None{T}</c>.
        /// </returns>
        /// <remarks>The difference between this and Map is that the supplied map function returns an Option, use this to prevent nested Options.</remarks>
        /// <see cref="Map(Func{T, TResult})">
        public abstract Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map);

        /// <summary>
        /// Reduces <c>Option{T}</c> to <c>T</c> using either <c>Some{T}.Content</c> or a default value supplied as a parameter.
        /// </summary>
        /// <param name="whenNone">The default value returned if this Option is <c>None{T}</c>.</param>
        /// <returns>
        /// <c>Some{TResult}.Content</c> if this <c>Option{T}</c> was originally a <c>Some{T}</c>. <br/>
        /// The supplied value for  <c>whenNone</c> if this <c>Option{T}</c> was originally a None{T}</c>.
        /// </returns>
        public abstract T Reduce(T whenNone);

        /// <summary>
        /// Reduces <c>Option{T}</c> to <c>T</c> using either <c>Some{T}.Content</c> or evaluates the supplied function which will return the value.
        /// </summary>
        /// <param name="whenNone">The default value returned if this Option is <c>None{T}</c>.</param>
        /// <returns>
        /// <c>Some{TResult}.Content</c> if this <c>Option{T}</c> was originally a <c>Some{T}</c>. <br/>
        /// The result of the supplied function if this <c>Option{T}</c> was originally a None{T}</c>.
        /// </returns>
        /// <remarks>The passed function is not evaluated if this <c>Option{T}</c> is a <c>None{T}</c>.</remarks>
        public abstract T Reduce(Func<T> whenNone);

        /// <summary>
        /// Casts a <c>Option{T}</c> to an </c>Option{TNew}</c> 
        /// </summary>
        /// <returns>
        /// <c>Some{TNew}</c> if this Option is a <c>Some</c> and is castable to <c>Some{TNew}</c>. <br/>
        /// <c>None{TNew}</c> if this Option is a <c>None</c> or is not castable to <c>Some{TNew}</c>.
        /// </returns>
        public Option<TNew> OfType<TNew>() where TNew : class =>
            this is Some<T> some && typeof(TNew).IsAssignableFrom(typeof(T))
                ? (Option<TNew>)new Some<TNew>(some.Content as TNew)
                : None.Value;
    }
}
