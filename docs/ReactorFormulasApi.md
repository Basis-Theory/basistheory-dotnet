# BasisTheory.net.Api.ReactorFormulasApi

All URIs are relative to *https://api.basistheory.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Create**](ReactorFormulasApi.md#create) | **POST** /reactor-formulas |  |
| [**Delete**](ReactorFormulasApi.md#delete) | **DELETE** /reactor-formulas/{id} |  |
| [**Get**](ReactorFormulasApi.md#get) | **GET** /reactor-formulas |  |
| [**GetById**](ReactorFormulasApi.md#getbyid) | **GET** /reactor-formulas/{id} |  |
| [**Update**](ReactorFormulasApi.md#update) | **PUT** /reactor-formulas/{id} |  |

<a name="create"></a>
# **Create**
> ReactorFormula Create (CreateReactorFormulaRequest createReactorFormulaRequest)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new ReactorFormulasApi(config);
var createReactorFormulaRequest = new CreateReactorFormulaRequest(/*required parameters*/)
{
    // Additional parameters
};

try
{
    ReactorFormula result = apiInstance.Create(createReactorFormulaRequest);
    Console.WriteLine(result);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling ReactorFormulasApi.Create: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the CreateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ReactorFormula> response = apiInstance.CreateWithHttpInfo(createReactorFormulaRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ReactorFormulasApi.CreateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createReactorFormulaRequest** | [**CreateReactorFormulaRequest**](CreateReactorFormulaRequest.md) |  |  |

### Return type

[**ReactorFormula**](ReactorFormula.md)

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
> void Delete (Guid id)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new ReactorFormulasApi(config);
var id = "id_example";

try
{
    apiInstance.Delete(id);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling ReactorFormulasApi.Delete: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the DeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DeleteWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ReactorFormulasApi.DeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

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

<a name="get"></a>
# **Get**
> ReactorFormulaPaginatedList Get (string name = null, int? page = null, string start = null, int? size = null)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new ReactorFormulasApi(config);
var name = "name_example";
var page = 56;
var start = "start_example";
var size = 56;

try
{
    ReactorFormulaPaginatedList result = apiInstance.Get(name, page, start, size);
    Console.WriteLine(result);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling ReactorFormulasApi.Get: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the GetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ReactorFormulaPaginatedList> response = apiInstance.GetWithHttpInfo(name, page, start, size);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ReactorFormulasApi.GetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** |  | [optional]  |
| **page** | **int?** |  | [optional]  |
| **start** | **string** |  | [optional]  |
| **size** | **int?** |  | [optional]  |

### Return type

[**ReactorFormulaPaginatedList**](ReactorFormulaPaginatedList.md)

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

<a name="getbyid"></a>
# **GetById**
> ReactorFormula GetById (Guid id)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new ReactorFormulasApi(config);
var id = "id_example";

try
{
    ReactorFormula result = apiInstance.GetById(id);
    Console.WriteLine(result);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling ReactorFormulasApi.GetById: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the GetByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ReactorFormula> response = apiInstance.GetByIdWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ReactorFormulasApi.GetByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**ReactorFormula**](ReactorFormula.md)

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

<a name="update"></a>
# **Update**
> ReactorFormula Update (Guid id, UpdateReactorFormulaRequest updateReactorFormulaRequest)



### Example
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

Configuration config = new Configuration();
config.BasePath = "https://api.basistheory.com";
config.AddApiKey("BT-API-KEY", "YOUR_API_KEY");

var apiInstance = new ReactorFormulasApi(config);
var id = "id_example";
var updateReactorFormulaRequest = new UpdateReactorFormulaRequest(/*required parameters*/)
{
    // Additional parameters
};

try
{
    ReactorFormula result = apiInstance.Update(id, updateReactorFormulaRequest);
    Console.WriteLine(result);
}
catch (ApiException  e)
{
    Console.WriteLine("Exception when calling ReactorFormulasApi.Update: " + e.Message);
    Console.WriteLine("Status Code: " + e.ErrorCode);
    Console.WriteLine(e.StackTrace);
}
```

#### Using the UpdateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ReactorFormula> response = apiInstance.UpdateWithHttpInfo(id, updateReactorFormulaRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ReactorFormulasApi.UpdateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **updateReactorFormulaRequest** | [**UpdateReactorFormulaRequest**](UpdateReactorFormulaRequest.md) |  |  |

### Return type

[**ReactorFormula**](ReactorFormula.md)

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
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

