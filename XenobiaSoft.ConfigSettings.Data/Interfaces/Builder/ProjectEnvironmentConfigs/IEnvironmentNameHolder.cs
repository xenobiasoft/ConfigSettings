namespace XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs
{
	public interface IEnvironmentNameHolder
	{
		IAppSettingHolder WithEnvironmentName(string environmentName);
	}
}