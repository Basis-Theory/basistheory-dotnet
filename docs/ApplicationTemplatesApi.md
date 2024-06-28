# BasisTheory.net.Api.ApplicationTemplatesApi

All URIs are relative to *https://api.basistheory.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Get**](ApplicationTemplatesApi.md#get) | **GET** /application-templates |  |
| [**GetById**](ApplicationTemplatesApi.md#getbyid) | **GET** /application-templates/{id} |  |

<a name="get"></a>
# **Get**
> List&lt;ApplicationTemplate&gt; Get ()



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new ApplicationTemplatesApi(config);

try
{
    List<ApplicationTemplate> result = apiInstance.Get();
    Console.WriteLine(result);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling ApplicationTemplatesApi.Get: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the GetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<ApplicationTemplate>> response = apiInstance.GetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ApplicationTemplatesApi.GetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;ApplicationTemplate&gt;**](ApplicationTemplate.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **401** | Unauthorized |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbyid"></a>
# **GetById**
> ApplicationTemplate GetById (Guid id)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new ApplicationTemplatesApi(config);
var id = "id_example";

try
{
    ApplicationTemplate result = apiInstance.GetById(id);
    Console.WriteLine(result);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling ApplicationTemplatesApi.GetById: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the GetByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ApplicationTemplate> response = apiInstance.GetByIdWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ApplicationTemplatesApi.GetByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**ApplicationTemplate**](ApplicationTemplate.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **401** | Unauthorized |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

