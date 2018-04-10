using System.Data.Entity.ModelConfiguration;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Context
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