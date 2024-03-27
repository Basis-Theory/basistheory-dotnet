using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSMessageExtension
  {
    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonProperty("critical")]
    [JsonPropertyName("critical")]
    public string Critical { get; set; }

    [JsonProperty("data")]
    [JsonPropertyName("data")]
    public string Data { get; set; }
  }
}