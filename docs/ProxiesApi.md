# BasisTheory.net.Api.ProxiesApi

All URIs are relative to *https://api.basistheory.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Create**](ProxiesApi.md#create) | **POST** /proxies | 
[**Delete**](ProxiesApi.md#delete) | **DELETE** /proxies/{id} | 
[**Get**](ProxiesApi.md#get) | **GET** /proxies | 
[**GetById**](ProxiesApi.md#getbyid) | **GET** /proxies/{id} | 
[**Patch**](ProxiesApi.md#patch) | **PATCH** /proxies/{id} | 
[**Update**](ProxiesApi.md#update) | **PUT** /proxies/{id} | 



## Create

> Proxy Create (CreateProxyRequest createProxyRequest)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class CreateExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ProxiesApi(Configuration.Default);
            var createProxyRequest = new CreateProxyRequest(); // CreateProxyRequest | 

            try
            {
                Proxy result = apiInstance.Create(createProxyRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProxiesApi.Create: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **createProxyRequest** | [**CreateProxyRequest**](CreateProxyRequest.md)|  | 

### Return type

[**Proxy**](Proxy.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Delete

> void Delete (Guid id)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class DeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ProxiesApi(Configuration.Default);
            var id = "id_example";  // Guid | 

            try
            {
                apiInstance.Delete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProxiesApi.Delete: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **Guid**|  | 

### Return type

void (empty response body)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **404** | Not Found |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Get

> ProxyPaginatedList Get (List<Guid> id = null, string name = null, int? page = null, string start = null, int? size = null)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class GetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ProxiesApi(Configuration.Default);
            var id = new List<Guid>(); // List<Guid> |  (optional) 
            var name = "name_example";  // string |  (optional) 
            var page = 56;  // int? |  (optional) 
            var start = "start_example";  // string |  (optional) 
            var size = 56;  // int? |  (optional) 

            try
            {
                ProxyPaginatedList result = apiInstance.Get(id, name, page, start, size);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProxiesApi.Get: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**List&lt;Guid&gt;**](Guid.md)|  | [optional] 
 **name** | **string**|  | [optional] 
 **page** | **int?**|  | [optional] 
 **start** | **string**|  | [optional] 
 **size** | **int?**|  | [optional] 

### Return type

[**ProxyPaginatedList**](ProxyPaginatedList.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetById

> Proxy GetById (Guid id)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class GetByIdExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ProxiesApi(Configuration.Default);
            var id = "id_example";  // Guid | 

            try
            {
                Proxy result = apiInstance.GetById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProxiesApi.GetById: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **Guid**|  | 

### Return type

[**Proxy**](Proxy.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Patch

> void Patch (Guid id, PatchProxyRequest patchProxyRequest)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class PatchExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ProxiesApi(Configuration.Default);
            var id = "id_example";  // Guid | 
            var patchProxyRequest = new PatchProxyRequest(); // PatchProxyRequest | 

            try
            {
                apiInstance.Patch(id, patchProxyRequest);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProxiesApi.Patch: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **Guid**|  | 
 **patchProxyRequest** | [**PatchProxyRequest**](PatchProxyRequest.md)|  | 

### Return type

void (empty response body)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: application/merge-patch+json
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Update

> Proxy Update (Guid id, UpdateProxyRequest updateProxyRequest)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class UpdateExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ProxiesApi(Configuration.Default);
            var id = "id_example";  // Guid | 
            var updateProxyRequest = new UpdateProxyRequest(); // UpdateProxyRequest | 

            try
            {
                Proxy result = apiInstance.Update(id, updateProxyRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProxiesApi.Update: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **Guid**|  | 
 **updateProxyRequest** | [**UpdateProxyRequest**](UpdateProxyRequest.md)|  | 

### Return type

[**Proxy**](Proxy.md)

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
| **404** | Not Found |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)
