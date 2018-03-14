using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders
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
			builder.Should().BeAssignableTo<ConfigSettings.Services.Interfaces.Builder.SharedAppSettings.IKeyHolder>();
		}

		[Test]
		public void SharedAppSettingsBuilder_WithId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.SharedAppSettingsBuilder(Create<int>());

			// Assert
			builder.Should().BeAssignableTo<ConfigSettings.Services.Interfaces.Builder.SharedAppSettings.IKeyHolder>();
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

		[Test]
		public void ProjectBuilder_NoId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.ProjectBuilder();

			// Assert
			builder.Should().BeAssignableTo<IProjectNameHolder>();
		}

		[Test]
		public void ProjectBuilder_WithId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.ProjectBuilder(Create<int>());

			// Assert
			builder.Should().BeAssignableTo<IProjectNameHolder>();
		}

		[Test]
		public void EnvironmentBuilder_NoId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.EnvironmentBuilder();

			// Assert
			builder.Should().BeAssignableTo<IEnvironmentNameHolder>();
		}

		[Test]
		public void EnvironmentBuilder_WithId_ReturnsInstance()
		{
			// Assemble

			// Act
			var builder = Sut.EnvironmentBuilder(Create<int>());

			// Assert
			builder.Should().BeAssignableTo<IEnvironmentNameHolder>();
		}
	}
}