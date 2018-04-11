using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data
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