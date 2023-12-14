// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

public static class DictionaryExtensions
{
    public static void Add<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary,
        KeyValuePair<TKey, TValue> keyValuePair
    )
        => ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Add(keyValuePair);
}
