using HealthExaminationSystem.Application.Contracts;
using HealthExaminationSystem.Core;
using HealthExaminationSystem.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;

namespace HealthExaminationSystem.WebApi;

[DependsOn(
    //ABP
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(HealthExaminationSystemCoreModule),
    //Hes
    typeof(HealthExaminationSystemApplicationContractsModule)
)]
public class HealthExaminationSystemWebApiModule: AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(HealthExaminationSystemWebApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<HealthExaminationSystemResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}