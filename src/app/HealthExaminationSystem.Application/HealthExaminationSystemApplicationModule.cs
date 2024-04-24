

using HealthExaminationSystem.Application.Contracts;
using HealthExaminationSystem.Core;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Caching.StackExchangeRedis;

namespace HealthExaminationSystem.Application;

[DependsOn(
    //ABP
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpCachingStackExchangeRedisModule),
    //Account
    typeof(AbpAccountApplicationModule),
    //Identity
    typeof(AbpIdentityApplicationModule),
    //PermissionManagement
    typeof(AbpPermissionManagementApplicationModule),
    //TenantManagement
    typeof(AbpTenantManagementApplicationModule),
    //Hes
    typeof(HealthExaminationSystemApplicationContractsModule),
    typeof(HealthExaminationSystemCoreModule)
)]
public class HealthExaminationSystemApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //注册 IObjectMapper 服务
        context.Services.AddAutoMapperObjectMapper<HealthExaminationSystemApplicationModule>();
        //配置：添加模块所在程序中定义的 Profile ，并启用验证
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<HealthExaminationSystemApplicationModule>(validate: true);
        });
    }
}