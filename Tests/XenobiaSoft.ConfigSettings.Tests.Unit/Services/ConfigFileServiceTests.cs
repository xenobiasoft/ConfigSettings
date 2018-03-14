using System.IO;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services
{
	[TestFixture]
	public class ConfigFileServiceTests : AutoMockFixtureInterface<ConfigFileService, IFileService>
	{
		[Test]
		public void GetConfigFiles_ReturnsListOfConfigFiles()
		{
			// Assemble
			var rootPath = Path.Combine(TestContext.TestDirectory, "ConfigSample");

			// Act
			var configFiles = Sut.GetConfigFiles(rootPath);

			// Assert
			configFiles.Count.Should().Be(7);
		}

		[Test]
		public void GetSharedAppSettings_ReturnsSingleConfigFile()
		{
			// Assemble
			var rootPath = Path.Combine(TestContext.TestDirectory, "ConfigSample");
			var filename = "SharedAppSettings.config";
			var expectedConfigFile = new ConfigFile(Path.Combine(rootPath, "Configs", filename), filename, "Configs");

			// Act
			var configFile = Sut.GetSharedAppSettings(rootPath);

			// Assert
			configFile.Should().Be(expectedConfigFile);
		}
	}
}