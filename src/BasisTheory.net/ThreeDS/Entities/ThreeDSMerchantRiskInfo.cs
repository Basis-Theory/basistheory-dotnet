using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
    public class ThreeDSMerchantRiskInfo
    {
        [JsonProperty("delivery_email")]
        [JsonPropertyName("delivery_email")]
        public string DeliveryEmail { get; set; }

        [JsonProperty("delivery_time_frame")]
        [JsonPropertyName("delivery_time_frame")]
        public string DeliveryTimeframe { get; set; }

        [JsonProperty("gift_card_amount")]
        [JsonPropertyName("gift_card_amount")]
        public string GiftCardAmount { get; set; }

        [JsonProperty("gift_card_count")]
        [JsonPropertyName("gift_card_count")]
        public string GiftCardCount { get; set; }

        [JsonProperty("gift_card_currency")]
        [JsonPropertyName("gift_card_currency")]
        public string GiftCardCurrency { get; set; }

        [JsonProperty("pre_order_purchase")]
        [JsonPropertyName("pre_order_purchase")]
        public bool? PreOrderPurchase { get; set; }

        [JsonProperty("pre_order_date")]
        [JsonPropertyName("pre_order_date")]
        public string PreOrderDate { get; set; }

        [JsonProperty("reordered_purchase")]
        [JsonPropertyName("reordered_purchase")]
        public bool? ReorderedPurchase { get; set; }

        [JsonProperty("shipping_method")]
        [JsonPropertyName("shipping_method")]
        public string ShippingMethod { get; set; }
    }
}
