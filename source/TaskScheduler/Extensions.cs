using DotNetCore.IoC;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskScheduler
{
    public static class Extensions
    {
        public static void AddHangFire(this IServiceCollection services)
        {
            var connectionString = services.GetConnectionString(nameof(TaskScheduler));
            services.AddHangfire(configuration => configuration.UseSqlServerStorage(connectionString));
            services.AddHangfireServer();
        }

        public static void UseHangfire(this IApplicationBuilder application)
        {
            application.UseHangfireDashboard();
        }

        public static void UseHangfireExamples(this IApplicationBuilder application)
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Executed only once and almost immediately after creation."));
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Executed every minute."), Cron.Minutely);
        }
    }
}