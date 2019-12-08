using FuSEx.Option;

namespace FuSEx.Option.Extensions
{
    public static class StringExtensions 
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
    }
}