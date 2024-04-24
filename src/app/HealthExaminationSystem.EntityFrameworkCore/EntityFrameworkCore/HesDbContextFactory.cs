
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HealthExaminationSystem.EntityFrameworkCore;

public class HesDbContextFactory :IDesignTimeDbContextFactory<HesDbContext>
{
    public HesDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<HesDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new HesDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../HealthExaminationSystem.Web.Host/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}