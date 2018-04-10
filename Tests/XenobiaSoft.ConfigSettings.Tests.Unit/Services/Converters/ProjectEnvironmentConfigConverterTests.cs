using FluentAssertions;
using Moq;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Converters;
using XenobiaSoft.ConfigSettings.Services.Interfaces;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Converters
{
	[TestFixture]
	public class ProjectEnvironmentConfigConverterTests : AutoMockFixtureInterface<ProjectEnvironmentConfigConverter, IProjectEnvironmentConfigConverter>
	{
		private Mock<ICache> _MockCache;
		private Mock<IProjectBuilder> _MockProjectBuilder;
		private Mock<IEnvironmentBuilder> _MockEnvironmentBuilder;

		[TestFixture]
		public class ProjectTests : ProjectEnvironmentConfigConverterTests
		{
			[Test]
			public void Convert_ReturnsProjectEnvironmentConfig_WithExpectedProject()
			{
				// Assemble

				// Act
				var projectEnvironmentConfig = Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				projectEnvironmentConfig.Project.Should().NotBeNull();
			}

			[Test]
			public void Convert_ChecksCacheForProjects()
			{
				// Assemble

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockCache.Verify(x => x.Exists<Project>(It.IsAny<string>()), Times.Once);
			}

			[Test]
			public void Convert_GetsProjectFromCache_IfExistsInCache()
			{
				// Assemble
				_MockCache.Setup(x => x.Exists<Project>(It.IsAny<string>())).Returns(true);

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockCache.Verify(x => x.Get<Project>(It.IsAny<string>()), Times.Once);
			}

			[Test]
			public void Convert_DoesNotCallBuilder_IfExistsInCache()
			{
				// Assemble
				_MockCache.Setup(x => x.Exists<Project>(It.IsAny<string>())).Returns(true);

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockProjectBuilder.Verify(x => x.Build(), Times.Never);
			}

			[Test]
			public void Convert_CallsBuilder_IfNotExistsInCache()
			{
				// Assemble

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockProjectBuilder.Verify(x => x.Build(), Times.Once);
			}

			[Test]
			public void Convert_AddsProjectToCache_IfNotExistsInCache()
			{
				// Assemble

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockCache.Verify(x => x.Add(It.IsAny<string>(), It.IsAny<Project>()), Times.Once);
			}
		}

		[TestFixture]
		public class EnvironmentTests : ProjectEnvironmentConfigConverterTests
		{
			[Test]
			public void Convert_ReturnsProjectEnvironmentConfig_WithExpectedEnvironment()
			{
				// Assemble

				// Act
				var projectEnvironmentConfig = Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				projectEnvironmentConfig.Environment.Should().NotBeNull();
			}

			[Test]
			public void Convert_ChecksCacheForEnvironment()
			{
				// Assemble

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockCache.Verify(x => x.Exists<Environment>(It.IsAny<string>()), Times.Once);
			}

			[Test]
			public void Convert_GetsEnvironmentFromCache_IfExistsInCache()
			{
				// Assemble
				_MockCache.Setup(x => x.Exists<Environment>(It.IsAny<string>())).Returns(true);

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockCache.Verify(x => x.Get<Environment>(It.IsAny<string>()), Times.Once);
			}

			[Test]
			public void Convert_DoesNotCallBuilder_IfExistsInCache()
			{
				// Assemble
				_MockCache.Setup(x => x.Exists<Environment>(It.IsAny<string>())).Returns(true);

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockEnvironmentBuilder.Verify(x => x.Build(), Times.Never);
			}

			[Test]
			public void Convert_CallsBuilder_IfNotExistsInCache()
			{
				// Assemble

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockEnvironmentBuilder.Verify(x => x.Build(), Times.Once);
			}

			[Test]
			public void Convert_AddsEnvironmentToCache_IfNotExistsInCache()
			{
				// Assemble

				// Act
				Sut.Convert(Create<ProjectEnvironmentConfiguration>());

				// Assert
				_MockCache.Verify(x => x.Add(It.IsAny<string>(), It.IsAny<Environment>()), Times.Once);
			}
		}

		public override void PostSetup()
		{
			_MockCache = ResolveMock<ICache>();
			_MockProjectBuilder = ResolveMock<IProjectBuilder>();
			_MockEnvironmentBuilder = ResolveMock<IEnvironmentBuilder>();
		}
	}
}