using System;
using System.Collections.Generic;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Builders
{
	public class ProjectEnvironmentConfigBuilder : IProjectEnvironmentConfigBuilder, IConfigPathHolder, IProjectNameHolder, IEnvironmentNameHolder, IAppSettingHolder
	{
		private ProjectEnvironmentConfigBuilder()
		{
			AppSettings = new List<AppSetting>();
		}

		public static IConfigPathHolder CreateNew()
		{
			return new ProjectEnvironmentConfigBuilder();
		}

		public static IConfigPathHolder CreateExisting(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException($"{nameof(Id)} must be greater than 0.");
			}

			return new ProjectEnvironmentConfigBuilder
			{
				Id = id
			};
		}

		public IProjectNameHolder WithConfigPath(string configPath)
		{
			if (string.IsNullOrEmpty(configPath))
			{
				throw new ArgumentNullException(nameof(configPath));
			}

			return new ProjectEnvironmentConfigBuilder
			{
				Id = Id,
				ConfigPath = configPath
			};
		}

		public IEnvironmentNameHolder WithProjectName(string projectName)
		{
			if (string.IsNullOrEmpty(projectName))
			{
				throw new ArgumentNullException(nameof(projectName));
			}

			return new ProjectEnvironmentConfigBuilder
			{
				Id = Id,
				ConfigPath = ConfigPath,
				ProjectName = projectName
			};
		}

		public IAppSettingHolder WithEnvironmentName(string environmentName)
		{
			if (string.IsNullOrEmpty(environmentName))
			{
				throw new ArgumentNullException(nameof(environmentName));
			}

			return new ProjectEnvironmentConfigBuilder
			{
				Id = Id,
				ConfigPath = ConfigPath,
				ProjectName = ProjectName,
				EnvironmentName = environmentName
			};
		}

		public IAppSettingHolder Add(AppSetting appSetting)
		{
			if (appSetting == null)
			{
				throw new ArgumentNullException(nameof(appSetting));
			}

			return new ProjectEnvironmentConfigBuilder
			{
				Id = Id,
				ConfigPath = ConfigPath,
				ProjectName = ProjectName,
				EnvironmentName = EnvironmentName,
				AppSettings = new List<AppSetting>(AppSettings) { appSetting }
			};
		}

		public IProjectEnvironmentConfigBuilder Done()
		{
			if (AppSettings.Count == 0)
			{
				throw new ApplicationException("At least 1 AppSetting is required.");
			}

			return this;
		}

		public ProjectEnvironmentConfiguration Build()
		{
			var projectEnvironmentConfig = new ProjectEnvironmentConfiguration
			{
				Id = Id,
				ConfigPath = ConfigPath,
				ProjectName = ProjectName,
				EnvironmentName = EnvironmentName,
				AppSettings = new List<AppSetting>(),
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			};

			return projectEnvironmentConfig;
		}

		public int Id { get; private set; }

		public string ConfigPath { get; private set; }

		public string ProjectName { get; private set; }

		public string EnvironmentName { get; private set; }

		public List<AppSetting> AppSettings { get; private set; }
	}
}