using Autofac;
using XenobiaSoft.ConfigSettings.Data;
using XenobiaSoft.ConfigSettings.Services;

namespace XenobiaSoft.ConfigSettings.Installer
{
	public class InstallerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule(new ServicesModule());
			builder.RegisterModule(new RepositoryModule());
		}
	}
}