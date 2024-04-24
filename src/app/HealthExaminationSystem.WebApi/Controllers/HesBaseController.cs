
using HealthExaminationSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HealthExaminationSystem.Controllers;

public abstract class HesBaseController : AbpControllerBase
{
    protected HesBaseController()
    {
        LocalizationResource = typeof(HealthExaminationSystemResource);
    }
}