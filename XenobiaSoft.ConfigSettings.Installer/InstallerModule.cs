using Autofac;
using XenobiaSoft.ConfigSettings.Data;
using XenobiaSoft.ConfigSettings.Services;

namespace XenobiaSoft.ConfigSettings.Installer
{
	public class InstallerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule(new ServicesInstallerModule());
			builder.RegisterModule(new DataInstallerModule());
		}
	}
}