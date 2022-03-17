using Newtonsoft.Json;

namespace BasisTheory.net.Reactors.Requests
{
    public class ReactRequest
    {
        [JsonProperty("args")]
        public dynamic Arguments { get; set; }
    }
}