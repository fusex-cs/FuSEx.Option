using FuSEx.Option;
using System;

namespace FuSEx.Option.Extensions
{
    public static partial class StringExtensions 
    {
        /// <summary>
        /// Parses a string to an int, wrapping the result in an <c>Option</c>.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>
        /// <c>Some{int}</c> of the resulting <c>int</c> if the string was parsed successfully.
        /// <c>None{int}</c> if the string was not parsed successfully.
        /// </returns>
        public static Option<int> ParseIntOptional(this string input) => 
            int.TryParse(input, out var newValue)
            ? new Some<int>(newValue)
            : (Option<int>)None.Value;

        /// <summary>
        /// Parses a string to a float, wrapping the result in an <c>Option</c>.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>
        /// <c>Some{float}</c> of the resulting <c>float</c> if the string was parsed successfully.
        /// <c>None{float}</c> if the string was not parsed successfully.
        /// </returns>
        public static Option<float> ParseFloatOptional(this string input) => 
            float.TryParse(input, out var newValue)
            ? new Some<float>(newValue)
            : (Option<float>)None.Value;

        /// <summary>
        /// Parses a string to a decimal, wrapping the result in an <c>Option</c>.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>
        /// <c>Some{decimal}</c> of the resulting <c>decimal</c> if the string was parsed successfully.
        /// <c>None{decimal}</c> if the string was not parsed successfully.
        /// </returns>
        public static Option<decimal> ParseDecimalOptional(this string input) => 
            decimal.TryParse(input, out var newValue)
            ? new Some<decimal>(newValue)
            : (Option<decimal>)None.Value;

        /// <summary>
        /// Parses a string to a double, wrapping the result in an <c>Option</c>.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>
        /// <c>Some{double}</c> of the resulting <c>double</c> if the string was parsed successfully.
        /// <c>None{double}</c> if the string was not parsed successfully.
        /// </returns>
        public static Option<double> ParseDoubleOptional(this string input) => 
            double.TryParse(input, out var newValue)
            ? new Some<double>(newValue)
            : (Option<double>)None.Value;

        /// <summary>
        /// Parses a string to a DateTime, wrapping the result in an <c>Option</c>.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>
        /// <c>Some{DateTime}</c> of the resulting <c>DateTime</c> if the string was parsed successfully.
        /// <c>None{DateTime}</c> if the string was not parsed successfully.
        /// </returns>
        public static Option<DateTime> ParseDateTimeOptional(this string input) =>
            DateTime.TryParse(input, out var newValue)
            ? new Some<DateTime>(newValue)
            : (Option<DateTime>)None.Value;

        /// <summary>
        /// Parses a string to a bool, wrapping the result in an <c>Option</c>.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>
        /// <c>Some{bool}</c> of the resulting <c>bool</c> if the string was parsed successfully.
        /// <c>None{bool}</c> if the string was not parsed successfully.
        /// </returns>
        public static Option<bool> ParseBooleanOptional(this string input) =>
            bool.TryParse(input, out var newValue)
            ? new Some<bool>(newValue)
            : (Option<bool>)None.Value;
    }
}