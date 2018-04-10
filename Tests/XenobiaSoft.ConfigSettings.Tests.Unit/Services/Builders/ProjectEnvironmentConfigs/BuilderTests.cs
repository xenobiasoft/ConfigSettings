using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class BuilderTests : AutoMockFixtureInterface<ProjectEnvironmentConfigBuilder, IProjectEnvironmentConfigBuilder>
	{

		[Test]
		public void Build_Returns_ProjectEnvironmentConfig()
		{
			// Assemble

			// Act
			var actual = Sut.Build();

			// Assert
			actual.Should().BeOfType<ProjectEnvironmentConfig>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}