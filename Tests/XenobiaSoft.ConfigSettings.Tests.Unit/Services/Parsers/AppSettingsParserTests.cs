using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers;
using XenobiaSoft.ConfigSettings.Services.Models;
using XenobiaSoft.ConfigSettings.Services.Parsers;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Parsers
{
	[TestFixture]
	public class AppSettingsParserTests : AutoMockFixtureInterface<AppSettingsParser, IAppSettingsParser>
	{
		[TestFixture]
		public class ParseTests : AppSettingsParserTests
		{
			[Test]
			public void ParsesAppSettingsFromConfigFile()
			{
				// Assemble
				var configFile = GetConfigFileInfo("Sub3", "web.config");

				// Act
				var actualAppSettings = Sut.Parse(configFile);

				// Assert
				actualAppSettings.Count.Should().Be(3);
			}

			[Test]
			public void CanParseTransformConfig()
			{
				// Assemble
				var expectedTransformType = TransformType.Replace;
				var configFile = GetConfigFileInfo("Sub1", "app.qa.config");

				// Act
				var actualAppSettings = Sut.Parse(configFile);

				// Assert
				actualAppSettings.First().TransformType.Should().Be(expectedTransformType);
			}

			[Test]
			public void ReturnsEmptyListWhenConfigFileDoesNotContainAppSettings()
			{
				// Assemble
				var configFile = GetConfigFileInfo("Sub4", "app.config");

				// Act
				var actualAppSettings = Sut.Parse(configFile);

				// Assert
				actualAppSettings.Should().BeEmpty();
			}

			private ConfigFile GetConfigFileInfo(string directoryName, string fileName)
			{
				var fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ConfigSample", directoryName, fileName);

				return new ConfigFile(fullPath, fileName, directoryName);
			}
		}
	}
}