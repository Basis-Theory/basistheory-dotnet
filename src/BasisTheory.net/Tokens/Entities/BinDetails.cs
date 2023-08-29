using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class BinDetails
    {
        [JsonProperty("card_brand")] 
        [JsonPropertyName("card_brand")] 
        public string? CardBrand { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonProperty("prepaid")]
        [JsonPropertyName("prepaid")]
        public bool? Prepaid { get; set; }

        [JsonProperty("card_segment_type")]
        [JsonPropertyName("card_segment_type")]
        public string? CardSegmentType { get; set; }

        [JsonProperty("bank")]
        [JsonPropertyName("bank")]
        public BinDetailsBank? Bank { get; set; }

        [JsonProperty("product")]
        [JsonPropertyName("product")]
        public BinDetailsProduct? Product { get; set; }

        [JsonProperty("country")]
        [JsonPropertyName("country")]
        public BinDetailsCountry? Country { get; set; }

        public class BinDetailsBank
        {
            [JsonProperty("name")]
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonProperty("phone")]
            [JsonPropertyName("phone")]
            public string? Phone { get; set; }

            [JsonProperty("url")]
            [JsonPropertyName("url")]
            public string? Url { get; set; }

            [JsonProperty("clean_name")]
            [JsonPropertyName("clean_name")]
            public string? CleanName { get; set; }
        }

        public class BinDetailsProduct
        {
            [JsonProperty("code")]
            [JsonPropertyName("code")]
            public string? Code { get; set; }

            [JsonProperty("name")]
            [JsonPropertyName("name")]
            public string? Name { get; set; }
        }

        public class BinDetailsCountry
        {
            [JsonProperty("alpha2")]
            [JsonPropertyName("alpha2")]
            public string? Alpha2 { get; set; }

            [JsonProperty("name")]
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonProperty("numeric")]
            [JsonPropertyName("numeric")]
            public string? Numeric { get; set; }
        }

        #region Enhanced Properties

        [JsonProperty("reloadable")]
        [JsonPropertyName("reloadable")]
        public bool? Reloadable { get; set; }

        [JsonProperty("pan_or_token")]
        [JsonPropertyName("pan_or_token")]
        public string? PanOrToken { get; set; }

        [JsonProperty("account_updater")]
        [JsonPropertyName("account_updater")]
        public bool? AccountUpdater { get; set; }

        [JsonProperty("alm")]
        [JsonPropertyName("alm")]
        public bool? AccountLevelManagement { get; set; }

        [JsonProperty("domestic_only")]
        [JsonPropertyName("domestic_only")]
        public bool? DomesticOnly { get; set; }

        [JsonProperty("gambling_blocked")]
        [JsonPropertyName("gambling_blocked")]
        public bool? GamblingBlocked { get; set; }

        [JsonProperty("level2")]
        [JsonPropertyName("level2")]
        public bool? Level2 { get; set; }

        [JsonProperty("level3")]
        [JsonPropertyName("level3")]
        public bool? Level3 { get; set; }

        [JsonProperty("issuer_currency")]
        [JsonPropertyName("issuer_currency")]
        public string? IssuerCurrency { get; set; }

        [JsonProperty("combo_card")]
        [JsonPropertyName("combo_card")]
        public string? ComboCard { get; set; }

        [JsonProperty("bin_length")]
        [JsonPropertyName("bin_length")]
        public int? BinLength { get; set; }

        [JsonProperty("authentication")]
        [JsonPropertyName("authentication")]
        public dynamic? Authentication { get; set; }

        [JsonProperty("cost")]
        [JsonPropertyName("cost")]
        public dynamic? Cost { get; set; }

        #endregion
    }
}