using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HealthExaminationSystem.Data;

public class NullHesDbSchemaMigrator : IHesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
