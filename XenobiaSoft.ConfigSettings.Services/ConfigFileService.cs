using System.Collections.Generic;
using System.IO;
using System.Linq;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class ConfigFileService : IFileService
	{
		public List<ConfigFile> GetConfigFiles(string rootPath)
		{
			var directoryInfo = GetDirectoryInfo(rootPath);

			return directoryInfo
				.GetDirectories("*", SearchOption.TopDirectoryOnly)
				.SelectMany(x => x.GetFiles("*.config")
					.Where(y => y.Name.StartsWith("web.") || y.Name.StartsWith("app.")))
				.Select(x => new ConfigFile(x.FullName, x.Name, x.Directory?.Name))
				.ToList();
		}

		public ConfigFile GetSharedAppSettings(string rootPath)
		{
			const string sharedAppSettingsFileName = "SharedAppSettings.Config";
			const string sharedAppSettingsFolderName = "Configs";

			var directoryInfo = GetDirectoryInfo(rootPath);

			return directoryInfo
				.GetDirectories(sharedAppSettingsFolderName, SearchOption.TopDirectoryOnly)
				.FirstOrDefault()
				?.GetFiles(sharedAppSettingsFileName)
				.Select(x => new ConfigFile(x.FullName, x.Name, x.Directory?.Name))
				.FirstOrDefault();
		}

		private DirectoryInfo GetDirectoryInfo(string rootPath)
		{
			return new DirectoryInfo(rootPath);
		}
	}
}