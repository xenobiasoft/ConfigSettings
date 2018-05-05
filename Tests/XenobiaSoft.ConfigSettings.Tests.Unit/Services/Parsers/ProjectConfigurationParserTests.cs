using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers;
using XenobiaSoft.ConfigSettings.Services.Models;
using XenobiaSoft.ConfigSettings.Services.Parsers;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Parsers
{
	[TestFixture]
	public class ProjectConfigurationParserTests : AutoMockFixtureInterface<ProjectConfigurationParser, IProjectConfigurationParser>
	{
		[TestFixture]
		public class ParseTests : ProjectConfigurationParserTests
		{
			[Test]
			public void ParsesProjectNameFromConfigFile()
			{
				// Assemble
				var expectedProjectName = "Sub1";
				var configFile = GetConfigFileInfo("Sub1", "app.config");

				// Act
				var actualProjectConfig = Sut.Parse(configFile);

				// Assert
				actualProjectConfig.ProjectName.Should().Be(expectedProjectName);
			}

			[Test]
			public void ParsesEnvironmentNameFromConfigFile()
			{
				// Assemble
				var expectedEnvironmentName = "QA";
				var configFile = GetConfigFileInfo("Sub1", "app.qa.config");

				// Act
				var actualProjectConfig = Sut.Parse(configFile);

				// Assert
				actualProjectConfig.EnvironmentName.Should().Be(expectedEnvironmentName);
			}

			[Test]
			public void ParsesConfigPathFromConfigFile()
			{
				// Assemble
				var filename = "SharedAppSettings.config";
				var expectedConfigPath = Path.Combine(TestContext.TestDirectory, "ConfigSample", "Configs", filename);
				var configFile = GetConfigFileInfo("Configs", filename);

				// Act
				var actualProjectConfig = Sut.Parse(configFile);

				// Assert
				actualProjectConfig.ConfigPath.Should().Be(expectedConfigPath);
			}

			[Test]
			public void ParsesAppSettingsFromConfigFile()
			{
				// Assemble
				var configFile = GetConfigFileInfo("Sub3", "web.config");

				// Act
				var actualProjectConfig = Sut.Parse(configFile);

				// Assert
				actualProjectConfig.AppSettings.Count.Should().Be(3);
			}

			[Test]
			public void ReturnsNullWhenConfigFileDoesNotContainAppSettings()
			{
				// Assemble
				var configFile = GetConfigFileInfo("Sub4", "app.config");
				ResolveMock<IAppSettingsParser>().Setup(x => x.Parse(It.IsAny<ConfigFile>())).Returns(new List<AppSetting>());

				// Act
				var actualProjectConfig = Sut.Parse(configFile);

				// Assert
				actualProjectConfig.Should().BeNull();
			}

			private ConfigFile GetConfigFileInfo(string directoryName, string fileName)
			{
				var fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ConfigSample", directoryName, fileName);

				return new ConfigFile(fullPath, fileName, directoryName);
			}
		}
	}
}