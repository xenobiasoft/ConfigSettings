using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Converters
{
	public class ProjectEnvironmentConfigConverter : IProjectEnvironmentConfigConverter
	{
		private readonly IBuilderFactory _builderFactory;
		private readonly ICache _cache;

		public ProjectEnvironmentConfigConverter(IBuilderFactory builderFactory, ICache cache)
		{
			_cache = cache;
			_builderFactory = builderFactory;
		}

		public ProjectEnvironmentConfig Convert(ProjectEnvironmentConfiguration projectConfiguration)
		{
			var project = GetProject(projectConfiguration.ProjectName);

			var environment = GetEnvironment(projectConfiguration.EnvironmentName);

			var appSettingHolder = _builderFactory
				.ProjectEnvironmentConfigBuilder()
				.WithConfigPath(projectConfiguration.ConfigPath)
				.WithProject(project)
				.WithEnvironment(environment);

			projectConfiguration.AppSettings.ForEach(x =>
			{
				appSettingHolder = appSettingHolder.Add(_builderFactory
					.AppSettingBuilder()
					.WithKey(x.Key)
					.WithValue(x.Value)
					.WithTransformType(x.TransformType)
					.Build());
			});

			return appSettingHolder.Done().Build();
		}

		private Project GetProject(string projectName)
		{
			Project project;

			if (_cache.Exists<Project>(projectName))
			{
				project = _cache.Get<Project>(projectName);
			}
			else
			{
				project = _builderFactory
					.ProjectBuilder()
					.WithName(projectName)
					.Build();
				_cache.Add(projectName, project);
			}

			return project;
		}

		private Environment GetEnvironment(string environmentName)
		{
			Environment environment = null;

			if (_cache.Exists<Environment>(environmentName))
			{
				environment = _cache.Get<Environment>(environmentName);
			}
			else
			{
				environment = _builderFactory
					.EnvironmentBuilder()
					.WithName(environmentName)
					.Build();
				_cache.Add(environmentName, environment);
			}

			return environment;
		}
	}
}