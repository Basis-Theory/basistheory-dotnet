using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Roles.Entities;

public class Role
{
    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }
}