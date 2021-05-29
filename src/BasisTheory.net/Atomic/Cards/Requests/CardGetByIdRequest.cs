using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Atomic.Cards.Requests
{
    public class CardGetByIdRequest : GetRequest
    {
        public bool DecryptCard { get; set; } = false;

        public override string BuildQuery()
        {
            return string.Empty;
        }
    }
}
