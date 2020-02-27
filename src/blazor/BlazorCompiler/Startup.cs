using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

using BlazorCompiler.Services.Concretes;
using BlazorCompiler.Services.Interfaces;

namespace BlazorCompiler
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMonacoService, MonacoService>();
            services.AddScoped<ICompilerService, CompilerCSharpService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("bz-compiler");
        }
    }
}