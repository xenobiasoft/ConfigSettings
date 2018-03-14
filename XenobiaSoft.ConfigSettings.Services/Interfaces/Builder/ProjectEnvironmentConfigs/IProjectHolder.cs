using System;
using System.Diagnostics.Contracts;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs
{
	[ContractClass(typeof(ProjectHolder))]
	public interface IProjectHolder
	{
		IEnvironmentHolder WithProject(Project project);
	}

	[ContractClassFor(typeof(IProjectHolder))]
	public abstract class ProjectHolder : IProjectHolder
	{
		public IEnvironmentHolder WithProject(Project project)
		{
			Contract.Requires<ArgumentNullException>(project != null);

			return null;
		}
	}
}