using System.Data.Entity.ModelConfiguration;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Context
{
	public class ProjectConfiguration : EntityTypeConfiguration<Project>
	{
		public ProjectConfiguration()
		{
			HasMany(x => x.ProjectEnvironmentConfigs)
				.WithRequired(x => x.Project);

			Property(x => x.ProjectName)
				.HasMaxLength(500)
				.IsRequired();
		}
	}
}