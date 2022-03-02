using System.Text.Json.Serialization;

namespace BasisTheory.net.AspNetCore
{
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field)]  
    public class BasisTheorySsnAttribute : JsonConverterAttribute
    {
        // todo: instead of a specific SSN attribute, maybe `[BasisTheory('ssn', Classification = X, Privacy = HIGH)]
        public BasisTheorySsnAttribute() : base(typeof(BasisTheorySsnJsonConverter))
        {
        }
    }
}