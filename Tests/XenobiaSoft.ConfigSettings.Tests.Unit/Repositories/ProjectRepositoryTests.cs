using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Repositories
{
	[TestFixture]
	public class ProjectRepositoryTests : EntityRepositoryTests<Project>
	{
		protected override Project CreateNewEntity()
		{
			return new Project();
		}
	}
}