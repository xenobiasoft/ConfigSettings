using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs
{
	[ContractClass(typeof(ConfigPathHolder))]
	public interface IConfigPathHolder
	{
		IProjectNameHolder WithConfigPath(string configPath);
	}

	[ContractClassFor(typeof(IConfigPathHolder))]
	public abstract class ConfigPathHolder : IConfigPathHolder
	{
		public IProjectNameHolder WithConfigPath(string configPath)
		{
			Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(configPath));

			return null;
		}
	}
}