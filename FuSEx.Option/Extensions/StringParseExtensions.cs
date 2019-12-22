using FuSEx.Option;
using System;

namespace FuSEx.Option.Extensions
{
    public static partial class StringExtensions 
    {
        public static Option<int> ParseIntOptional(this string input) => 
            int.TryParse(input, out var newValue)
            ? new Some<int>(newValue)
            : (Option<int>)None.Value;

        public static Option<float> ParseFloatOptional(this string input) => 
            float.TryParse(input, out var newValue)
            ? new Some<float>(newValue)
            : (Option<float>)None.Value;

        public static Option<decimal> ParseDecimalOptional(this string input) => 
            decimal.TryParse(input, out var newValue)
            ? new Some<decimal>(newValue)
            : (Option<decimal>)None.Value;

        public static Option<double> ParseDoubleOptional(this string input) => 
            double.TryParse(input, out var newValue)
            ? new Some<double>(newValue)
            : (Option<double>)None.Value;

        public static Option<DateTime> ParseDateTimeOptional(this string input) =>
            DateTime.TryParse(input, out var newValue)
            ? new Some<DateTime>(newValue)
            : (Option<DateTime>)None.Value;

        public static Option<bool> ParseBooleanOptional(this string input) =>
            bool.TryParse(input, out var newValue)
            ? new Some<bool>(newValue)
            : (Option<bool>)None.Value;
    }
}