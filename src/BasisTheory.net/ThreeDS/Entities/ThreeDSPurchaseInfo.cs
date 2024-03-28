using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSPurchaseInfo
  {
    [JsonProperty("amount")]
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonProperty("currency")]
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonProperty("exponent")]
    [JsonPropertyName("exponent")]
    public string Exponent { get; set; }

    [JsonProperty("date")]
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonProperty("transaction_type")]
    [JsonPropertyName("transaction_type")]
    public string TransactionType { get; set; }

    [JsonProperty("installment_count")]
    [JsonPropertyName("installment_count")]
    public string InstallmentCount { get; set; }

    [JsonProperty("recurring_expiration")]
    [JsonPropertyName("recurring_expiration")]
    public string RecurringExpiration { get; set; }

    [JsonProperty("recurring_frequency")]
    [JsonPropertyName("recurring_frequency")]
    public string RecurringFrequency { get; set; }
  }
}