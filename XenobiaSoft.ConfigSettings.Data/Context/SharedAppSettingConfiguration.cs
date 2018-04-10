using System.Data.Entity.ModelConfiguration;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Context
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