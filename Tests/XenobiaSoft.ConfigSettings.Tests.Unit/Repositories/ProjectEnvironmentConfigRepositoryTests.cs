using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Repositories
{
	[TestFixture]
	public class ProjectEnvironmentConfigRepositoryTests : EntityRepositoryTests<ProjectEnvironmentConfig>
	{
		protected override ProjectEnvironmentConfig CreateNewEntity()
		{
			return new ProjectEnvironmentConfig();
		}
	}
}