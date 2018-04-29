using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Data.Interfaces.Builder
{
	public interface IBuilderFactory
	{
		AppSettings.IKeyHolder AppSettingBuilder(int id);
		AppSettings.IKeyHolder AppSettingBuilder();
		IConfigPathHolder ProjectEnvironmentConfigBuilder();
		SharedAppSettings.IKeyHolder SharedAppSettingsBuilder();
		SharedAppSettings.IKeyHolder SharedAppSettingsBuilder(int id);
	}
}