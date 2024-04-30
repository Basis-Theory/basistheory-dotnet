using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
    public class ThreeDSAcsRenderingType
    {
        [JsonProperty("acs_interface")]
        [JsonPropertyName("acs_interface")]
        public string AcsInterface { get; set; }

        [JsonProperty("acs_ui_template")]
        [JsonPropertyName("acs_ui_template")]
        public string AcsUiTemplate { get; set; }
    }
}