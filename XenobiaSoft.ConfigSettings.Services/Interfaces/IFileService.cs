using System.Collections.Generic;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces
{
	public interface IFileService
	{
		List<ConfigFile> GetConfigFiles(string rootPath);
		ConfigFile GetSharedAppSettings(string rootPath);
	}
}