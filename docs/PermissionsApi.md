# BasisTheory.net.Api.PermissionsApi

All URIs are relative to *https://api.basistheory.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Get**](PermissionsApi.md#get) | **GET** /permissions |  |

<a name="get"></a>
# **Get**
> List&lt;Permission&gt; Get (string applicationType = null)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new PermissionsApi(config);
var applicationType = "applicationType_example";

try
{
    List<Permission> result = apiInstance.Get(applicationType);
    Console.WriteLine(result);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling PermissionsApi.Get: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the GetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Permission>> response = apiInstance.GetWithHttpInfo(applicationType);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PermissionsApi.GetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **applicationType** | **string** |  | [optional]  |

### Return type

[**List&lt;Permission&gt;**](Permission.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

