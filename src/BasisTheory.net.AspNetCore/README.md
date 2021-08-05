# Basis Theory .NET AspNetCore Extensions

## Setup

### Setup the Encryption and Key Provider Services

***Note: An instance of `IProviderKeyRepository` is required to register Basis Theory's key provider***

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services
        .AddScoped<IProviderKeyRepository>(new ProviderKeyRepositoryImpl())
        .AddBasisTheoryEncryption()
    ...
```

### Configure the exception filter

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services
        ...
        .AddScoped<BasisTheoryExceptionFilter>();
        .AddControllers(o =>
        {
            options.Filters.Add<BasisTheoryExceptionFilter>();
        })
        ...
```
