using System.Data.Entity.ModelConfiguration;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Repository.Context
{
	public class SharedAppSettingConfiguration : EntityTypeConfiguration<SharedAppSetting>
	{
		public SharedAppSettingConfiguration()
		{
			Property(x => x.Key)
				.HasMaxLength(200)
				.IsRequired();

			Property(x => x.Value)
				.HasMaxLength(500)
				.IsRequired();
		}
	}
}