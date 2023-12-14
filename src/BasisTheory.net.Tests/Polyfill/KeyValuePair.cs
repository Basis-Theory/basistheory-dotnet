#if NETFRAMEWORK || NETSTANDARD2_0
// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

internal static class KeyValuePair
{
    public static KeyValuePair<TKey, TValue> Create<TKey, TValue>(
        TKey key,
        TValue value
    )
        where TKey : notnull
        => new(key, value);

    public static void Deconstruct<T1, T2>(
        this KeyValuePair<T1, T2> keyValuePair,
        out T1 key,
        out T2 value
    )
    {
        key = keyValuePair.Key;
        value = keyValuePair.Value;
    }
}

#endif
