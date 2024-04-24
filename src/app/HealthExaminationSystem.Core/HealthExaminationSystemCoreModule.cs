using HealthExaminationSystem.Core.Shared;
using HealthExaminationSystem.MultiTenancy;
using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.TenantManagement;

namespace HealthExaminationSystem.Core;

[DependsOn(
    //ABP
    typeof(AbpDddDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpOpenIddictDomainModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpTenantManagementDomainModule),
    //Hes
    typeof(HealthExaminationSystemCoreSharedModule)
)]
public class HealthExaminationSystemCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Configure<AbpLocalizationOptions>(options =>
        // {
        //     options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
        // });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });
    }
}