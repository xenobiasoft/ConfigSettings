using Moq;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Interfaces;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Data.V2.Models;
using XenobiaSoft.ConfigSettings.Services;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;

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
			public void CallsToConvertProjectConfigurations()
			{
				// Assemble
				var mockConverter = ResolveMock<IProjectEnvironmentConfigConverter>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockConverter.Verify(x => x.Convert(It.IsAny<ProjectEnvironmentConfiguration>()), Times.AtLeast(3));
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
			public void CallsToConvertSharedApSettings()
			{
				// Assemble
				var mockSharedAppSettingsConverter = ResolveMock<ISharedAppSettingConverter>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockSharedAppSettingsConverter.Verify(x => x.Convert(It.IsAny<ConfigSettings.Data.V2.Models.AppSetting>()), Times.Exactly(3));
			}

			[Test]
			public void CallsToSaveProjects()
			{
				// Assemble
				var mockRepository = ResolveMock<IRepository<Project>>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockRepository.Verify(x => x.Add(It.IsAny<Project>()), Times.Exactly(3));
			}

			[Test]
			public void CallsToSaveEnvironments()
			{
				// Assemble
				var mockRepository = ResolveMock<IRepository<Environment>>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockRepository.Verify(x => x.Add(It.IsAny<Environment>()), Times.Exactly(3));
			}

			[Test]
			public void CallsToSaveProjectEnvironmentConfigs()
			{
				// Assemble
				var mockRepository = ResolveMock<IRepository<ProjectEnvironmentConfig>>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockRepository.Verify(x => x.Add(It.IsAny<ProjectEnvironmentConfig>()), Times.Exactly(3));
			}

			[Test]
			public void CallsToSaveAppSettings()
			{
				// Assemble
				var mockRepository = ResolveMock<IRepository<ConfigSettings.Data.Models.AppSetting>>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockRepository.Verify(x => x.Add(It.IsAny<ConfigSettings.Data.Models.AppSetting>()), Times.Exactly(9));
			}

			[Test]
			public void CallsToSaveSharedAppSettingForEverySharedAppSetting()
			{
				// Assemble
				var mockRepository = ResolveMock<IRepository<SharedAppSetting>>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockRepository.Verify(x => x.Add(It.IsAny<SharedAppSetting>()), Times.Exactly(3));
			}

			[Test]
			public void CallsToCommitAllChanges()
			{
				// Assemble
				var mockUow = ResolveMock<IUnitOfWork>();

				// Act
				Sut.LoadConfigurations(Create<string>());

				// Assert
				mockUow.Verify(x => x.Commit(), Times.Once);
			}
		}

		[TestFixture]
		public class ClearDbTests : ConfigServiceTests
		{
			[Test]
			public void CallsToDeleteAllAppSettings()
			{
				// Assemble
				var mockAppSettingRepository = ResolveMock<IRepository<ConfigSettings.Data.Models.AppSetting>>();

				// Act
				Sut.ClearDb();

				// Assert
				mockAppSettingRepository.Verify(x => x.RemoveAll(), Times.Once);
			}

			[Test]
			public void CallsToDeleteAllEnvironments()
			{
				// Assemble
				var mockAppSettingRepository = ResolveMock<IRepository<Environment>>();

				// Act
				Sut.ClearDb();

				// Assert
				mockAppSettingRepository.Verify(x => x.RemoveAll(), Times.Once);
			}

			[Test]
			public void CallsToDeleteAllProjects()
			{
				// Assemble
				var mockAppSettingRepository = ResolveMock<IRepository<Project>>();

				// Act
				Sut.ClearDb();

				// Assert
				mockAppSettingRepository.Verify(x => x.RemoveAll(), Times.Once);
			}

			[Test]
			public void CallsToDeleteAllProjectEnvironmentConfigs()
			{
				// Assemble
				var mockAppSettingRepository = ResolveMock<IRepository<ProjectEnvironmentConfig>>();

				// Act
				Sut.ClearDb();

				// Assert
				mockAppSettingRepository.Verify(x => x.RemoveAll(), Times.Once);
			}

			[Test]
			public void CallsToDeleteAllSharedAppSettings()
			{
				// Assemble
				var mockAppSettingRepository = ResolveMock<IRepository<SharedAppSetting>>();

				// Act
				Sut.ClearDb();

				// Assert
				mockAppSettingRepository.Verify(x => x.RemoveAll(), Times.Once);
			}
		}
	}
}