using Autofac;
using XenobiaSoft.ConfigSettings.Services;
using XenobiaSoft.ConfigSettings.Services.Parsers;

namespace XenobiaSoft.ConfigSettings.Installer
{
	public class ServicesInstallerModule : Module
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
		}
	}
}