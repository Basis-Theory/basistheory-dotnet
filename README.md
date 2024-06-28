# BasisTheory.net - the C# library for the Basis Theory API

## Getting Started
* Sign-in to [Basis Theory](https://basistheory.com) and go to [Applications](https://portal.basistheory.com/applications)
* Create a Basis Theory Private Application
* All permissions should be selected
* Paste the API Key into the `BT-API-KEY` variable

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: v1
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.1 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;
```
<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BasisTheory.net.Api;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://api.basistheory.com";
            // Configure API key authorization: ApiKey
            config.ApiKey.Add("BT-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.ApiKeyPrefix.Add("BT-API-KEY", "Bearer");

            var apiInstance = new ApplicationKeysApi(config);
            var id = "id_example";  // Guid | 

            try
            {
                ApplicationKey result = apiInstance.Create(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ApplicationKeysApi.Create: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://api.basistheory.com*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ApplicationKeysApi* | [**Create**](docs/ApplicationKeysApi.md#create) | **POST** /applications/{id}/keys | 
*ApplicationKeysApi* | [**Delete**](docs/ApplicationKeysApi.md#delete) | **DELETE** /applications/{id}/keys/{keyId} | 
*ApplicationKeysApi* | [**Get**](docs/ApplicationKeysApi.md#get) | **GET** /applications/{id}/keys | 
*ApplicationKeysApi* | [**GetById**](docs/ApplicationKeysApi.md#getbyid) | **GET** /applications/{id}/keys/{keyId} | 
*ApplicationTemplatesApi* | [**Get**](docs/ApplicationTemplatesApi.md#get) | **GET** /application-templates | 
*ApplicationTemplatesApi* | [**GetById**](docs/ApplicationTemplatesApi.md#getbyid) | **GET** /application-templates/{id} | 
*ApplicationsApi* | [**Create**](docs/ApplicationsApi.md#create) | **POST** /applications | 
*ApplicationsApi* | [**Delete**](docs/ApplicationsApi.md#delete) | **DELETE** /applications/{id} | 
*ApplicationsApi* | [**Get**](docs/ApplicationsApi.md#get) | **GET** /applications | 
*ApplicationsApi* | [**GetById**](docs/ApplicationsApi.md#getbyid) | **GET** /applications/{id} | 
*ApplicationsApi* | [**GetByKey**](docs/ApplicationsApi.md#getbykey) | **GET** /applications/key | 
*ApplicationsApi* | [**RegenerateKey**](docs/ApplicationsApi.md#regeneratekey) | **POST** /applications/{id}/regenerate | 
*ApplicationsApi* | [**Update**](docs/ApplicationsApi.md#update) | **PUT** /applications/{id} | 
*LogsApi* | [**Get**](docs/LogsApi.md#get) | **GET** /logs | 
*LogsApi* | [**GetEntityTypes**](docs/LogsApi.md#getentitytypes) | **GET** /logs/entity-types | 
*PermissionsApi* | [**Get**](docs/PermissionsApi.md#get) | **GET** /permissions | 
*ProxiesApi* | [**Create**](docs/ProxiesApi.md#create) | **POST** /proxies | 
*ProxiesApi* | [**Delete**](docs/ProxiesApi.md#delete) | **DELETE** /proxies/{id} | 
*ProxiesApi* | [**Get**](docs/ProxiesApi.md#get) | **GET** /proxies | 
*ProxiesApi* | [**GetById**](docs/ProxiesApi.md#getbyid) | **GET** /proxies/{id} | 
*ProxiesApi* | [**Patch**](docs/ProxiesApi.md#patch) | **PATCH** /proxies/{id} | 
*ProxiesApi* | [**Update**](docs/ProxiesApi.md#update) | **PUT** /proxies/{id} | 
*ReactorFormulasApi* | [**Create**](docs/ReactorFormulasApi.md#create) | **POST** /reactor-formulas | 
*ReactorFormulasApi* | [**Delete**](docs/ReactorFormulasApi.md#delete) | **DELETE** /reactor-formulas/{id} | 
*ReactorFormulasApi* | [**Get**](docs/ReactorFormulasApi.md#get) | **GET** /reactor-formulas | 
*ReactorFormulasApi* | [**GetById**](docs/ReactorFormulasApi.md#getbyid) | **GET** /reactor-formulas/{id} | 
*ReactorFormulasApi* | [**Update**](docs/ReactorFormulasApi.md#update) | **PUT** /reactor-formulas/{id} | 
*ReactorsApi* | [**Create**](docs/ReactorsApi.md#create) | **POST** /reactors | 
*ReactorsApi* | [**Delete**](docs/ReactorsApi.md#delete) | **DELETE** /reactors/{id} | 
*ReactorsApi* | [**Get**](docs/ReactorsApi.md#get) | **GET** /reactors | 
*ReactorsApi* | [**GetById**](docs/ReactorsApi.md#getbyid) | **GET** /reactors/{id} | 
*ReactorsApi* | [**Patch**](docs/ReactorsApi.md#patch) | **PATCH** /reactors/{id} | 
*ReactorsApi* | [**React**](docs/ReactorsApi.md#react) | **POST** /reactors/{id}/react | 
*ReactorsApi* | [**Update**](docs/ReactorsApi.md#update) | **PUT** /reactors/{id} | 
*RolesApi* | [**Get**](docs/RolesApi.md#get) | **GET** /roles | 
*SessionsApi* | [**Authorize**](docs/SessionsApi.md#authorize) | **POST** /sessions/authorize | 
*SessionsApi* | [**Create**](docs/SessionsApi.md#create) | **POST** /sessions | 
*TenantsApi* | [**CreateConnection**](docs/TenantsApi.md#createconnection) | **POST** /tenants/self/connections | 
*TenantsApi* | [**CreateInvitation**](docs/TenantsApi.md#createinvitation) | **POST** /tenants/self/invitations | 
*TenantsApi* | [**Delete**](docs/TenantsApi.md#delete) | **DELETE** /tenants/self | 
*TenantsApi* | [**DeleteConnection**](docs/TenantsApi.md#deleteconnection) | **DELETE** /tenants/self/connections | 
*TenantsApi* | [**DeleteInvitation**](docs/TenantsApi.md#deleteinvitation) | **DELETE** /tenants/self/invitations/{invitationId} | 
*TenantsApi* | [**DeleteMember**](docs/TenantsApi.md#deletemember) | **DELETE** /tenants/self/members/{memberId} | 
*TenantsApi* | [**Get**](docs/TenantsApi.md#get) | **GET** /tenants/self | 
*TenantsApi* | [**GetInvitations**](docs/TenantsApi.md#getinvitations) | **GET** /tenants/self/invitations | 
*TenantsApi* | [**GetMembers**](docs/TenantsApi.md#getmembers) | **GET** /tenants/self/members | 
*TenantsApi* | [**GetTenantUsageReport**](docs/TenantsApi.md#gettenantusagereport) | **GET** /tenants/self/reports/usage | 
*TenantsApi* | [**ResendInvitation**](docs/TenantsApi.md#resendinvitation) | **POST** /tenants/self/invitations/{invitationId}/resend | 
*TenantsApi* | [**Update**](docs/TenantsApi.md#update) | **PUT** /tenants/self | 
*TenantsApi* | [**UpdateMember**](docs/TenantsApi.md#updatemember) | **PUT** /tenants/self/members/{memberId} | 
*ThreeDSApi* | [**ThreeDSAuthenticateSession**](docs/ThreeDSApi.md#threedsauthenticatesession) | **POST** /3ds/sessions/{sessionId}/authenticate | 
*ThreeDSApi* | [**ThreeDSGetChallengeResult**](docs/ThreeDSApi.md#threedsgetchallengeresult) | **GET** /3ds/sessions/{sessionId}/challenge-result | 
*ThreeDSApi* | [**ThreeDSGetSessionById**](docs/ThreeDSApi.md#threedsgetsessionbyid) | **GET** /3ds/sessions/{id} | 
*TokenizeApi* | [**Tokenize**](docs/TokenizeApi.md#tokenize) | **POST** /tokenize | 
*TokensApi* | [**Create**](docs/TokensApi.md#create) | **POST** /tokens | 
*TokensApi* | [**Delete**](docs/TokensApi.md#delete) | **DELETE** /tokens/{id} | 
*TokensApi* | [**Get**](docs/TokensApi.md#get) | **GET** /tokens | 
*TokensApi* | [**GetById**](docs/TokensApi.md#getbyid) | **GET** /tokens/{id} | 
*TokensApi* | [**GetV2**](docs/TokensApi.md#getv2) | **GET** /v2/tokens | 
*TokensApi* | [**Search**](docs/TokensApi.md#search) | **POST** /tokens/search | 
*TokensApi* | [**Update**](docs/TokensApi.md#update) | **PATCH** /tokens/{id} | 


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.AccessRule](docs/AccessRule.md)
 - [Model.Application](docs/Application.md)
 - [Model.ApplicationKey](docs/ApplicationKey.md)
 - [Model.ApplicationPaginatedList](docs/ApplicationPaginatedList.md)
 - [Model.ApplicationTemplate](docs/ApplicationTemplate.md)
 - [Model.AuthenticateThreeDSSessionRequest](docs/AuthenticateThreeDSSessionRequest.md)
 - [Model.AuthorizeSessionRequest](docs/AuthorizeSessionRequest.md)
 - [Model.BinDetails](docs/BinDetails.md)
 - [Model.BinDetailsBank](docs/BinDetailsBank.md)
 - [Model.BinDetailsCountry](docs/BinDetailsCountry.md)
 - [Model.BinDetailsProduct](docs/BinDetailsProduct.md)
 - [Model.CardDetails](docs/CardDetails.md)
 - [Model.Condition](docs/Condition.md)
 - [Model.CreateApplicationRequest](docs/CreateApplicationRequest.md)
 - [Model.CreateProxyRequest](docs/CreateProxyRequest.md)
 - [Model.CreateReactorFormulaRequest](docs/CreateReactorFormulaRequest.md)
 - [Model.CreateReactorRequest](docs/CreateReactorRequest.md)
 - [Model.CreateSessionResponse](docs/CreateSessionResponse.md)
 - [Model.CreateTenantConnectionRequest](docs/CreateTenantConnectionRequest.md)
 - [Model.CreateTenantConnectionResponse](docs/CreateTenantConnectionResponse.md)
 - [Model.CreateTenantInvitationRequest](docs/CreateTenantInvitationRequest.md)
 - [Model.CreateTokenRequest](docs/CreateTokenRequest.md)
 - [Model.CursorPagination](docs/CursorPagination.md)
 - [Model.GetApplications](docs/GetApplications.md)
 - [Model.GetLogs](docs/GetLogs.md)
 - [Model.GetPermissions](docs/GetPermissions.md)
 - [Model.GetProxies](docs/GetProxies.md)
 - [Model.GetReactorFormulas](docs/GetReactorFormulas.md)
 - [Model.GetReactors](docs/GetReactors.md)
 - [Model.GetTenantInvitations](docs/GetTenantInvitations.md)
 - [Model.GetTenantMembers](docs/GetTenantMembers.md)
 - [Model.GetTokens](docs/GetTokens.md)
 - [Model.GetTokensV2](docs/GetTokensV2.md)
 - [Model.Log](docs/Log.md)
 - [Model.LogEntityType](docs/LogEntityType.md)
 - [Model.LogPaginatedList](docs/LogPaginatedList.md)
 - [Model.Pagination](docs/Pagination.md)
 - [Model.PatchProxyRequest](docs/PatchProxyRequest.md)
 - [Model.PatchReactorRequest](docs/PatchReactorRequest.md)
 - [Model.Permission](docs/Permission.md)
 - [Model.Privacy](docs/Privacy.md)
 - [Model.ProblemDetails](docs/ProblemDetails.md)
 - [Model.Proxy](docs/Proxy.md)
 - [Model.ProxyPaginatedList](docs/ProxyPaginatedList.md)
 - [Model.ProxyTransform](docs/ProxyTransform.md)
 - [Model.ReactRequest](docs/ReactRequest.md)
 - [Model.ReactResponse](docs/ReactResponse.md)
 - [Model.Reactor](docs/Reactor.md)
 - [Model.ReactorFormula](docs/ReactorFormula.md)
 - [Model.ReactorFormulaConfiguration](docs/ReactorFormulaConfiguration.md)
 - [Model.ReactorFormulaPaginatedList](docs/ReactorFormulaPaginatedList.md)
 - [Model.ReactorFormulaRequestParameter](docs/ReactorFormulaRequestParameter.md)
 - [Model.ReactorPaginatedList](docs/ReactorPaginatedList.md)
 - [Model.Role](docs/Role.md)
 - [Model.SearchTokensRequest](docs/SearchTokensRequest.md)
 - [Model.StringStringKeyValuePair](docs/StringStringKeyValuePair.md)
 - [Model.Tenant](docs/Tenant.md)
 - [Model.TenantConnectionOptions](docs/TenantConnectionOptions.md)
 - [Model.TenantInvitationResponse](docs/TenantInvitationResponse.md)
 - [Model.TenantInvitationResponsePaginatedList](docs/TenantInvitationResponsePaginatedList.md)
 - [Model.TenantInvitationStatus](docs/TenantInvitationStatus.md)
 - [Model.TenantMemberResponse](docs/TenantMemberResponse.md)
 - [Model.TenantMemberResponsePaginatedList](docs/TenantMemberResponsePaginatedList.md)
 - [Model.TenantUsageReport](docs/TenantUsageReport.md)
 - [Model.ThreeDSAcsRenderingType](docs/ThreeDSAcsRenderingType.md)
 - [Model.ThreeDSAddress](docs/ThreeDSAddress.md)
 - [Model.ThreeDSAuthentication](docs/ThreeDSAuthentication.md)
 - [Model.ThreeDSCardholderAccountInfo](docs/ThreeDSCardholderAccountInfo.md)
 - [Model.ThreeDSCardholderAuthenticationInfo](docs/ThreeDSCardholderAuthenticationInfo.md)
 - [Model.ThreeDSCardholderInfo](docs/ThreeDSCardholderInfo.md)
 - [Model.ThreeDSCardholderPhoneNumber](docs/ThreeDSCardholderPhoneNumber.md)
 - [Model.ThreeDSDeviceInfo](docs/ThreeDSDeviceInfo.md)
 - [Model.ThreeDSMerchantInfo](docs/ThreeDSMerchantInfo.md)
 - [Model.ThreeDSMerchantRiskInfo](docs/ThreeDSMerchantRiskInfo.md)
 - [Model.ThreeDSMessageExtension](docs/ThreeDSMessageExtension.md)
 - [Model.ThreeDSMethod](docs/ThreeDSMethod.md)
 - [Model.ThreeDSMobileSdkRenderOptions](docs/ThreeDSMobileSdkRenderOptions.md)
 - [Model.ThreeDSPriorAuthenticationInfo](docs/ThreeDSPriorAuthenticationInfo.md)
 - [Model.ThreeDSPurchaseInfo](docs/ThreeDSPurchaseInfo.md)
 - [Model.ThreeDSRequestorInfo](docs/ThreeDSRequestorInfo.md)
 - [Model.ThreeDSSession](docs/ThreeDSSession.md)
 - [Model.ThreeDSVersion](docs/ThreeDSVersion.md)
 - [Model.Token](docs/Token.md)
 - [Model.TokenCursorPaginatedList](docs/TokenCursorPaginatedList.md)
 - [Model.TokenEnrichments](docs/TokenEnrichments.md)
 - [Model.TokenMetrics](docs/TokenMetrics.md)
 - [Model.TokenPaginatedList](docs/TokenPaginatedList.md)
 - [Model.TokenReport](docs/TokenReport.md)
 - [Model.UpdateApplicationRequest](docs/UpdateApplicationRequest.md)
 - [Model.UpdatePrivacy](docs/UpdatePrivacy.md)
 - [Model.UpdateProxyRequest](docs/UpdateProxyRequest.md)
 - [Model.UpdateReactorFormulaRequest](docs/UpdateReactorFormulaRequest.md)
 - [Model.UpdateReactorRequest](docs/UpdateReactorRequest.md)
 - [Model.UpdateTenantMemberRequest](docs/UpdateTenantMemberRequest.md)
 - [Model.UpdateTenantRequest](docs/UpdateTenantRequest.md)
 - [Model.UpdateTokenRequest](docs/UpdateTokenRequest.md)
 - [Model.User](docs/User.md)
 - [Model.ValidationProblemDetails](docs/ValidationProblemDetails.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="ApiKey"></a>
### ApiKey

- **Type**: API key
- **API key parameter name**: BT-API-KEY
- **Location**: HTTP header

