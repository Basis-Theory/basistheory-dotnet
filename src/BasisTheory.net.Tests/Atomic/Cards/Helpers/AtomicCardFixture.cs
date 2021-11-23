using BasisTheory.net.Atomic.Cards;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Atomic.Cards.Helpers
{
    public class AtomicCardFixture : BaseFixture
    {
        public readonly IAtomicCardClient Client;

        public AtomicCardFixture()
        {
            Client = new AtomicCardClient(ApiKey, HttpClient);
        }
    }
}
