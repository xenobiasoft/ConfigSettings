using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data
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