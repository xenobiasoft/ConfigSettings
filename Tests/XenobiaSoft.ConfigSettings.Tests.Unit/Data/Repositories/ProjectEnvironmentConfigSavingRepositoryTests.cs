using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.V2.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Repositories
{
	[TestFixture]
	public class ProjectEnvironmentConfigSavingRepositoryTests : SavingRepositoryTests<ProjectEnvironmentConfiguration, int>
	{
		protected override int GetValidId()
		{
			return Create<int>();
		}

		protected override void ModifyModel(ProjectEnvironmentConfiguration model)
		{
			model.ProjectName = Create<string>();
			model.EnvironmentName = Create<string>();
		}
	}
}