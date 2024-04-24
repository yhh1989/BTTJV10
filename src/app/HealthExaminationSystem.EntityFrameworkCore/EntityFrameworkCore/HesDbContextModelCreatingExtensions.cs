
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace HealthExaminationSystem.EntityFrameworkCore;

public static class HesDbContextModelCreatingExtensions
{
    public static void ConfigureHes(
            this ModelBuilder builder,
            Action<HesModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HesModelBuilderConfigurationOptions(
                HesDbProperties.DbTablePrefix,
                HesDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* 示例
            builder.Entity<Tree>(b =>
            {
                b.ToTable(options.TablePrefix + "Trees", options.Schema);
                b.ConfigureByConvention();

                b.Property(x => x.Name).IsRequired().HasMaxLength(TreeConsts.NameMaxLength).HasColumnName(nameof(Tree.Name));
                b.Property(x => x.Data)
                    .HasColumnName(nameof(Tree.Data))
                    .HasConversion(
                        v => JsonSerializer.Serialize<JsonTreeItem[]>(v, new JsonSerializerOptions() { IgnoreNullValues = true }),
                        v => JsonSerializer.Deserialize<JsonTreeItem[]>(v, new JsonSerializerOptions() { IgnoreNullValues = true })
                    );
            });
            */
        }
}