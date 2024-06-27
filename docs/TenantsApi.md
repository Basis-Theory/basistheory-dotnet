# BasisTheory.net.Api.TenantsApi

All URIs are relative to *https://api.basistheory.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateConnection**](TenantsApi.md#createconnection) | **POST** /tenants/self/connections | 
[**CreateInvitation**](TenantsApi.md#createinvitation) | **POST** /tenants/self/invitations | 
[**Delete**](TenantsApi.md#delete) | **DELETE** /tenants/self | 
[**DeleteConnection**](TenantsApi.md#deleteconnection) | **DELETE** /tenants/self/connections | 
[**DeleteInvitation**](TenantsApi.md#deleteinvitation) | **DELETE** /tenants/self/invitations/{invitationId} | 
[**DeleteMember**](TenantsApi.md#deletemember) | **DELETE** /tenants/self/members/{memberId} | 
[**Get**](TenantsApi.md#get) | **GET** /tenants/self | 
[**GetInvitations**](TenantsApi.md#getinvitations) | **GET** /tenants/self/invitations | 
[**GetMembers**](TenantsApi.md#getmembers) | **GET** /tenants/self/members | 
[**GetTenantUsageReport**](TenantsApi.md#gettenantusagereport) | **GET** /tenants/self/reports/usage | 
[**ResendInvitation**](TenantsApi.md#resendinvitation) | **POST** /tenants/self/invitations/{invitationId}/resend | 
[**Update**](TenantsApi.md#update) | **PUT** /tenants/self | 
[**UpdateMember**](TenantsApi.md#updatemember) | **PUT** /tenants/self/members/{memberId} | 



## CreateConnection

> CreateTenantConnectionResponse CreateConnection (CreateTenantConnectionRequest createTenantConnectionRequest)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class CreateConnectionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var createTenantConnectionRequest = new CreateTenantConnectionRequest(); // CreateTenantConnectionRequest | 

            try
            {
                CreateTenantConnectionResponse result = apiInstance.CreateConnection(createTenantConnectionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.CreateConnection: " + e.Message );
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
 **createTenantConnectionRequest** | [**CreateTenantConnectionRequest**](CreateTenantConnectionRequest.md)|  | 

### Return type

[**CreateTenantConnectionResponse**](CreateTenantConnectionResponse.md)

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


## CreateInvitation

> TenantInvitationResponse CreateInvitation (CreateTenantInvitationRequest createTenantInvitationRequest)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class CreateInvitationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var createTenantInvitationRequest = new CreateTenantInvitationRequest(); // CreateTenantInvitationRequest | 

            try
            {
                TenantInvitationResponse result = apiInstance.CreateInvitation(createTenantInvitationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.CreateInvitation: " + e.Message );
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
 **createTenantInvitationRequest** | [**CreateTenantInvitationRequest**](CreateTenantInvitationRequest.md)|  | 

### Return type

[**TenantInvitationResponse**](TenantInvitationResponse.md)

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

> void Delete ()



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

            var apiInstance = new TenantsApi(Configuration.Default);

            try
            {
                apiInstance.Delete();
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.Delete: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

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


## DeleteConnection

> CreateTenantConnectionResponse DeleteConnection ()



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class DeleteConnectionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);

            try
            {
                CreateTenantConnectionResponse result = apiInstance.DeleteConnection();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.DeleteConnection: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**CreateTenantConnectionResponse**](CreateTenantConnectionResponse.md)

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


## DeleteInvitation

> void DeleteInvitation (Guid invitationId)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class DeleteInvitationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var invitationId = "invitationId_example";  // Guid | 

            try
            {
                apiInstance.DeleteInvitation(invitationId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.DeleteInvitation: " + e.Message );
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
 **invitationId** | **Guid**|  | 

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteMember

> void DeleteMember (Guid memberId)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class DeleteMemberExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var memberId = "memberId_example";  // Guid | 

            try
            {
                apiInstance.DeleteMember(memberId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.DeleteMember: " + e.Message );
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
 **memberId** | **Guid**|  | 

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **422** | Client Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Get

> Tenant Get ()



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

            var apiInstance = new TenantsApi(Configuration.Default);

            try
            {
                Tenant result = apiInstance.Get();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.Get: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**Tenant**](Tenant.md)

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


## GetInvitations

> TenantInvitationResponsePaginatedList GetInvitations (TenantInvitationStatus? status = null, int? page = null, string start = null, int? size = null)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class GetInvitationsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var status = (TenantInvitationStatus) "PENDING";  // TenantInvitationStatus? |  (optional) 
            var page = 56;  // int? |  (optional) 
            var start = "start_example";  // string |  (optional) 
            var size = 56;  // int? |  (optional) 

            try
            {
                TenantInvitationResponsePaginatedList result = apiInstance.GetInvitations(status, page, start, size);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.GetInvitations: " + e.Message );
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
 **status** | **TenantInvitationStatus?**|  | [optional] 
 **page** | **int?**|  | [optional] 
 **start** | **string**|  | [optional] 
 **size** | **int?**|  | [optional] 

### Return type

[**TenantInvitationResponsePaginatedList**](TenantInvitationResponsePaginatedList.md)

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
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetMembers

> TenantMemberResponsePaginatedList GetMembers (List<Guid> userId = null, int? page = null, string start = null, int? size = null)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class GetMembersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var userId = new List<Guid>(); // List<Guid> |  (optional) 
            var page = 56;  // int? |  (optional) 
            var start = "start_example";  // string |  (optional) 
            var size = 56;  // int? |  (optional) 

            try
            {
                TenantMemberResponsePaginatedList result = apiInstance.GetMembers(userId, page, start, size);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.GetMembers: " + e.Message );
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
 **userId** | [**List&lt;Guid&gt;**](Guid.md)|  | [optional] 
 **page** | **int?**|  | [optional] 
 **start** | **string**|  | [optional] 
 **size** | **int?**|  | [optional] 

### Return type

[**TenantMemberResponsePaginatedList**](TenantMemberResponsePaginatedList.md)

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
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetTenantUsageReport

> TenantUsageReport GetTenantUsageReport ()



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class GetTenantUsageReportExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);

            try
            {
                TenantUsageReport result = apiInstance.GetTenantUsageReport();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.GetTenantUsageReport: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**TenantUsageReport**](TenantUsageReport.md)

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


## ResendInvitation

> TenantInvitationResponse ResendInvitation (Guid invitationId)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class ResendInvitationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var invitationId = "invitationId_example";  // Guid | 

            try
            {
                TenantInvitationResponse result = apiInstance.ResendInvitation(invitationId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.ResendInvitation: " + e.Message );
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
 **invitationId** | **Guid**|  | 

### Return type

[**TenantInvitationResponse**](TenantInvitationResponse.md)

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Update

> Tenant Update (UpdateTenantRequest updateTenantRequest)



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

            var apiInstance = new TenantsApi(Configuration.Default);
            var updateTenantRequest = new UpdateTenantRequest(); // UpdateTenantRequest | 

            try
            {
                Tenant result = apiInstance.Update(updateTenantRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.Update: " + e.Message );
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
 **updateTenantRequest** | [**UpdateTenantRequest**](UpdateTenantRequest.md)|  | 

### Return type

[**Tenant**](Tenant.md)

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


## UpdateMember

> TenantMemberResponse UpdateMember (Guid memberId, UpdateTenantMemberRequest updateTenantMemberRequest = null)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class UpdateMemberExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new TenantsApi(Configuration.Default);
            var memberId = "memberId_example";  // Guid | 
            var updateTenantMemberRequest = new UpdateTenantMemberRequest(); // UpdateTenantMemberRequest |  (optional) 

            try
            {
                TenantMemberResponse result = apiInstance.UpdateMember(memberId, updateTenantMemberRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TenantsApi.UpdateMember: " + e.Message );
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
 **memberId** | **Guid**|  | 
 **updateTenantMemberRequest** | [**UpdateTenantMemberRequest**](UpdateTenantMemberRequest.md)|  | [optional] 

### Return type

[**TenantMemberResponse**](TenantMemberResponse.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json, application/xml, text/xml, application/*+xml
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)
