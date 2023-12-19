namespace System.Net.Mime;

public static class MediaTypeNamesPolyfill
{
    /// <summary>Specifies the kind of application data in an email message attachment.</summary>
    public static class Application
    {
        /// <summary>Specifies that the <see cref="T:System.Net.Mime.MediaTypeNames.Application" /> data is in JSON format.</summary>
        public const string Json
#if NETSTANDARD2_0
            = "application/json";
#else
            = MediaTypeNames.Application.Json;
#endif
    }
}
