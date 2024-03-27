using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSVersion
  {
    [JsonProperty("recommended_version")]
    [JsonPropertyName("recommended_version")]
    public string RecommendedVersion { get; set; }

    [JsonProperty("available_version")]
    [JsonPropertyName("available_version")]
    public List<string> AvailableVersions { get; set; }

    [JsonProperty("earliest_acs_supported_version")]
    [JsonPropertyName("earliest_acs_supported_version")]
    public string EarliestAcsSupportedVersion { get; set; }

    [JsonProperty("earliest_ds_supported_version")]
    [JsonPropertyName("earliest_ds_supported_version")]
    public string EarliestDsSupportedVersion { get; set; }

    [JsonProperty("latest_acs_supported_version")]
    [JsonPropertyName("latest_acs_supported_version")]
    public string LatestAcsSupportedVersion { get; set; }

    [JsonProperty("latest_ds_supported_version")]
    [JsonPropertyName("latest_ds_supported_version")]
    public string LatestDsSupportedVersion { get; set; }

    [JsonProperty("acs_information")]
    [JsonPropertyName("acs_information")]
    public List<string> AcsInformation { get; set; }
  }
}