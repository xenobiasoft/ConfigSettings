using System.Collections.Generic;
using System.IO;
using System.Linq;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class ConfigFileService : IFileService
	{
		private const string SharedAppSettingsFileName = "SharedAppSettings.Config";
		private const string SharedAppSettingsFolderName = "Configs";

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
			var directoryInfo = GetDirectoryInfo(rootPath);

			return directoryInfo
				.GetDirectories(SharedAppSettingsFolderName, SearchOption.TopDirectoryOnly)
				.FirstOrDefault()
				?.GetFiles(SharedAppSettingsFileName)
				.Select(x => new ConfigFile(x.FullName, x.Name, x.Directory?.Name))
				.FirstOrDefault();
		}

		private DirectoryInfo GetDirectoryInfo(string rootPath)
		{
			return new DirectoryInfo(rootPath);
		}
	}
}