using System.Collections.Generic;
using System.Linq;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class ConfigLoader : IConfigLoader
	{
		private const string SharedAppSettingsFileName = "SharedAppSettings.Config";
		private const string SharedAppSettingsFolderName = "Configs";
		private readonly IProjectConfigurationParser _ProjectConfigParser;
		private readonly IAppSettingsParser _AppSettingsParser;
		private readonly IFileService _FileService;

		public ConfigLoader(IProjectConfigurationParser projectConfigParser, IAppSettingsParser appSettingsParser, IFileService fileService)
		{
			_FileService = fileService;
			_AppSettingsParser = appSettingsParser;
			_ProjectConfigParser = projectConfigParser;
		}

		public List<ProjectEnvironmentConfiguration> LoadConfigs(string rootPath)
		{
			var configFiles = _FileService.GetConfigFiles(rootPath);
			var projectConfigurations = configFiles
				.Select(_ProjectConfigParser.Parse)
				.Where(x => x != null)
				.ToList();

			return projectConfigurations;
		}

		public List<AppSettingModel> LoadSharedAppSettings(string rootPath)
		{
			return _AppSettingsParser.Parse(_FileService.GetSharedAppSettings(rootPath));
		}
	}
}