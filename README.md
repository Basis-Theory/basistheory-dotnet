# Basis Theory .NET SDK

[![NuGet](https://img.shields.io/nuget/v/basistheory.net.svg)](https://www.nuget.org/packages/BasisTheory.net/)
[![Verify](https://github.com/Basis-Theory/basistheory-dotnet/actions/workflows/verify.yml/badge.svg)](https://github.com/Basis-Theory/basistheory-dotnet/actions/workflows/verify.yml)

The [Basis Theory](https://basistheory.com/) .NET SDK for .NET Core 2.1+, .NET Standard 2.1+, and .NET Framework 4.6.1+.

## Installation

Using the [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```sh
dotnet add package BasisTheory.net
```

Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference):

```sh
nuget install BasisTheory.net
```

Using the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```powershell
Install-Package BasisTheory.net
```

## Documentation

For a complete list of endpoints and examples, please refer to our [API docs](https://docs.basistheory.com/api-reference/?csharp#introduction)

## Usage

### Per-request configuration

All of the service methods accept an optional `RequestOptions` object. This is
used if you want to set a [correlation ID](https://docs.basistheory.com/api-reference/?csharp#request-correlation) or if you want to set a per-request [`X-API-KEY`](https://docs.basistheory.com/api-reference/?csharp#authentication)

```csharp
var requestOptions = new RequestOptions();
requestOptions.ApiKey = "API KEY";
requestOptions.CorrelationId = Guid.NewGuid().ToString();
```

### Using a custom `HttpClient`

Each client can be configured to use a custom `HttpClient`:

```csharp
var httpClient = new HttpClient();
var client = new TokenClient(apiKey, httpClient: httpClient);
```

### Setting a custom API Url

Each client can set a custom API Url, such as calling a deployed instance of the Token Proxy.

```csharp
var client = new TokenClient(apiKey, apiBaseUrl: "https://token-proxy.somedomain.com");
```

### AspNetCore Setup

See complete documentation in the [BasisTheory.net.AspNetCore project](https://github.com/Basis-Theory/basistheory-dotnet/tree/master/src/BasisTheory.net.AspNetCore)

## Encryption and Key Management

Encryption and Key Management is provided to enable you to manage your own data encryption and key storage with your KMS provider of choice.

### Key Management

```csharp
// Provider Key Repository implementation which must set the KeyId when saving the generated ProviderEncryptionKey
var providerKeyRepository = new ProviderKeyRepositoryImpl();
var rsaProviderKeyFactory = new RSAKeyVaultProviderKeyFactory();

var providerKeyService = new ProviderKeyService(new CachingService(), providerKeyRepository, 
  new List<IProviderKeyFactory> { 
    rsaProviderKeyFactory 
  });

// Retrieves or creates a key by name with a registered IProviderKeyFactory for the provided provider and algorithm
var providerEncryptionKey = providerKeyService.GetOrCreateAsync("encryption-key", "AZURE", "RSA");

// Retrieves the provider encryption key from the registered IProviderKeyRepository by KeyId
providerEncryptionKey = providerKeyService.GetKeyByKeyIdAsync(providerEncryptionKey.KeyId);
```

### Encrypt and Decrypt

```csharp
// Encryption Factory which has a provider and algorithm implementation for the ProviderEncryptionKey
var rsaEncryptionFactory = new RSAKeyVaultEncryptionFactory();
var encryptionService = new EncryptionService(new List<IEncryptionFactory> { 
  rsaEncryptionFactory 
});

// Provider Encryption Key which was generated from the ProviderKeyService
var providerEncryptionKey = new ProviderEncryptionKey {
  KeyId = Guid.NewGuid().ToString(),
  ProviderKeyId = "https://custom-kms.vault.azure.net/keys/encryption-key/809b10a3cedb83e83bbaeb5e8c762fab",
  Algorithm = "RSA",
  Provider = "AZURE"
};

// Encrypt string to get back a wrapped EncryptedDataResult with a reference to the ProvderEncryptionKey
var encryptedData = encryptionService.Encrypt("My Super Secret", providerEncryptionKey);

// Use Encrypted Data and Provider Encryption Key to decrypt the the value and get back the original plaintext
var plaintext = encryptionService.Decrypt(encryptedData, providerEncryptionKey);
```

## Development

The provided scripts with the SDK will check for all dependencies, start docker, build the solution, and run all tests.

### Dependencies
- [Docker](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://www.docker.com/products/docker-desktop)
- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

### Build the SDK and run Tests

Run the following command from the root of the project:

```sh
make verify
```
