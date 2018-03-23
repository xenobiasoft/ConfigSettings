using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Interfaces;

namespace XenobiaSoft.ConfigSettings.Tests.Integration.Services
{
	[TestFixture]
	[Explicit]
	public class ConfigServiceTests : BaseTest<IConfigService>
	{
		[Test]
		public void PopulateDb()
		{
			// Assemble
			var rootPath = @"E:\Git\dryfly\FreeStone";

			// Act
			Sut.ClearDb();
			Sut.LoadConfigurations(rootPath);

			// Assert
		}
	}
}