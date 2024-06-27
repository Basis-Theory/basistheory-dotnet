# BasisTheory.net.Api.ReactorsApi

All URIs are relative to *https://api.basistheory.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Create**](ReactorsApi.md#create) | **POST** /reactors | 
[**Delete**](ReactorsApi.md#delete) | **DELETE** /reactors/{id} | 
[**Get**](ReactorsApi.md#get) | **GET** /reactors | 
[**GetById**](ReactorsApi.md#getbyid) | **GET** /reactors/{id} | 
[**Patch**](ReactorsApi.md#patch) | **PATCH** /reactors/{id} | 
[**React**](ReactorsApi.md#react) | **POST** /reactors/{id}/react | 
[**Update**](ReactorsApi.md#update) | **PUT** /reactors/{id} | 



## Create

> Reactor Create (CreateReactorRequest createReactorRequest)



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

            var apiInstance = new ReactorsApi(Configuration.Default);
            var createReactorRequest = new CreateReactorRequest(); // CreateReactorRequest | 

            try
            {
                Reactor result = apiInstance.Create(createReactorRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ReactorsApi.Create: " + e.Message );
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
 **createReactorRequest** | [**CreateReactorRequest**](CreateReactorRequest.md)|  | 

### Return type

[**Reactor**](Reactor.md)

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

            var apiInstance = new ReactorsApi(Configuration.Default);
            var id = "id_example";  // Guid | 

            try
            {
                apiInstance.Delete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ReactorsApi.Delete: " + e.Message );
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

> ReactorPaginatedList Get (List<Guid> id = null, string name = null, int? page = null, string start = null, int? size = null)



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

            var apiInstance = new ReactorsApi(Configuration.Default);
            var id = new List<Guid>(); // List<Guid> |  (optional) 
            var name = "name_example";  // string |  (optional) 
            var page = 56;  // int? |  (optional) 
            var start = "start_example";  // string |  (optional) 
            var size = 56;  // int? |  (optional) 

            try
            {
                ReactorPaginatedList result = apiInstance.Get(id, name, page, start, size);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ReactorsApi.Get: " + e.Message );
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

[**ReactorPaginatedList**](ReactorPaginatedList.md)

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

> Reactor GetById (Guid id)



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

            var apiInstance = new ReactorsApi(Configuration.Default);
            var id = "id_example";  // Guid | 

            try
            {
                Reactor result = apiInstance.GetById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ReactorsApi.GetById: " + e.Message );
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

[**Reactor**](Reactor.md)

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

> void Patch (Guid id, PatchReactorRequest patchReactorRequest)



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

            var apiInstance = new ReactorsApi(Configuration.Default);
            var id = "id_example";  // Guid | 
            var patchReactorRequest = new PatchReactorRequest(); // PatchReactorRequest | 

            try
            {
                apiInstance.Patch(id, patchReactorRequest);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ReactorsApi.Patch: " + e.Message );
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
 **patchReactorRequest** | [**PatchReactorRequest**](PatchReactorRequest.md)|  | 

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


## React

> ReactResponse React (Guid id, ReactRequest reactRequest)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class ReactExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ReactorsApi(Configuration.Default);
            var id = "id_example";  // Guid | 
            var reactRequest = new ReactRequest(); // ReactRequest | 

            try
            {
                ReactResponse result = apiInstance.React(id, reactRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ReactorsApi.React: " + e.Message );
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
 **reactRequest** | [**ReactRequest**](ReactRequest.md)|  | 

### Return type

[**ReactResponse**](ReactResponse.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **202** | Accepted |  -  |
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |
| **422** | Client Error |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Update

> Reactor Update (Guid id, UpdateReactorRequest updateReactorRequest)



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

            var apiInstance = new ReactorsApi(Configuration.Default);
            var id = "id_example";  // Guid | 
            var updateReactorRequest = new UpdateReactorRequest(); // UpdateReactorRequest | 

            try
            {
                Reactor result = apiInstance.Update(id, updateReactorRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ReactorsApi.Update: " + e.Message );
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
 **updateReactorRequest** | [**UpdateReactorRequest**](UpdateReactorRequest.md)|  | 

### Return type

[**Reactor**](Reactor.md)

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
