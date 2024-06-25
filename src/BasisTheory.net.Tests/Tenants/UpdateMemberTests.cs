using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tenants.Requests;
using BasisTheory.net.Tests.Tenants.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Tenants;

public class UpdateMemberTests: IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public UpdateMemberTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    async (client, memberId, request, options) => await client.UpdateMemberAsync(memberId, request, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    async (client, memberId, request, options) => await client.UpdateMemberAsync(memberId.ToString(), request, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    (client, memberId, request, options) => Task.FromResult(client.UpdateMember(memberId, request, options))
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    (client, memberId, request, options) => Task.FromResult(client.UpdateMember(memberId.ToString(), request, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldUpdate(Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>> mut)
    {
        var content = TenantMemberFactory.TenantMemberFaker.Generate();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var updateRequest = new TenantMemberUpdateRequest
        {
            Role = content.Role
        };
        
        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, updateRequest, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Put, requestMessage.Method);
        Assert.Equal("/tenants/self/members/" + content.Id, requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }
}