# BasisTheory.net.Api.PermissionsApi

All URIs are relative to *https://api.basistheory.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Get**](PermissionsApi.md#get) | **GET** /permissions | 



## Get

> List&lt;Permission&gt; Get (string applicationType = null)



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

            var apiInstance = new PermissionsApi(Configuration.Default);
            var applicationType = "applicationType_example";  // string |  (optional) 

            try
            {
                List<Permission> result = apiInstance.Get(applicationType);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PermissionsApi.Get: " + e.Message );
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
 **applicationType** | **string**|  | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)
