using Autofac;
using XenobiaSoft.ConfigSettings.Data.Context;

namespace XenobiaSoft.ConfigSettings.Data
{
	public class RepositoryModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterType<ConfigSettingsUnitOfWork>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			builder
				.RegisterType<ConfigSettingsContext>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}