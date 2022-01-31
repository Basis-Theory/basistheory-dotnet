namespace BasisTheory.net.Tokens.Requests
{
    public class TokenSearchRequest
    {
        public string Query { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }
    }
}