# Basis Theory .NET AspNetCore Extensions

## Setup

### Setup the Encryption and Key Provider Services

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services.AddBasisTheoryEncryption()
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
