using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data
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