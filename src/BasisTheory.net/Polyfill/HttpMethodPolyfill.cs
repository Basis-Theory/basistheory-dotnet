namespace System.Net.Http;

public static class HttpMethodPolyfill
{
    /// <summary>Represents an HTTP PATCH protocol method.</summary>
    /// <returns>Returns <see cref="T:System.Net.Http.HttpMethod" />.</returns>
    public static HttpMethod Patch { get; }
#if NETSTANDARD2_0
        = new("PATCH");
#else
        = HttpMethod.Patch;
#endif
}
