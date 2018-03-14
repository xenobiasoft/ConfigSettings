using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs
{
	[ContractClass(typeof(ConfigPathHolder))]
	public interface IConfigPathHolder
	{
		IProjectHolder WithConfigPath(string configPath);
	}

	[ContractClassFor(typeof(IConfigPathHolder))]
	public abstract class ConfigPathHolder : IConfigPathHolder
	{
		public IProjectHolder WithConfigPath(string configPath)
		{
			Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(configPath));

			return null;
		}
	}
}