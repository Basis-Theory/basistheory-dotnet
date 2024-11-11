# BasisTheory.net.Api.EnrichmentsApi

All URIs are relative to *https://api.basistheory.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BankAccountVerify**](EnrichmentsApi.md#bankaccountverify) | **POST** /enrichments/bank-account-verify |  |

<a name="bankaccountverify"></a>
# **BankAccountVerify**
> void BankAccountVerify (BankVerificationRequest bankVerificationRequest)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new EnrichmentsApi(config);
var bankVerificationRequest = new BankVerificationRequest()
{
    TokenId = ...
    CountryCode = ...
    RoutingNumber = ...
};

apiInstance.BankAccountVerify(bankVerificationRequest);
```

#### Using the BankAccountVerifyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.BankAccountVerifyWithHttpInfo(bankVerificationRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EnrichmentsApi.BankAccountVerifyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bankVerificationRequest** | [**BankVerificationRequest**](BankVerificationRequest.md) |  |  |

### Return type

void (empty response body)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

