using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Data.Builders
{
	public class BuilderFactory : IBuilderFactory
	{
		public Interfaces.Builder.AppSettings.IKeyHolder AppSettingBuilder()
		{
			return Builders.AppSettingBuilder.CreateNew();
		}

		public Interfaces.Builder.AppSettings.IKeyHolder AppSettingBuilder(int id)
		{
			return Builders.AppSettingBuilder.CreateExisting(id);
		}

		public Interfaces.Builder.SharedAppSettings.IKeyHolder SharedAppSettingsBuilder()
		{
			return SharedAppSettingBuilder.CreateNew();
		}

		public Interfaces.Builder.SharedAppSettings.IKeyHolder SharedAppSettingsBuilder(int id)
		{
			return SharedAppSettingBuilder.CreateExisting(id);
		}

		public IConfigPathHolder ProjectEnvironmentConfigBuilder()
		{
			return Builders.ProjectEnvironmentConfigBuilder.CreateNew();
		}
	}
}