
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace HealthExaminationSystem.WebApi.Host;

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
            Log.Information("启动 HealthExaminationSystem.WebApi.Host 项目...");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();

            await builder.AddApplicationAsync<AppModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "HealthExaminationSystem.WebApi.Host 意外终止!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }

        // var builder = WebApplication.CreateBuilder(args);

        // // Add services to the container.
        // builder.Services.AddAuthorization();

        // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen();

        // var app = builder.Build();

        // // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseSwagger();
        //     app.UseSwaggerUI();
        // }

        // app.UseHttpsRedirection();

        // app.UseAuthorization();

        // var summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        // {
        //     var forecast =  Enumerable.Range(1, 5).Select(index =>
        //         new WeatherForecast
        //         {
        //             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //             TemperatureC = Random.Shared.Next(-20, 55),
        //             Summary = summaries[Random.Shared.Next(summaries.Length)]
        //         })
        //         .ToArray();
        //     return forecast;
        // })
        // .WithName("GetWeatherForecast")
        // .WithOpenApi();

        // app.Run();
    }
}
