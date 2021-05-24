using System;

namespace BasisTheory.net.Common.Requests
{
    public class RequestOptions
    {
        public string ApiKey { get; set; }

        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
    }
}
