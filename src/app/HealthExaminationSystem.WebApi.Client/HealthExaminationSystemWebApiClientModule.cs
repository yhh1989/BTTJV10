
using HealthExaminationSystem.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Http.Client;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace HealthExaminationSystem.WebApi.Client;

[DependsOn(
    //ABP
    typeof(AbpHttpClientModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    //Hes
    typeof(HealthExaminationSystemWebApiModule)
)]
public class HealthExaminationSystemWebApiClientModule : AbpModule
{
    //远程服务名称
    public const string RemoteServiceName = "Hes";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(HealthExaminationSystemWebApiModule).Assembly,
            RemoteServiceName
        );
        context.Services.AddHttpClientProxies(
            typeof(HealthExaminationSystemApplicationContractsModule).Assembly,
            RemoteServiceName
        );
    }
}