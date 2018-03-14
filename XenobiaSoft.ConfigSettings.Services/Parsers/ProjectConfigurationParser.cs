using System.IO;
using System.Linq;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Parsers
{
	public class ProjectConfigurationParser : IProjectConfigurationParser
	{
		private readonly IAppSettingsParser _AppSettingsParser;

		public ProjectConfigurationParser(IAppSettingsParser appSettingsParser)
		{
			_AppSettingsParser = appSettingsParser;
		}

		public ProjectEnvironmentConfiguration Parse(ConfigFile configFile)
		{
			var appSettings = _AppSettingsParser.Parse(configFile);

			if (!appSettings.Any())
			{
				return null;
			}

			return new ProjectEnvironmentConfiguration
			{
				ProjectName = configFile.DirectoryName,
				EnvironmentName = Utility.GetEnvironmentName(configFile.FileName),
				ConfigPath = configFile.FilePath,
				AppSettings = appSettings
			};
		}
	}
}