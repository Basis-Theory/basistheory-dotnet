using BasisTheory.net.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BasisTheory.net.AcceptanceTests.Encryption.Helpers
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) =>
            services.AddBasisTheoryEncryption()
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app.UseRouting()
                .UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
