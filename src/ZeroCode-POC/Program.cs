using BasisTheory.net.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddBasisTheoryEncryption(builder.Configuration.GetSection("BasisTheory"));

var app = builder.Build();

app.MapControllers();

app.Run();
