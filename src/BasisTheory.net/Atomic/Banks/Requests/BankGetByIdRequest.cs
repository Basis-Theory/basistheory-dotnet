using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Atomic.Banks.Requests
{
    public class BankGetByIdRequest : GetRequest
    {
        public bool Decrypt { get; set; } = false;

        public override string BuildQuery()
        {
            return string.Empty;
        }
    }
}
