using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.AppSettings;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders
{
	[TestFixture]
	public class BuilderFactoryTests : AutoMockFixtureConcrete<BuilderFactory>
	{
		[Test]
		public void AppSettingBuilder_NoId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.AppSettingBuilder();

			// Assert
			builder.Should().BeAssignableTo<IKeyHolder>();
		}

		[Test]
		public void AppSettingBuilder_WithId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.AppSettingBuilder(Create<int>());

			// Assert
			builder.Should().BeAssignableTo<IKeyHolder>();
		}

		[Test]
		public void SharedAppSettingBuilder_NoId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.SharedAppSettingsBuilder();

			// Assert
			builder.Should().BeAssignableTo<ConfigSettings.Data.Interfaces.Builder.SharedAppSettings.IKeyHolder>();
		}

		[Test]
		public void SharedAppSettingsBuilder_WithId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.SharedAppSettingsBuilder(Create<int>());

			// Assert
			builder.Should().BeAssignableTo<ConfigSettings.Data.Interfaces.Builder.SharedAppSettings.IKeyHolder>();
		}

		[Test]
		public void ProjectEnvironmentConfigBuilder_NoId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.ProjectEnvironmentConfigBuilder();

			// Assert
			builder.Should().BeAssignableTo<IConfigPathHolder>();
		}
	}
}