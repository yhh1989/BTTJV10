using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace HealthExaminationSystem.Web.Host;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        #region Serilog日志
        Log.Logger = new LoggerConfiguration()
        #if DEBUG
            .MinimumLevel.Debug()
        #else
            .MinimumLevel.Information()
        #endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();
        #endregion
        
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();

            await builder.AddApplicationAsync<AppModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();

            Log.Information("启动 HealthExaminationSystem.Web.Host 项目...");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "HealthExaminationSystem.Web.Host 意外终止!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }

        // var builder = WebApplication.CreateBuilder(args);

        // // Add services to the container.
        // builder.Services.AddRazorPages();

        // var app = builder.Build();

        // // Configure the HTTP request pipeline.
        // if (!app.Environment.IsDevelopment())
        // {
        //     app.UseExceptionHandler("/Error");
        //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //     app.UseHsts();
        // }

        // app.UseHttpsRedirection();
        // app.UseStaticFiles();

        // app.UseRouting();

        // app.UseAuthorization();

        // app.MapRazorPages();

        // app.Run();
    }
}
