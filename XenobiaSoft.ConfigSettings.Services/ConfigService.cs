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
		private readonly IConfigLoader _configLoader;
		private readonly IProjectEnvironmentConfigConverter _projectEnvironmentConfigConverter;
		private readonly ISharedAppSettingConverter _sharedAppSettingsConverter;
		private readonly IUnitOfWork _unitOfWork;

		public ConfigService(IConfigLoader configLoader, 
			IProjectEnvironmentConfigConverter projectEnvironmentConfigConverter,
			IUnitOfWork unitOfWork,
			ISharedAppSettingConverter sharedAppSettingsConverter)
		{
			_unitOfWork = unitOfWork;
			_sharedAppSettingsConverter = sharedAppSettingsConverter;
			_projectEnvironmentConfigConverter = projectEnvironmentConfigConverter;
			_configLoader = configLoader;
		}

		public void ClearDb()
		{
			_unitOfWork.AppSettings.RemoveAll();
			_unitOfWork.Environments.RemoveAll();
			_unitOfWork.Projects.RemoveAll();
			_unitOfWork.ProjectEnvironmentConfigs.RemoveAll();
			_unitOfWork.SharedAppSettings.RemoveAll();
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

			_unitOfWork.Commit();
		}

		private List<ProjectEnvironmentConfig> LoadProjectConfigs(string rootPath)
		{
			var projectConfigs = _configLoader.LoadConfigs(rootPath);
			var projectEnvironmentConfigs = projectConfigs
				.Select(_projectEnvironmentConfigConverter.Convert)
				.ToList();

			return projectEnvironmentConfigs;
		}

		private void SaveProjects(List<Project> projects)
		{
			projects.ForEach(_unitOfWork.Projects.Add);
		}

		private void SaveEnvironments(List<Environment> environments)
		{
			environments.ForEach(_unitOfWork.Environments.Add);
		}

		private void SaveAppSettings(List<AppSetting> appSettings)
		{
			appSettings.ForEach(_unitOfWork.AppSettings.Add);
		}

		private void SaveProjectEnvironmentConfigs(List<ProjectEnvironmentConfig> projectEnvironmentConfigs)
		{
			projectEnvironmentConfigs.ForEach(_unitOfWork.ProjectEnvironmentConfigs.Add);
		}

		private List<SharedAppSetting> LoadSharedAppSettings(string rootPath)
		{
			var sharedAppSettingModels = _configLoader.LoadSharedAppSettings(rootPath);
			var sharedAppSettings = sharedAppSettingModels
				.Select(_sharedAppSettingsConverter.Convert)
				.ToList();

			return sharedAppSettings;
		}

		private void SaveSharedAppSettings(List<SharedAppSetting> sharedAppSettings)
		{
			sharedAppSettings.ForEach(_unitOfWork.SharedAppSettings.Add);
		}
	}
}