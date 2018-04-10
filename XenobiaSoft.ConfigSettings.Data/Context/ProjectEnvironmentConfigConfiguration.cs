using System.Data.Entity.ModelConfiguration;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Context
{
	public class ProjectEnvironmentConfigConfiguration : EntityTypeConfiguration<ProjectEnvironmentConfig>
	{
		public ProjectEnvironmentConfigConfiguration()
		{
			HasMany(x => x.AppSettings)
				.WithRequired(x => x.ProjectEnvironmentConfig);
			HasRequired(x => x.Environment)
				.WithMany(x => x.ProjectEnvironmentConfigs);
			HasRequired(x => x.Project)
				.WithMany(x => x.ProjectEnvironmentConfigs);

			Property(x => x.ConfigPath)
				.HasMaxLength(1000)
				.IsRequired();
		}
	}
}