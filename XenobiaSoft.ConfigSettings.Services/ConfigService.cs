using System.Collections.Generic;
using System.Linq;
using XenobiaSoft.ConfigSettings.Repository.Interfaces;
using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class ConfigService : IConfigService
	{
		private readonly IConfigLoader _ConfigLoader;
		private readonly IProjectEnvironmentConfigConverter _ProjectEnvironmentConfigConverter;
		private readonly ISharedAppSettingConverter _SharedAppSettingsConverter;
		private readonly IUnitOfWork _UnitOfWork;

		public ConfigService(IConfigLoader configLoader, 
			IProjectEnvironmentConfigConverter projectEnvironmentConfigConverter,
			IUnitOfWork unitOfWork,
			ISharedAppSettingConverter sharedAppSettingsConverter)
		{
			_UnitOfWork = unitOfWork;
			_SharedAppSettingsConverter = sharedAppSettingsConverter;
			_ProjectEnvironmentConfigConverter = projectEnvironmentConfigConverter;
			_ConfigLoader = configLoader;
		}

		public void ClearDb()
		{
			_UnitOfWork.AppSettings.RemoveAll();
			_UnitOfWork.Environments.RemoveAll();
			_UnitOfWork.Projects.RemoveAll();
			_UnitOfWork.ProjectEnvironmentConfigs.RemoveAll();
			_UnitOfWork.SharedAppSettings.RemoveAll();
		}

		public void LoadConfigurations(string rootPath)
		{
			var projectEnvironmentConfigs = LoadProjectConfigs(rootPath);
			var sharedAppSettings = LoadSharedAppSettings(rootPath);

			SaveAll(projectEnvironmentConfigs, sharedAppSettings);
		}

		private void SaveAll(List<ProjectEnvironmentConfig> projectEnvironmentConfigs, List<SharedAppSetting> sharedAppSettings)
		{
			SaveProjects(projectEnvironmentConfigs.Select(x => x.Project).ToList());
			SaveEnvironments(projectEnvironmentConfigs.Select(x => x.Environment).ToList());
			SaveAppSettings(projectEnvironmentConfigs.SelectMany(x => x.AppSettings).ToList());
			SaveProjectEnvironmentConfigs(projectEnvironmentConfigs);
			SaveSharedAppSettings(sharedAppSettings);

			_UnitOfWork.Commit();
		}

		private List<ProjectEnvironmentConfig> LoadProjectConfigs(string rootPath)
		{
			var projectConfigs = _ConfigLoader.LoadConfigs(rootPath);
			var projectEnvironmentConfigs = projectConfigs
				.Select(_ProjectEnvironmentConfigConverter.Convert)
				.ToList();

			return projectEnvironmentConfigs;
		}

		private void SaveProjects(List<Project> projects)
		{
			projects.ForEach(_UnitOfWork.Projects.Add);
		}

		private void SaveEnvironments(List<Environment> environments)
		{
			environments.ForEach(_UnitOfWork.Environments.Add);
		}

		private void SaveAppSettings(List<AppSetting> appSettings)
		{
			appSettings.ForEach(_UnitOfWork.AppSettings.Add);
		}

		private void SaveProjectEnvironmentConfigs(List<ProjectEnvironmentConfig> projectEnvironmentConfigs)
		{
			projectEnvironmentConfigs.ForEach(_UnitOfWork.ProjectEnvironmentConfigs.Add);
		}

		private List<SharedAppSetting> LoadSharedAppSettings(string rootPath)
		{
			var sharedAppSettingModels = _ConfigLoader.LoadSharedAppSettings(rootPath);
			var sharedAppSettings = sharedAppSettingModels
				.Select(_SharedAppSettingsConverter.Convert)
				.ToList();

			return sharedAppSettings;
		}

		private void SaveSharedAppSettings(List<SharedAppSetting> sharedAppSettings)
		{
			sharedAppSettings.ForEach(_UnitOfWork.SharedAppSettings.Add);
		}
	}
}