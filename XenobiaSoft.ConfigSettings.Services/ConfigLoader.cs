using System.Collections.Generic;
using System.Linq;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class ConfigLoader : IConfigLoader
	{
		private readonly IProjectConfigurationParser _projectConfigParser;
		private readonly IAppSettingsParser _appSettingsParser;
		private readonly IFileService _fileService;

		public ConfigLoader(IProjectConfigurationParser projectConfigParser, IAppSettingsParser appSettingsParser, IFileService fileService)
		{
			_fileService = fileService;
			_appSettingsParser = appSettingsParser;
			_projectConfigParser = projectConfigParser;
		}

		public List<ProjectEnvironmentConfiguration> LoadConfigs(string rootPath)
		{
			var configFiles = _fileService.GetConfigFiles(rootPath);
			var projectConfigurations = configFiles
				.Select(_projectConfigParser.Parse)
				.Where(x => x != null)
				.ToList();

			return projectConfigurations;
		}

		public List<AppSetting> LoadSharedAppSettings(string rootPath)
		{
			return _appSettingsParser.Parse(_fileService.GetSharedAppSettings(rootPath));
		}
	}
}