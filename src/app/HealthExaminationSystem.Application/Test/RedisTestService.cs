using System;
using System.Collections.Generic;
using System.Net.Http.Headers;


using System.Threading.Tasks;
using HealthExaminationSystem.Application.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.TenantManagement;

namespace HealthExaminationSystem.Application;

public class RedisTestService : ApplicationService, IRedisTestService
{
    private readonly IDistributedCache<List<TenantDto>> cache;
    
    public RedisTestService(
        IDistributedCache<List<TenantDto>> cache)
    {
        this.cache = cache;
    }

    public async Task<List<TenantDto>> GetTenantsAsync()
    {
        return await cache.GetOrAddAsync(
                "Hes_Tenants_Random", //Cache key
                async () => await GetTenantsByRepositoryAsync(),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }
            );
    }

    private async Task<List<TenantDto>> GetTenantsByRepositoryAsync()
    {
        return new List<TenantDto>()
        {
            new TenantDto(){ Id = Guid.NewGuid(), Name = "租户1"},
            new TenantDto(){Id = Guid.NewGuid(), Name = "租户2"},
        };
    }
}