using System;
using System.Collections.Generic;
using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;
using Environment = XenobiaSoft.ConfigSettings.Repository.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Services.Builders
{
	public class ProjectEnvironmentConfigBuilder : IProjectEnvironmentConfigBuilder, IConfigPathHolder, IProjectHolder, IEnvironmentHolder, IAppSettingHolder
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

		public IProjectHolder WithConfigPath(string configPath)
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

		public IEnvironmentHolder WithProject(Project project)
		{
			if (project == null)
			{
				throw new ArgumentNullException(nameof(project));
			}

			return new ProjectEnvironmentConfigBuilder
			{
				Id = Id,
				ConfigPath = ConfigPath,
				Project = project
			};
		}

		public IAppSettingHolder WithEnvironment(Environment environment)
		{
			if (environment == null)
			{
				throw new ArgumentNullException(nameof(environment));
			}

			return new ProjectEnvironmentConfigBuilder
			{
				Id = Id,
				ConfigPath = ConfigPath,
				Project = Project,
				Environment = environment
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
				Project = Project,
				Environment = Environment,
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

		public ProjectEnvironmentConfig Build()
		{
			var projectEnvironmentConfig = new ProjectEnvironmentConfig
			{
				Id = Id,
				ConfigPath = ConfigPath,
				Project = Project,
				Environment = Environment,
				AppSettings = new List<AppSetting>(),
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			};

			AppSettings.ForEach(x =>
			{
				x.ProjectEnvironmentConfig = projectEnvironmentConfig;
				projectEnvironmentConfig.AppSettings.Add(x);
			});

			return projectEnvironmentConfig;
		}

		public int Id { get; private set; }
		public string ConfigPath { get; private set; }
		public Project Project { get; private set; }
		public Environment Environment { get; private set; }
		public List<AppSetting> AppSettings { get; private set; }
	}
}