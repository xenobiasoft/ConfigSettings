using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Converters
{
	public class ProjectEnvironmentConfigConverter : IProjectEnvironmentConfigConverter
	{
		private readonly IBuilderFactory _BuilderFactory;
		private readonly ICache _Cache;

		public ProjectEnvironmentConfigConverter(IBuilderFactory builderFactory, ICache cache)
		{
			_Cache = cache;
			_BuilderFactory = builderFactory;
		}

		public ProjectEnvironmentConfig Convert(ProjectEnvironmentConfiguration projectConfiguration)
		{
			var project = GetProject(projectConfiguration.ProjectName);

			var environment = GetEnvironment(projectConfiguration.EnvironmentName);

			var appSettingHolder = _BuilderFactory
				.ProjectEnvironmentConfigBuilder()
				.WithConfigPath(projectConfiguration.ConfigPath)
				.WithProject(project)
				.WithEnvironment(environment);

			projectConfiguration.AppSettings.ForEach(x =>
			{
				appSettingHolder = appSettingHolder.Add(_BuilderFactory
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

			if (_Cache.Exists<Project>(projectName))
			{
				project = _Cache.Get<Project>(projectName);
			}
			else
			{
				project = _BuilderFactory
					.ProjectBuilder()
					.WithName(projectName)
					.Build();
				_Cache.Add(projectName, project);
			}

			return project;
		}

		private Environment GetEnvironment(string environmentName)
		{
			Environment environment = null;

			if (_Cache.Exists<Environment>(environmentName))
			{
				environment = _Cache.Get<Environment>(environmentName);
			}
			else
			{
				environment = _BuilderFactory
					.EnvironmentBuilder()
					.WithName(environmentName)
					.Build();
				_Cache.Add(environmentName, environment);
			}

			return environment;
		}
	}
}