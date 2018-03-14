using System.Data.Entity.ModelConfiguration;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Repository.Context
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