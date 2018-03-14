using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder
{
	public interface IBuilderFactory
	{
		AppSettings.IKeyHolder AppSettingBuilder(int id);
		AppSettings.IKeyHolder AppSettingBuilder();
		IEnvironmentNameHolder EnvironmentBuilder();
		IEnvironmentNameHolder EnvironmentBuilder(int id);
		IProjectNameHolder ProjectBuilder();
		IProjectNameHolder ProjectBuilder(int id);
		IConfigPathHolder ProjectEnvironmentConfigBuilder();
		SharedAppSettings.IKeyHolder SharedAppSettingsBuilder();
		SharedAppSettings.IKeyHolder SharedAppSettingsBuilder(int id);
	}
}