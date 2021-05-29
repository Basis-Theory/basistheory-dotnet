# Basis Theory .NET AspNetCore Extensions

## Configure the exception filter

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
