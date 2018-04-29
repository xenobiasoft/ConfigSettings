using Moq;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Interfaces;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services;
using XenobiaSoft.ConfigSettings.Services.Interfaces;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services
{
	[TestFixture]
	public class ConfigServiceTests : AutoMockFixtureInterface<ConfigService, IConfigService>
	{
		[TestFixture]
		public class LoadConfigurationsTests : ConfigServiceTests
		{
			[Test]
			public void CallsToLoadConfigs()
			{
				// Assemble
				var mockConfigLoader = ResolveMock<IConfigLoader>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockConfigLoader.Verify(x => x.LoadConfigs(It.IsAny<string>()), Times.Once);
			}

			[Test]
			public void CallsLoadSharedAppSettings()
			{
				// Assemble
				var mockConfigLoader = ResolveMock<IConfigLoader>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockConfigLoader.Verify(x => x.LoadSharedAppSettings(It.IsAny<string>()), Times.Once);
			}

			[Test]
			public void CallsToSaveProjectEnvironmentConfigurations()
			{
				// Assemble
				var repositoryFactory = ResolveMock<IRepositoryFactory>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				repositoryFactory.Verify(x => x.CreateWrite<ProjectEnvironmentConfiguration, int>(), Times.Once);
			}

			[Test]
			public void CallsToSaveSharedAppSettingForEverySharedAppSetting()
			{
				// Assemble
				var repositoryFactory = ResolveMock<IRepositoryFactory>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				repositoryFactory.Verify(x => x.CreateWrite<AppSetting, int>(), Times.Once);
			}
		}
	}
}