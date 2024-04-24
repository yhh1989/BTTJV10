
using System;
using System.Threading.Tasks;
using HealthExaminationSystem.Data;
using HealthExaminationSystem.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

public class EntityFrameworkCoreHesDbSchemaMigrator : IHesDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHesDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        await _serviceProvider
            .GetRequiredService<HesDbContext>()
            .Database
            .MigrateAsync();
    }
}