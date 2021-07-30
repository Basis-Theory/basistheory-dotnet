using BasisTheory.net.Atomic.Banks;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Atomic.Banks.Helpers
{
    public class AtomicBankFixture : BaseFixture
    {
        public readonly IAtomicBankClient Client;

        public AtomicBankFixture()
        {
            Client = new AtomicBankClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
