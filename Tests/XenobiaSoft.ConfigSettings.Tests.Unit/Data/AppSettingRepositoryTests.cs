using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data
{
	[TestFixture]
	public class AppSettingRepositoryTests : EntityRepositoryTests<AppSetting>
	{
		protected override AppSetting CreateNewEntity()
		{
			return new AppSetting();
		}
	}
}