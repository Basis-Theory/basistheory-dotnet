using Xunit;
using BasisTheory.net.Tests.ThreeDS.Helpers;
using System.Collections.Generic;
using System;
using BasisTheory.net.ThreeDS;
using BasisTheory.net.Common.Requests;
using System.Threading.Tasks;
using BasisTheory.net.ThreeDS.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Common.Errors;
using System.Net;

namespace BasisTheory.net.Tests.ThreeDS
{
  public class GetSessionByIdTests : IClassFixture<ThreeDSFixture>
  {
    private readonly ThreeDSFixture _fixture;

    public GetSessionByIdTests(ThreeDSFixture fixture)
    {
      _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
      get
      {
        yield return new object[]
        {
          (Func<IThreeDSClient, string, RequestOptions, Task<ThreeDSSession>>) (
            async (client, sessionId, options) => await client.GetSessionByIdAsync(sessionId, options)
          )
        };
        yield return new object[]
        {
          (Func<IThreeDSClient, string, RequestOptions, Task<ThreeDSSession>>) (
            (client, sessionId, options) => Task.FromResult(client.GetSessionById(sessionId, options))
          )
        };
      }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetSessionById(Func<IThreeDSClient, string, RequestOptions, Task<ThreeDSSession>> mut)
    {
      var sessionId = Guid.NewGuid();
      var content = ThreeDSFactory.ThreeDSSession(a => a.Id = sessionId);
      var expectedSerialized = JsonConvert.SerializeObject(content);

      HttpRequestMessage requestMessage = null;
      _fixture.SetupHandler(System.Net.HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

      var response = await mut(_fixture.Client, sessionId.ToString(), null);

      Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
      Assert.Equal(HttpMethod.Get, requestMessage.Method);
      Assert.Equal($"/3ds/sessions/{sessionId}", requestMessage.RequestUri?.PathAndQuery);
      Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
      _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
    Func<IThreeDSClient, string, RequestOptions, Task<ThreeDSSession>> mut)
    {
      var error = BasisTheoryErrorFactory.BasisTheoryError();
      var expectedSerializedError = JsonConvert.SerializeObject(error);

      _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

      var exception =
          await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid().ToString(), null));
      var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

      Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<IThreeDSClient, string, RequestOptions, Task<ThreeDSSession>> mut)
    {
      _fixture.SetupHandler(HttpStatusCode.Forbidden);

      var exception =
          await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid().ToString(), null));

      Assert.Equal(403, exception.Error.Status);
      Assert.Null(exception.Error.Title);
      Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<IThreeDSClient, string, RequestOptions, Task<ThreeDSSession>> mut)
    {
      var error = Guid.NewGuid().ToString();

      _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

      var exception =
          await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid().ToString(), null));

      Assert.Equal(500, exception.Error.Status);
      Assert.Null(exception.Error.Title);
      Assert.Null(exception.Error.Detail);
    }
  }
}