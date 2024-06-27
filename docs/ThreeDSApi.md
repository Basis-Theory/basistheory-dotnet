# BasisTheory.net.Api.ThreeDSApi

All URIs are relative to *https://api.basistheory.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ThreeDSAuthenticateSession**](ThreeDSApi.md#threedsauthenticatesession) | **POST** /3ds/sessions/{sessionId}/authenticate |  |
| [**ThreeDSGetChallengeResult**](ThreeDSApi.md#threedsgetchallengeresult) | **GET** /3ds/sessions/{sessionId}/challenge-result |  |
| [**ThreeDSGetSessionById**](ThreeDSApi.md#threedsgetsessionbyid) | **GET** /3ds/sessions/{id} |  |

<a name="threedsauthenticatesession"></a>
# **ThreeDSAuthenticateSession**
> ThreeDSAuthentication ThreeDSAuthenticateSession (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class ThreeDSAuthenticateSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ThreeDSApi(config);
            var sessionId = "sessionId_example";  // Guid | 
            var authenticateThreeDSSessionRequest = new AuthenticateThreeDSSessionRequest(); // AuthenticateThreeDSSessionRequest |  (optional) 

            try
            {
                ThreeDSAuthentication result = apiInstance.ThreeDSAuthenticateSession(sessionId, authenticateThreeDSSessionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThreeDSApi.ThreeDSAuthenticateSession: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ThreeDSAuthenticateSessionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ThreeDSAuthentication> response = apiInstance.ThreeDSAuthenticateSessionWithHttpInfo(sessionId, authenticateThreeDSSessionRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ThreeDSApi.ThreeDSAuthenticateSessionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sessionId** | **Guid** |  |  |
| **authenticateThreeDSSessionRequest** | [**AuthenticateThreeDSSessionRequest**](AuthenticateThreeDSSessionRequest.md) |  | [optional]  |

### Return type

[**ThreeDSAuthentication**](ThreeDSAuthentication.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="threedsgetchallengeresult"></a>
# **ThreeDSGetChallengeResult**
> ThreeDSAuthentication ThreeDSGetChallengeResult (Guid sessionId)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class ThreeDSGetChallengeResultExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ThreeDSApi(config);
            var sessionId = "sessionId_example";  // Guid | 

            try
            {
                ThreeDSAuthentication result = apiInstance.ThreeDSGetChallengeResult(sessionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThreeDSApi.ThreeDSGetChallengeResult: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ThreeDSGetChallengeResultWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ThreeDSAuthentication> response = apiInstance.ThreeDSGetChallengeResultWithHttpInfo(sessionId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ThreeDSApi.ThreeDSGetChallengeResultWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sessionId** | **Guid** |  |  |

### Return type

[**ThreeDSAuthentication**](ThreeDSAuthentication.md)

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
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="threedsgetsessionbyid"></a>
# **ThreeDSGetSessionById**
> ThreeDSSession ThreeDSGetSessionById (Guid id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class ThreeDSGetSessionByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ThreeDSApi(config);
            var id = "id_example";  // Guid | 

            try
            {
                ThreeDSSession result = apiInstance.ThreeDSGetSessionById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThreeDSApi.ThreeDSGetSessionById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ThreeDSGetSessionByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ThreeDSSession> response = apiInstance.ThreeDSGetSessionByIdWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ThreeDSApi.ThreeDSGetSessionByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**ThreeDSSession**](ThreeDSSession.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

