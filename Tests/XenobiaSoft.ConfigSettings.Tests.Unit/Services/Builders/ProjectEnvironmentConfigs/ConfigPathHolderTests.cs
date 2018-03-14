using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class ConfigPathHolderTests : AutoMockFixtureInterface<ProjectEnvironmentConfigBuilder, IConfigPathHolder>
	{
		[Test]
		public void Returns_ProjectHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithConfigPath(Create<string>());

			// Assert
			actual.Should().BeAssignableTo<IProjectHolder>();
		}

		[TestCase("")]
		[TestCase(null)]
		public void RequiresConfigPath_NotNullOrEmptyString(string configPath)
		{
			// Assemble

			// Act
			Action withConfigPath = () => Sut.WithConfigPath(configPath);

			// Assert
			withConfigPath.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}