using System.Collections.Generic;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces
{
	public interface IConfigLoader
	{
		List<ProjectEnvironmentConfiguration> LoadConfigs(string rootPath);
		List<AppSettingModel> LoadSharedAppSettings(string rootPath);
	}
}