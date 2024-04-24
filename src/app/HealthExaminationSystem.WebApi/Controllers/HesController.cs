
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthExaminationSystem.Controllers;
using HealthExaminationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.Data;

[ControllerName("Hes")]
[Route("/api/hes")]
public class HesController : HesBaseController
{
    private readonly IEnumerable<IHesDbSchemaMigrator> hesDbSchemaMigrators;
    private readonly IDataSeeder dataSeeder;

    public HesController(IEnumerable<IHesDbSchemaMigrator> hesDbSchemaMigrators,
        IDataSeeder dataSeeder)
    {
        this.hesDbSchemaMigrators = hesDbSchemaMigrators;
        this.dataSeeder = dataSeeder;
    }

    [HttpGet]
    [Route("inital")]
    public virtual async Task<ActionResult> Inital()
    {
        foreach (var migrator in hesDbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }

        await dataSeeder.SeedAsync(new DataSeedContext()
            .WithProperty(/*IdentityDataSeedContributor.AdminEmailPropertyName*/"AdminEmail", /*IdentityDataSeedContributor.AdminEmailDefaultValue*/"admin@abp.io")
            .WithProperty(/*IdentityDataSeedContributor.AdminPasswordPropertyName*/"AdminPassword", /*IdentityDataSeedContributor.AdminPasswordDefaultValue*/"1q2w3E*")
        );

        return Content("Hes Inital Success!");
    }

    // private async Task SeedDataAsync(Tenant? tenant = null)
    // {
    //     Logger.LogInformation($"Executing {(tenant == null ? "host" : tenant.Name + " tenant")} database seed...");

    //     await _dataSeeder.SeedAsync(new DataSeedContext(tenant?.Id)
    //         .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, IdentityDataSeedContributor.AdminEmailDefaultValue)
    //         .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, IdentityDataSeedContributor.AdminPasswordDefaultValue)
    //     );
    // }
}