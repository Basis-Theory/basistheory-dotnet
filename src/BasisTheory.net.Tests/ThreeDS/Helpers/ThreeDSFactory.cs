using System;
using System.Linq;
using BasisTheory.net.ThreeDS.Entities;
using Bogus;

namespace BasisTheory.net.Tests.ThreeDS.Helpers;

public static class ThreeDSFactory
{
  public static readonly Faker<ThreeDSSession> ThreeDSSessionFaker = new Faker<ThreeDSSession>()
    .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
    .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
    .RuleFor(a => a.PanTokenId, (_, _) => Guid.NewGuid().ToString())
    .RuleFor(a => a.CardBrand, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.ExpirationDate, (f, _) => f.Date.FutureOffset())
    .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
    .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
    .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
    .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
    .RuleFor(a => a.Device, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.DeviceInfo, (f, _) => ThreeDSDeviceInfoFaker.Generate())
    .RuleFor(a => a.Version, (f, _) => ThreeDSVersionFaker.Generate())
    .RuleFor(a => a.Method, (f, _) => ThreeDSMethodFaker.Generate());


  public static readonly Faker<ThreeDSDeviceInfo> ThreeDSDeviceInfoFaker = new Faker<ThreeDSDeviceInfo>()
    .RuleFor(a => a.BrowserAcceptHeader, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.BrowserIpAddress, (f, _) => f.Internet.Ip())
    .RuleFor(a => a.BrowserJavaEnabled, (f, _) => f.Random.Bool())
    .RuleFor(a => a.BrowserLanguage, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.BrowserColorDepth, (f, _) => f.Random.Int().ToString())
    .RuleFor(a => a.BrowserScreenHeight, (f, _) => f.Random.Int().ToString())
    .RuleFor(a => a.BrowserScreenWidth, (f, _) => f.Random.Int().ToString())
    .RuleFor(a => a.BrowserTimezone, (f, _) => f.Random.Int().ToString())
    .RuleFor(a => a.BrowserUserAgent, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.MobileSdkTransactionId, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.MobileSdkApplicationId, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.MobileSdkEncryptionData, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.MobileSdkMaxTimeout, (f, _) => f.Random.Int().ToString())
    .RuleFor(a => a.MobileSdkReferenceNumber, (f, _) => f.Lorem.Word());

  public static readonly Faker<ThreeDSVersion> ThreeDSVersionFaker = new Faker<ThreeDSVersion>()
    .RuleFor(a => a.RecommendedVersion, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.AvailableVersions, (f, _) => f.Make(5, () => f.Lorem.Word()).ToList())
    .RuleFor(a => a.EarliestAcsSupportedVersion, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.EarliestDsSupportedVersion, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.LatestAcsSupportedVersion, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.LatestDsSupportedVersion, (f, _) => f.Lorem.Word())
    .RuleFor(a => a.AcsInformation, (f, _) => f.Make(5, () => f.Lorem.Word()).ToList());

  public static readonly Faker<ThreeDSMethod> ThreeDSMethodFaker = new Faker<ThreeDSMethod>()
  .RuleFor(a => a.MethodUrl, (f, _) => f.Internet.Url())
  .RuleFor(a => a.MethodCompletionIndicator, (f, _) => f.Lorem.Word());

  public static readonly Faker<ThreeDSAuthentication> ThreeDSAuthenticationFaker = new Faker<ThreeDSAuthentication>()
  .RuleFor(a => a.ThreeDSVersion, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AcsTransactionId, (f, _) => f.Random.Guid())
  .RuleFor(a => a.DirectoryServerTransactionId, (f, _) => f.Random.Guid())
  .RuleFor(a => a.SdkTransactionId, (f, _) => f.Random.Guid())
  .RuleFor(a => a.AcsReferenceNumber, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.DirectoryServerReferenceNumber, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AuthenticationValue, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AuthenticationStatus, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AuthenticationStatusReason, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.Eci, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AcsChallengeMandated, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AcsDecoupledAuthentication, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AuthenticationChallengeType, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AcsRenderingType, (f, _) => f.PickRandom<ThreeDSAcsRenderingType>())
  .RuleFor(a => a.AcsSignedContent, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AcsChallengeUrl, (f, _) => f.Internet.Url())
  .RuleFor(a => a.ChallengeAttempts, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.ChallengeCancelReason, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.CardholderInfo, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.WhitelistStatus, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.WhitelistStatusSource, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.MessageExtensions, (f, _) => f.Make(5, () => new ThreeDSMessageExtension()).ToList());

  public static ThreeDSSession ThreeDSSession(Action<ThreeDSSession> applyOverrides = null)
  {
    var session = ThreeDSSessionFaker.Generate();

    applyOverrides?.Invoke(session);

    return session;
  }

  public static ThreeDSAuthentication ThreeDSAuthentication(Action<ThreeDSAuthentication> applyOverrides = null)
  {
    var authentication = ThreeDSAuthenticationFaker.Generate();

    applyOverrides?.Invoke(authentication);

    return authentication;
  }
}