using System;
using System.Diagnostics.Contracts;
using Environment = XenobiaSoft.ConfigSettings.Data.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs
{
	[ContractClass(typeof(EnvironmentHolder))]
	public interface IEnvironmentHolder
	{
		IAppSettingHolder WithEnvironment(Environment environment);
	}

	[ContractClassFor(typeof(IEnvironmentHolder))]
	public abstract class EnvironmentHolder : IEnvironmentHolder
	{
		public IAppSettingHolder WithEnvironment(Environment environment)
		{
			Contract.Requires<ArgumentNullException>(environment != null);

			return null;
		}
	}
}