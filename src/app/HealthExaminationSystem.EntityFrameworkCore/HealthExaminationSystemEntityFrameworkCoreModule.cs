
using HealthExaminationSystem.Core;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace HealthExaminationSystem.EntityFrameworkCore;

[DependsOn(
    //Hes
    typeof(HealthExaminationSystemCoreModule),
    //ABP
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule)
)]
public class HealthExaminationSystemEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<HesDbContext>(options =>
        {
            //注册实体默认仓储
            options.AddDefaultRepositories(true);
        });

        //配置使用SqlServer数据库
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });
    }
}