using HealthExaminationSystem.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HealthExaminationSystem.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class HealthExaminationSystemPageModel : AbpPageModel
{
    protected HealthExaminationSystemPageModel()
    {
        LocalizationResourceType = typeof(HealthExaminationSystemResource);
    }
}
