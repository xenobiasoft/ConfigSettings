using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Repositories
{
	[TestFixture]
	public class EnvironmentRepositoryTests : EntityRepositoryTests<Environment>
	{
		protected override Environment CreateNewEntity()
		{
			return new Environment();
		}
	}
}