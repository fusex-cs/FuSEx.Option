using System.Collections.Generic;

namespace FuSEx.Option.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Search for the value in a dictionary by key, returning the value wrapped in an Option
        /// </summary>
        /// <param name="key">The key to search the dictionary for.</param>
        /// <returns>
        /// <c>Some</c> with the value if the value exists. 
        /// <c>None</c> if the value does not exist.
        /// </returns>
        public static Option<TValue> TryGetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key) =>
            dictionary.TryGetValue(key, out TValue value) 
                ? (Option<TValue>)new Some<TValue>(value)
                : None.Value;
    }
}
