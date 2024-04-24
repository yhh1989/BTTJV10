
using System.Threading.Tasks;

namespace HealthExaminationSystem.Data;

public interface IHesDbSchemaMigrator
{
    Task MigrateAsync();
}
