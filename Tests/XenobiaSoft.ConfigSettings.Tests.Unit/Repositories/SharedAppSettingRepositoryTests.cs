using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Repositories
{
	[TestFixture]
	public class SharedAppSettingRepositoryTests : EntityRepositoryTests<SharedAppSetting>
	{
		protected override SharedAppSetting CreateNewEntity()
		{
			return new SharedAppSetting();
		}
	}
}