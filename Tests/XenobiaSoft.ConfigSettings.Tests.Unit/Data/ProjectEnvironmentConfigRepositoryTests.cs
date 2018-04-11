using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data
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