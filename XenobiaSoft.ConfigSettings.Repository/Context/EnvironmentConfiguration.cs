using System.Data.Entity.ModelConfiguration;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Repository.Context
{
	public class EnvironmentConfiguration : EntityTypeConfiguration<Environment>
	{
		public EnvironmentConfiguration()
		{
			HasMany(x => x.ProjectEnvironmentConfigs)
				.WithRequired(x => x.Environment);

			Property(x => x.EnvironmentName)
				.HasMaxLength(500)
				.IsRequired();
		}
	}
}