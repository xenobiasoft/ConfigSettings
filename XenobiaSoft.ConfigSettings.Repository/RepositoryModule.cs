using Autofac;
using XenobiaSoft.ConfigSettings.Repository.Context;

namespace XenobiaSoft.ConfigSettings.Repository
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