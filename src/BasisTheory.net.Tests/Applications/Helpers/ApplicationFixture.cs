using BasisTheory.net.Applications;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Applications.Helpers
{
    public class ApplicationFixture : BaseFixture
    {
        public readonly IApplicationClient Client;

        public ApplicationFixture()
        {
            Client = new ApplicationClient(ApiKey, HttpClient);
        }
    }
}
