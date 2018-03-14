using System.IO;
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
			var rootPath = GetConfigSamplePath();

			// Act
			Sut.ClearDb();
			Sut.LoadConfigurations(rootPath);

			// Assert
		}

		private string GetConfigSamplePath()
		{
			return Path.Combine(TestContext.TestDirectory, "ConfigSample");
		}
	}
}