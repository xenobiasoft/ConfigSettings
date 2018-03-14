using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects
{
	[ContractClass(typeof(ProjectNameHolder))]
	public interface IProjectNameHolder
	{
		IProjectBuilder WithName(string name);
	}

	[ContractClassFor(typeof(IProjectNameHolder))]
	public abstract class ProjectNameHolder : IProjectNameHolder
	{
		public IProjectBuilder WithName(string name)
		{
			Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name));

			return null;
		}
	}
}