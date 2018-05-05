using System.Collections.Generic;
using XenobiaSoft.ConfigSettings.Data.Interfaces;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class ConfigService : IConfigService
	{
		private readonly IConfigLoader _configLoader;
		private readonly IRepositoryFactory _repositoryFactory;

		public ConfigService(IConfigLoader configLoader, 
			IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
			_configLoader = configLoader;
		}

		public void LoadConfigurations(string rootPath)
		{
			var projectEnvironmentConfigs = _configLoader.LoadConfigs(rootPath);
			SaveProjectEnvironmentConfigs(projectEnvironmentConfigs);

			var sharedAppSettings = _configLoader.LoadSharedAppSettings(rootPath);
			SaveSharedAppSettings(sharedAppSettings);
		}

		public void ClearDb()
		{
			_repositoryFactory
				.CreateWrite<ProjectEnvironmentConfiguration, int>()
				.RemoveAll();
			_repositoryFactory
				.CreateWrite<AppSetting, int>()
				.RemoveAll();
		}

		private void SaveProjectEnvironmentConfigs(List<ProjectEnvironmentConfiguration> projectEnvironmentConfigs)
		{
			var repository = _repositoryFactory.CreateWrite<ProjectEnvironmentConfiguration, int>();

			projectEnvironmentConfigs.ForEach(repository.Add);
		}

		private void SaveSharedAppSettings(List<AppSetting> sharedAppSettings)
		{
			var repository = _repositoryFactory.CreateWrite<AppSetting, int>();

			sharedAppSettings.ForEach(repository.Add);
		}
	}
}