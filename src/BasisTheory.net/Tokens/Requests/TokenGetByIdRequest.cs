using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenGetByIdRequest : GetRequest
    {
        public bool Decrypt { get; set; }
        public List<string> DecryptTypes { get; set; } = new List<string>();

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (DecryptTypes.Any())
                queryParts.AddRange(DecryptTypes.Select(decryptType => $"decrypt_type={decryptType}"));

            return string.Join("&", queryParts);
        }
    }
}
