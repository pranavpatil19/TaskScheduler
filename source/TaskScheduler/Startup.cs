using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TaskScheduler
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseException();
            application.UseCorsAllowAny();
            application.UseHttps();
            application.UseRouting();
            application.UseStaticFiles();
            application.UseEndpoints();
            application.UseHangfire();
            application.UseHangfireExamples();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddResponseCompression();
            services.AddResponseCaching();
            services.AddControllersDefault();
            services.AddHangFire();
        }
    }
}