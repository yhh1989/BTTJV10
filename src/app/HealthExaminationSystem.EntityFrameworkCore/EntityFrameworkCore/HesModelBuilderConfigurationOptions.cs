
using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace HealthExaminationSystem.EntityFrameworkCore;

public class HesModelBuilderConfigurationOptions
    : AbpModelBuilderConfigurationOptions
{
    public HesModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
    {

    }
}