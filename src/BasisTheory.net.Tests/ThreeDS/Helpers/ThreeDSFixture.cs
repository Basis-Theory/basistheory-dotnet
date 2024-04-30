using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.ThreeDS;

namespace BasisTheory.net.Tests.ThreeDS.Helpers;

public class ThreeDSFixture : BaseFixture
{
    public readonly IThreeDSClient Client;

    public ThreeDSFixture()
    {
        Client = new ThreeDSClient(ApiKey, HttpClient, appInfo: AppInfo);
    }
}
