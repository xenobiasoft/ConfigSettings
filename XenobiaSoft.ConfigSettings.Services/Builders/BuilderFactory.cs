using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;

namespace XenobiaSoft.ConfigSettings.Services.Builders
{
	public class BuilderFactory : IBuilderFactory
	{
		public Interfaces.Builder.AppSettings.IKeyHolder AppSettingBuilder()
		{
			return Builders.AppSettingBuilder.CreateNew();
		}

		public Interfaces.Builder.AppSettings.IKeyHolder AppSettingBuilder(int id)
		{
			return Builders.AppSettingBuilder.CreateExisting(id);
		}

		public Interfaces.Builder.SharedAppSettings.IKeyHolder SharedAppSettingsBuilder()
		{
			return SharedAppSettingBuilder.CreateNew();
		}

		public Interfaces.Builder.SharedAppSettings.IKeyHolder SharedAppSettingsBuilder(int id)
		{
			return SharedAppSettingBuilder.CreateExisting(id);
		}

		public IConfigPathHolder ProjectEnvironmentConfigBuilder()
		{
			return Builders.ProjectEnvironmentConfigBuilder.CreateNew();
		}

		public IProjectNameHolder ProjectBuilder()
		{
			return Builders.ProjectBuilder.CreateNew();
		}

		public IProjectNameHolder ProjectBuilder(int id)
		{
			return Builders.ProjectBuilder.CreateExisting(id);
		}

		public IEnvironmentNameHolder EnvironmentBuilder()
		{
			return Builders.EnvironmentBuilder.CreateNew();
		}

		public IEnvironmentNameHolder EnvironmentBuilder(int id)
		{
			return Builders.EnvironmentBuilder.CreateExisting(id);
		}
	}
}