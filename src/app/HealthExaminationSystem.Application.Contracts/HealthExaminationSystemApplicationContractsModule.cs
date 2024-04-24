using System.Reflection;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using HealthExaminationSystem.Core.Shared;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace HealthExaminationSystem.Application.Contracts;

[DependsOn(
    //ABP
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    //Hes
    typeof(HealthExaminationSystemCoreSharedModule)
)]
public class HealthExaminationSystemApplicationContractsModule : AbpModule
{

}