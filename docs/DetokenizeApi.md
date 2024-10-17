# BasisTheory.net.Api.DetokenizeApi

All URIs are relative to *https://api.basistheory.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Detokenize**](DetokenizeApi.md#detokenize) | **POST** /detokenize |  |

<a name="detokenize"></a>
# **Detokenize**
> void Detokenize (Object body = null)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new DetokenizeApi(config);
var body = null;

apiInstance.Detokenize(body);
```

#### Using the DetokenizeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DetokenizeWithHttpInfo(body);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DetokenizeApi.DetokenizeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **body** | **Object** |  | [optional]  |

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
| **409** | Conflict |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

