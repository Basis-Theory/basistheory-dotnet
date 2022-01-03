using System;

namespace BasisTheory.net.Common.Requests
{
    public abstract class GetRequest
    {
        public virtual string BuildQuery() => string.Empty;
    }
}
