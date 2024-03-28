using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.ThreeDS.Entities;
using BasisTheory.net.ThreeDS.Requests;
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
  .RuleFor(a => a.AcsSignedContent, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.AcsChallengeUrl, (f, _) => f.Internet.Url())
  .RuleFor(a => a.ChallengeAttempts, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.ChallengeCancelReason, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.CardholderInfo, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.WhitelistStatus, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.WhitelistStatusSource, (f, _) => f.Lorem.Word())
  .RuleFor(a => a.MessageExtensions, (f, _) => new List<ThreeDSMessageExtension>
    {
      new()
        {
          Name = f.Random.Word(),
          Id = f.Random.Word(),
          Critical = f.Random.Bool(),
          Data = f.Random.Word()
        }
    });

  public static readonly Faker<ThreeDSPurchaseInfo> PurchaseInfoFaker = new Faker<ThreeDSPurchaseInfo>()
    .RuleFor(i => i.Amount, (f, _) => f.Random.Int().ToString())
    .RuleFor(i => i.Currency, (f, _) => f.Finance.Currency().Code)
    .RuleFor(i => i.Exponent, (f, _) => f.Random.Int().ToString())
    .RuleFor(i => i.Date, (f, _) => f.Date.Past().ToString("yyyyMMddhhmmss"))
    .RuleFor(i => i.TransactionType, (f, _) => f.Lorem.Word())
    .RuleFor(i => i.InstallmentCount, (f, _) => f.Random.Int().ToString())
    .RuleFor(i => i.RecurringExpiration, (f, _) => f.Date.Future().ToString("yyyyMMdd"))
    .RuleFor(i => i.RecurringFrequency, (f, _) => f.Random.Int().ToString());

  public static readonly Faker<ThreeDSRequestorInfo> RequestInfoFaker = new Faker<ThreeDSRequestorInfo>()
      .RuleFor(i => i.Id, (f, _) => f.Random.Word())
      .RuleFor(i => i.Name, (f, _) => f.Person.FullName)
      .RuleFor(i => i.Url, (f, _) => f.Internet.Url());

  public static readonly Faker<ThreeDSMerchantRiskInfo> ThreeDSMerchantRiskInfoFaker = new Faker<ThreeDSMerchantRiskInfo>()
          .RuleFor(i => i.DeliveryEmail, (f, _) => f.Person.Email)
          .RuleFor(i => i.DeliveryTimeframe, (f, _) => f.Lorem.Word())
          .RuleFor(i => i.GiftCardAmount, (f, _) => f.Random.Int().ToString())
          .RuleFor(i => i.GiftCardCount, (f, _) => f.Random.Int().ToString())
          .RuleFor(i => i.GiftCardCurrency, (f, _) => f.Finance.Currency().Code)
          .RuleFor(i => i.PreOrderPurchase, (f, _) => f.Random.Bool())
          .RuleFor(i => i.PreOrderDate, (f, _) => f.Date.Recent().ToString("yyyyMMdd"))
          .RuleFor(i => i.ReorderedPurchase, (f, _) => f.Random.Bool())
          .RuleFor(i => i.ShippingMethod, (f, _) => f.Lorem.Word());

  public static readonly Faker<ThreeDSMerchantInfo> MerchantInfoFaker = new Faker<ThreeDSMerchantInfo>()
      .RuleFor(i => i.MerchantId, (f, _) => f.Random.Word())
      .RuleFor(i => i.AcquirerBin, (f, _) => f.Random.Word())
      .RuleFor(i => i.Name, (f, _) => f.Company.CompanyName())
      .RuleFor(i => i.CountryCode, (f, _) => f.Address.CountryCode())
      .RuleFor(i => i.CategoryCode, (f, _) => f.Random.Word())
      .RuleFor(i => i.RiskInfo, (f, _) => ThreeDSMerchantRiskInfoFaker.Generate());

  public static readonly Faker<ThreeDSAddress> AddressFaker = new Faker<ThreeDSAddress>()
      .RuleFor(i => i.Line1, (f, _) => f.Address.StreetAddress())
      .RuleFor(i => i.Line2, (f, _) => f.Address.SecondaryAddress())
      .RuleFor(i => i.Line3, (f, _) => f.Address.BuildingNumber())
      .RuleFor(i => i.City, (f, _) => f.Address.City())
      .RuleFor(i => i.StateCode, (f, _) => f.Address.StateAbbr())
      .RuleFor(i => i.PostalCode, (f, _) => f.Address.ZipCode())
      .RuleFor(i => i.CountryCode, (f, _) => f.Address.CountryCode());

  public static readonly Faker<ThreeDSCardholderAuthenticationInfo> CardholderAuthenticationInfoFaker =
      new Faker<ThreeDSCardholderAuthenticationInfo>()
          .RuleFor(i => i.Method, (f, _) => f.Lorem.Word())
          .RuleFor(i => i.Timestamp, (f, _) => f.Date.Past().ToString("yyyyMMddhhmmss"))
          .RuleFor(i => i.Data, (f, _) => f.Random.Word());

  public static readonly Faker<ThreeDSPriorAuthenticationInfo> PriorAuthenticationInfoFaker =
      new Faker<ThreeDSPriorAuthenticationInfo>()
          .RuleFor(i => i.Method, (f, _) => f.Lorem.Word())
          .RuleFor(i => i.Timestamp, (f, _) => f.Date.Past().ToString("yyyyMMddhhmmss"))
          .RuleFor(i => i.ReferenceId, (f, _) => f.Random.Word())
          .RuleFor(i => i.Data, (f, _) => f.Random.Word());

  public static readonly Faker<ThreeDSCardholderAccountInfo> CardholderAccountInfoFaker = new Faker<ThreeDSCardholderAccountInfo>()
      .RuleFor(i => i.AccountAge, (f, _) => f.Lorem.Word())
      .RuleFor(i => i.AccountLastChanged, (f, _) => f.Lorem.Word())
      .RuleFor(i => i.AccountChangeDate, (f, _) => f.Date.Past().ToString("yyyyMMdd"))
      .RuleFor(i => i.AccountCreatedDate, (f, _) => f.Date.Past().ToString("yyyyMMdd"))
      .RuleFor(i => i.AccountPasswordLastChanged, (f, _) => f.Lorem.Word())
      .RuleFor(i => i.AccountPasswordChangeDate, (f, _) => f.Date.Past().ToString("yyyyMMdd"))
      .RuleFor(i => i.PurchaseCountLastYear, (f, _) => f.Random.Int().ToString())
      .RuleFor(i => i.TransactionCountDay, (f, _) => f.Random.Int().ToString())
      .RuleFor(i => i.PaymentAccountAge, (f, _) => f.Random.Int().ToString())
      .RuleFor(i => i.TransactionCountYear, (f, _) => f.Random.Int().ToString())
      .RuleFor(i => i.PaymentAccountCreated, (f, _) => f.Lorem.Word())
      .RuleFor(i => i.ShippingAddressFirstUsed, (f, _) => f.Lorem.Word())
      .RuleFor(i => i.ShippingAddressUsageDate, (f, _) => f.Date.Past().ToString("yyyyMMdd"))
      .RuleFor(i => i.ShippingAccountNameMatch, (f, _) => f.Random.Bool())
      .RuleFor(i => i.SuspiciousActivityObserved, (f, _) => f.Random.Bool());

  public static readonly Faker<ThreeDSCardholderPhoneNumber> CardholderPhoneNumberFaker = new Faker<ThreeDSCardholderPhoneNumber>()
      .RuleFor(i => i.CountryCode, (f, _) => f.Address.CountryCode())
      .RuleFor(i => i.Number, (f, _) => f.Phone.PhoneNumber());

  public static readonly Faker<ThreeDSCardholderInfo> CardholderInfoFaker = new Faker<ThreeDSCardholderInfo>()
      .RuleFor(i => i.AccountId, (f, _) => f.Random.Word())
      .RuleFor(i => i.AccountType, (f, _) => f.Lorem.Word())
      .RuleFor(i => i.Name, (f, _) => f.Person.FullName)
      .RuleFor(i => i.Email, (f, _) => f.Person.Email)
      .RuleFor(i => i.PhoneNumber, (f, _) => CardholderPhoneNumberFaker.Generate())
      .RuleFor(i => i.MobilePhoneNumber, CardholderPhoneNumberFaker.Generate())
      .RuleFor(i => i.WorkPhoneNumber, CardholderPhoneNumberFaker.Generate())
      .RuleFor(i => i.BillingShippingAddressMatch, (f, _) => f.PickRandom<string>("Y", "N"))
      .RuleFor(i => i.ShippingAddress, (f, _) => AddressFaker.Generate())
      .RuleFor(i => i.BillingAddress, (f, _) => AddressFaker.Generate())
      .RuleFor(i => i.AuthenticationInfo, (f, _) => CardholderAuthenticationInfoFaker.Generate())
      .RuleFor(i => i.PriorAuthenticationInfo, (f, _) => PriorAuthenticationInfoFaker.Generate())
      .RuleFor(i => i.AccountInfo, (f, _) => CardholderAccountInfoFaker.Generate());

  public static readonly Faker<AuthenticateThreeDSSessionRequest> AuthenticateThreeDSSessionRequestFaker =
      new Faker<AuthenticateThreeDSSessionRequest>()
          .RuleFor(r => r.AuthenticationCategory, (f, _) => f.PickRandom<string>("payment", "non-payment"))
          .RuleFor(r => r.AuthenticationType, (f, _) => f.Lorem.Word())
          .RuleFor(r => r.ChallengePreference, (f, _) => f.Lorem.Word())
          .RuleFor(r => r.BroadcastInfo, (f, _) => f.Random.Word())
          .RuleFor(r => r.PurchaseInfo, (f, _) => PurchaseInfoFaker.Generate())
          .RuleFor(r => r.RequestorInfo, (f, _) => RequestInfoFaker.Generate())
          .RuleFor(r => r.MerchantInfo, (f, _) => MerchantInfoFaker.Generate())
          .RuleFor(r => r.CardholderInfo, (f, _) => CardholderInfoFaker.Generate())
          .RuleFor(r => r.MessageExtensions, (f, _) => new List<ThreeDSMessageExtension>
          {
                new()
                {
                    Name = f.Random.Word(),
                    Id = f.Random.Word(),
                    Critical = f.Random.Bool(),
                    Data = f.Random.Word()
                }
          });

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

  public static AuthenticateThreeDSSessionRequest AuthenticateThreeDSSessionRequest(Action<AuthenticateThreeDSSessionRequest> applyOverrides = null)
  {
    var request = AuthenticateThreeDSSessionRequestFaker.Generate();

    applyOverrides?.Invoke(request);

    return request;
  }
}