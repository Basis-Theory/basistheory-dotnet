using System.Text;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Entities
{
    public class ApplicationInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public string ToUserAgentString()
        {
            var sb = new StringBuilder();
            sb.Append($"({Name}");

            if (!string.IsNullOrEmpty(Version))
                sb.Append($"; {Version}");

            if (!string.IsNullOrEmpty(Url))
                sb.Append($"; {Url}");

            sb.Append(")");
            return sb.ToString();
        }
    }
}