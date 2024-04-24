using System.Collections.Generic;
using System.Threading.Tasks;
using HealthExaminationSystem.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.TenantManagement;

namespace HealthExaminationSystem.Web.Pages;

public class RedisTestModel : HealthExaminationSystemPageModel
{
    private readonly IRedisTestService redisTestService;

    public List<TenantDto> Tenants { get; set; }

    public RedisTestModel(IRedisTestService redisTestService)
    {
        this.redisTestService = redisTestService;

        Tenants = new List<TenantDto>();
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var tenants =  await redisTestService.GetTenantsAsync();
        Tenants = tenants;
        return Page();
    }
}
