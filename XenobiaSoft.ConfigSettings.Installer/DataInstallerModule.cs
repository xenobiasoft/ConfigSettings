using Autofac;
using MongoDB.Driver;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Repositories;

namespace XenobiaSoft.ConfigSettings.Installer
{
	public class DataInstallerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterType<RepositoryFactory>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			builder
				.RegisterAssemblyTypes(ThisAssembly)
				.Where(x => x.Namespace == typeof(AppSettingBuilder).Namespace)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			builder
				.Register(x => new MongoClient("localhost:27017"))
				.As<IMongoClient>()
				.SingleInstance();
		}
	}
}