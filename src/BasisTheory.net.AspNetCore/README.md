# Basis Theory .NET AspNetCore Extensions

In `Startup.cs`

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services
        ...
        .AddControllers(o =>
        {
            o.Filters.Add(new BasisTheoryExceptionFilter()); <-- Add this line
        })
        ...
```
