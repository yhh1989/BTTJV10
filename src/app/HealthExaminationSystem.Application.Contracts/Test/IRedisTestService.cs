

using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.TenantManagement;

namespace HealthExaminationSystem.Application.Contracts;

public interface IRedisTestService
{
    Task<List<TenantDto>> GetTenantsAsync();
}