using System.Collections.Generic;
using XenobiaSoft.ConfigSettings.Data.V2.Models;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces
{
	public interface IConfigLoader
	{
		List<ProjectEnvironmentConfiguration> LoadConfigs(string rootPath);
		List<AppSetting> LoadSharedAppSettings(string rootPath);
	}
}