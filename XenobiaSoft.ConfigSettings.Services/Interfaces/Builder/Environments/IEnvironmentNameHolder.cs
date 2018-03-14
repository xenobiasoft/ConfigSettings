using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments
{
	[ContractClass(typeof(EnvironmentNameHolder))]
	public interface IEnvironmentNameHolder
	{
		IEnvironmentBuilder WithName(string name);
	}

	[ContractClassFor(typeof(IEnvironmentNameHolder))]
	public abstract class EnvironmentNameHolder : IEnvironmentNameHolder
	{
		public IEnvironmentBuilder WithName(string name)
		{
			Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name));

			return null;
		}
	}
}