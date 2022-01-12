using BasisTheory.net.ReactorFormulas;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.ReactorFormulas.Helpers
{
    public class ReactorFormulaFixture : BaseFixture
    {
        public readonly IReactorFormulaClient Client;

        public ReactorFormulaFixture()
        {
            Client = new ReactorFormulaClient(ApiKey, HttpClient, appInfo: AppInfo);
        }
    }
}
