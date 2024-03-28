using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSCardholderAccountInfo
{
    [JsonProperty("account_age")]
    [JsonPropertyName("account_age")]
    public string AccountAge { get; set; }

    [JsonProperty("account_last_changed")]
    [JsonPropertyName("account_last_changed")]
    public string AccountLastChanged { get; set; }

    [JsonProperty("account_change_date")]
    [JsonPropertyName("account_change_date")]
    public string AccountChangeDate { get; set; }

    [JsonProperty("account_created_date")]
    [JsonPropertyName("account_created_date")]
    public string AccountCreatedDate { get; set; }

    [JsonProperty("account_pwd_last_changed")]
    [JsonPropertyName("account_pwd_last_changed")]
    public string AccountPasswordLastChanged { get; set; }

    [JsonProperty("account_pwd_change_date")]
    [JsonPropertyName("account_pwd_change_date")]
    public string AccountPasswordChangeDate { get; set; }

    [JsonProperty("purchase_count_half_year")]
    [JsonPropertyName("purchase_count_half_year")]
    public string PurchaseCountLastYear { get; set; }

    [JsonProperty("transaction_count_day")]
    [JsonPropertyName("transaction_count_day")]
    public string TransactionCountDay { get; set; }

    [JsonProperty("payment_account_age")]
    [JsonPropertyName("payment_account_age")]
    public string PaymentAccountAge { get; set; }

    [JsonProperty("transaction_count_year")]
    [JsonPropertyName("transaction_count_year")]
    public string TransactionCountYear { get; set; }

    [JsonProperty("payment_account_created")]
    [JsonPropertyName("payment_account_created")]
    public string PaymentAccountCreated { get; set; }

    [JsonProperty("shipping_address_first_used")]
    [JsonPropertyName("shipping_address_first_used")]
    public string ShippingAddressFirstUsed { get; set; }

    [JsonProperty("shipping_address_usage_date")]
    [JsonPropertyName("shipping_address_usage_date")]
    public string ShippingAddressUsageDate { get; set; }

    [JsonProperty("shipping_account_name_match")]
    [JsonPropertyName("shipping_account_name_match")]
    public bool? ShippingAccountNameMatch { get; set; }

    [JsonProperty("suspicious_activity_observed")]
    public bool? SuspiciousActivityObserved { get; set; }
}
}