using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BasisTheory.net.Common.Utilities
{
    public static class JsonUtility
    {
        public static JsonSerializerSettings InitializeDefaults(this JsonSerializerSettings settings)
        {
            settings.DateParseHandling = DateParseHandling.None;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;
            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }

        public static string SerializeObject(object entity)
        {
            return JsonConvert.SerializeObject(entity, new JsonSerializerSettings().InitializeDefaults());
        }

        public static T DeserializeObject<T>(string entity)
        {
            return JsonConvert.DeserializeObject<T>(entity, new JsonSerializerSettings().InitializeDefaults());
        }
    }
}
