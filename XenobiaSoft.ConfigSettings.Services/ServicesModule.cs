using Autofac;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Converters;
using XenobiaSoft.ConfigSettings.Services.Parsers;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class ServicesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterAssemblyTypes(ThisAssembly)
				.Where(x => x.Namespace == typeof(ConfigService).Namespace)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			builder
				.RegisterAssemblyTypes(ThisAssembly)
				.Where(x => x.Namespace == typeof(AppSettingsParser).Namespace)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			builder
				.RegisterAssemblyTypes(ThisAssembly)
				.Where(x => x.Namespace == typeof(AppSettingConverter).Namespace)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			builder
				.RegisterAssemblyTypes(ThisAssembly)
				.Where(x => x.Namespace == typeof(AppSettingBuilder).Namespace)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}