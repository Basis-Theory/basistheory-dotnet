# BasisTheory.net.Api.TenantsApi

All URIs are relative to *https://api.basistheory.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateConnection**](TenantsApi.md#createconnection) | **POST** /tenants/self/connections |  |
| [**CreateInvitation**](TenantsApi.md#createinvitation) | **POST** /tenants/self/invitations |  |
| [**Delete**](TenantsApi.md#delete) | **DELETE** /tenants/self |  |
| [**DeleteConnection**](TenantsApi.md#deleteconnection) | **DELETE** /tenants/self/connections |  |
| [**DeleteInvitation**](TenantsApi.md#deleteinvitation) | **DELETE** /tenants/self/invitations/{invitationId} |  |
| [**DeleteMember**](TenantsApi.md#deletemember) | **DELETE** /tenants/self/members/{memberId} |  |
| [**Get**](TenantsApi.md#get) | **GET** /tenants/self |  |
| [**GetInvitations**](TenantsApi.md#getinvitations) | **GET** /tenants/self/invitations |  |
| [**GetMembers**](TenantsApi.md#getmembers) | **GET** /tenants/self/members |  |
| [**GetTenantUsageReport**](TenantsApi.md#gettenantusagereport) | **GET** /tenants/self/reports/usage |  |
| [**OwnerGet**](TenantsApi.md#ownerget) | **GET** /tenants/self/owner |  |
| [**ResendInvitation**](TenantsApi.md#resendinvitation) | **POST** /tenants/self/invitations/{invitationId}/resend |  |
| [**Update**](TenantsApi.md#update) | **PUT** /tenants/self |  |
| [**UpdateMember**](TenantsApi.md#updatemember) | **PUT** /tenants/self/members/{memberId} |  |

<a name="createconnection"></a>
# **CreateConnection**
> CreateTenantConnectionResponse CreateConnection (CreateTenantConnectionRequest createTenantConnectionRequest)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var createTenantConnectionRequest = new CreateTenantConnectionRequest()
{
    Strategy = ...
    Options = ...
};

CreateTenantConnectionResponse result = apiInstance.CreateConnection(createTenantConnectionRequest);
```

#### Using the CreateConnectionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<CreateTenantConnectionResponse> response = apiInstance.CreateConnectionWithHttpInfo(createTenantConnectionRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.CreateConnectionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createTenantConnectionRequest** | [**CreateTenantConnectionRequest**](CreateTenantConnectionRequest.md) |  |  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createinvitation"></a>
# **CreateInvitation**
> TenantInvitationResponse CreateInvitation (CreateTenantInvitationRequest createTenantInvitationRequest)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var createTenantInvitationRequest = new CreateTenantInvitationRequest()
{
    Email = ...
    Role = ...
};

TenantInvitationResponse result = apiInstance.CreateInvitation(createTenantInvitationRequest);
```

#### Using the CreateInvitationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TenantInvitationResponse> response = apiInstance.CreateInvitationWithHttpInfo(createTenantInvitationRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.CreateInvitationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createTenantInvitationRequest** | [**CreateTenantInvitationRequest**](CreateTenantInvitationRequest.md) |  |  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="delete"></a>
# **Delete**
> void Delete ()



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);

apiInstance.Delete();
```

#### Using the DeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DeleteWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.DeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteconnection"></a>
# **DeleteConnection**
> CreateTenantConnectionResponse DeleteConnection ()



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);

CreateTenantConnectionResponse result = apiInstance.DeleteConnection();
```

#### Using the DeleteConnectionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<CreateTenantConnectionResponse> response = apiInstance.DeleteConnectionWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.DeleteConnectionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteinvitation"></a>
# **DeleteInvitation**
> void DeleteInvitation (Guid invitationId)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var invitationId = Guid.Parse("");

apiInstance.DeleteInvitation(invitationId);
```

#### Using the DeleteInvitationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DeleteInvitationWithHttpInfo(invitationId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.DeleteInvitationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **invitationId** | **Guid** |  |  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletemember"></a>
# **DeleteMember**
> void DeleteMember (Guid memberId)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var memberId = Guid.Parse("");

apiInstance.DeleteMember(memberId);
```

#### Using the DeleteMemberWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DeleteMemberWithHttpInfo(memberId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.DeleteMemberWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **memberId** | **Guid** |  |  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="get"></a>
# **Get**
> Tenant Get ()



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);

Tenant result = apiInstance.Get();
```

#### Using the GetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Tenant> response = apiInstance.GetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.GetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getinvitations"></a>
# **GetInvitations**
> TenantInvitationResponsePaginatedList GetInvitations (TenantInvitationStatus? status = null, int? page = null, string start = null, int? size = null)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var status = (TenantInvitationStatus) "PENDING";
var page = 1;
var start = "";
var size = 1;

TenantInvitationResponsePaginatedList result = apiInstance.GetInvitations(status, page, start, size);
```

#### Using the GetInvitationsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TenantInvitationResponsePaginatedList> response = apiInstance.GetInvitationsWithHttpInfo(status, page, start, size);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.GetInvitationsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **status** | **TenantInvitationStatus?** |  | [optional]  |
| **page** | **int?** |  | [optional]  |
| **start** | **string** |  | [optional]  |
| **size** | **int?** |  | [optional]  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmembers"></a>
# **GetMembers**
> TenantMemberResponsePaginatedList GetMembers (List<Guid> userId = null, int? page = null, string start = null, int? size = null)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var userId = new List<Guid>();
var page = 1;
var start = "";
var size = 1;

TenantMemberResponsePaginatedList result = apiInstance.GetMembers(userId, page, start, size);
```

#### Using the GetMembersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TenantMemberResponsePaginatedList> response = apiInstance.GetMembersWithHttpInfo(userId, page, start, size);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.GetMembersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | [**List&lt;Guid&gt;**](Guid.md) |  | [optional]  |
| **page** | **int?** |  | [optional]  |
| **start** | **string** |  | [optional]  |
| **size** | **int?** |  | [optional]  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettenantusagereport"></a>
# **GetTenantUsageReport**
> TenantUsageReport GetTenantUsageReport ()



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);

TenantUsageReport result = apiInstance.GetTenantUsageReport();
```

#### Using the GetTenantUsageReportWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TenantUsageReport> response = apiInstance.GetTenantUsageReportWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.GetTenantUsageReportWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ownerget"></a>
# **OwnerGet**
> TenantMemberResponse OwnerGet ()



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);

TenantMemberResponse result = apiInstance.OwnerGet();
```

#### Using the OwnerGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TenantMemberResponse> response = apiInstance.OwnerGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.OwnerGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**TenantMemberResponse**](TenantMemberResponse.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="resendinvitation"></a>
# **ResendInvitation**
> TenantInvitationResponse ResendInvitation (Guid invitationId)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var invitationId = Guid.Parse("");

TenantInvitationResponse result = apiInstance.ResendInvitation(invitationId);
```

#### Using the ResendInvitationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TenantInvitationResponse> response = apiInstance.ResendInvitationWithHttpInfo(invitationId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.ResendInvitationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **invitationId** | **Guid** |  |  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="update"></a>
# **Update**
> Tenant Update (UpdateTenantRequest updateTenantRequest)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var updateTenantRequest = new UpdateTenantRequest()
{
    Name = ...
    Settings = ...
};

Tenant result = apiInstance.Update(updateTenantRequest);
```

#### Using the UpdateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Tenant> response = apiInstance.UpdateWithHttpInfo(updateTenantRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.UpdateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **updateTenantRequest** | [**UpdateTenantRequest**](UpdateTenantRequest.md) |  |  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatemember"></a>
# **UpdateMember**
> TenantMemberResponse UpdateMember (Guid memberId, UpdateTenantMemberRequest updateTenantMemberRequest = null)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new TenantsApi(config);
var memberId = Guid.Parse("");
var updateTenantMemberRequest = new UpdateTenantMemberRequest()
{
    Role = ...
};

TenantMemberResponse result = apiInstance.UpdateMember(memberId, updateTenantMemberRequest);
```

#### Using the UpdateMemberWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TenantMemberResponse> response = apiInstance.UpdateMemberWithHttpInfo(memberId, updateTenantMemberRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TenantsApi.UpdateMemberWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **memberId** | **Guid** |  |  |
| **updateTenantMemberRequest** | [**UpdateTenantMemberRequest**](UpdateTenantMemberRequest.md) |  | [optional]  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

