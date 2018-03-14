using System.IO;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services
{
	[TestFixture]
	public class ConfigLoaderTests : AutoMockFixtureInterface<ConfigLoader, IConfigLoader>
	{
		private string _RootPath;

		[TestFixture]
		public class LoadConfigsTests : ConfigLoaderTests
		{
			[Test]
			public void CallsFileService_GetConfigFiles()
			{
				// Assemble
				var mockFileService = ResolveMock<IFileService>();
				var rootPath = Create<string>();

				// Act
				Sut.LoadConfigs(rootPath);

				// Assert
				mockFileService.Verify(x => x.GetConfigFiles(It.IsAny<string>()), Times.Once);
			}

			[Test]
			public void CallsProjectConfigParserForEachConfigFileInDirectory()
			{
				// Assemble
				var mockProjectConfigParser = ResolveMock<IProjectConfigurationParser>();
				mockProjectConfigParser
					.Setup(x => x.Parse(It.Is<ConfigFile>(p => p.DirectoryName == "Sub4")))
					.Returns((ProjectEnvironmentConfiguration)null);

				// Act
				Sut.LoadConfigs(_RootPath);

				// Assert
				mockProjectConfigParser.Verify(x => x.Parse(It.IsAny<ConfigFile>()), Times.Exactly(3));
			}

			[Test]
			public void DoesNotParseConfigsWithoutAppSettings()
			{
				// Assemble

				// Act
				var projectConfigurations = Sut.LoadConfigs(_RootPath);

				// Assert
				projectConfigurations.All(x => x.ProjectName != "Sub4").Should().BeTrue();
			}
		}

		[TestFixture]
		public class LoadSharedAppSettingsTests : ConfigLoaderTests
		{
			[Test]
			public void CallsAppSettingsParseForSharedAppSettings()
			{
				// Assemble
				var mockAppSettingsParser = ResolveMock<IAppSettingsParser>();

				// Act
				Sut.LoadSharedAppSettings(_RootPath);

				// Assert
				mockAppSettingsParser.Verify(x => x.Parse(It.IsAny<ConfigFile>()), Times.Once);
			}
		}

		public override void PostSetup()
		{
			_RootPath = Path.Combine(TestContext.TestDirectory, "ConfigSample");
		}
	}
}