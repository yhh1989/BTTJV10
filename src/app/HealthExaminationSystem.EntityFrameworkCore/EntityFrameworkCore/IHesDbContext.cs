
using HealthExaminationSystem;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HealthExaminationSystem.EntityFrameworkCore;

[ConnectionStringName(HesDbProperties.ConnectionStringName)]
public interface IHesDbContext : IEfCoreDbContext
{
    //DbSet<Entity> Entities { get; }
}