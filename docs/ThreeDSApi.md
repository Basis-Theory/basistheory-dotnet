# BasisTheory.net.Api.ThreeDSApi

All URIs are relative to *https://api.basistheory.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ThreeDSAuthenticateSession**](ThreeDSApi.md#threedsauthenticatesession) | **POST** /3ds/sessions/{sessionId}/authenticate | 
[**ThreeDSGetChallengeResult**](ThreeDSApi.md#threedsgetchallengeresult) | **GET** /3ds/sessions/{sessionId}/challenge-result | 
[**ThreeDSGetSessionById**](ThreeDSApi.md#threedsgetsessionbyid) | **GET** /3ds/sessions/{id} | 



## ThreeDSAuthenticateSession

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
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ThreeDSApi(Configuration.Default);
            var sessionId = "sessionId_example";  // Guid | 
            var authenticateThreeDSSessionRequest = new AuthenticateThreeDSSessionRequest(); // AuthenticateThreeDSSessionRequest |  (optional) 

            try
            {
                ThreeDSAuthentication result = apiInstance.ThreeDSAuthenticateSession(sessionId, authenticateThreeDSSessionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ThreeDSApi.ThreeDSAuthenticateSession: " + e.Message );
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
 **sessionId** | **Guid**|  | 
 **authenticateThreeDSSessionRequest** | [**AuthenticateThreeDSSessionRequest**](AuthenticateThreeDSSessionRequest.md)|  | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ThreeDSGetChallengeResult

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
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ThreeDSApi(Configuration.Default);
            var sessionId = "sessionId_example";  // Guid | 

            try
            {
                ThreeDSAuthentication result = apiInstance.ThreeDSGetChallengeResult(sessionId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ThreeDSApi.ThreeDSGetChallengeResult: " + e.Message );
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
 **sessionId** | **Guid**|  | 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ThreeDSGetSessionById

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
            Configuration.Default.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            Configuration.Default.AddApiKey("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("BT-API-KEY", "Bearer");

            var apiInstance = new ThreeDSApi(Configuration.Default);
            var id = "id_example";  // Guid | 

            try
            {
                ThreeDSSession result = apiInstance.ThreeDSGetSessionById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ThreeDSApi.ThreeDSGetSessionById: " + e.Message );
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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

