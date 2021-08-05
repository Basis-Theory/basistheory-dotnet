# Basis Theory .NET Azure Encryption AspNetCore Extensions

## Setup

### Setup Azure Encryption with KeyVaultProviderKeyOptions

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services.AddBasisTheoryAzureEncryption(new KeyVaultProviderKeyOptions {
        RsaKeySize = 2048,
        KeyProviderExpirationInDays = 90,
        KeyVaultUri = new Uri("https://tenant.vault.azure.com")
    })
    ...
```

### Setup Azure Encryption with Options Builder

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services.AddBasisTheoryAzureEncryption(options => {
      options.RsaKeySize = 2048;
      options.KeyProviderExpirationInDays = 90;
      options.KeyVaultUri = new Uri("https://tenant.vault.azure.com")
    })
    ...
```

### Setup Azure Encryption with custom TokenCredential

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services.AddBasisTheoryAzureEncryption(tokenCredential: new DefaultAzureCredential())
    ...
```