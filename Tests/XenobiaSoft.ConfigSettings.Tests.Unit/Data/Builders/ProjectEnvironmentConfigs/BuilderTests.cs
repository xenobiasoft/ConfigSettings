using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders.ProjectEnvironmentConfigs
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
			actual.Should().BeOfType<ProjectEnvironmentConfiguration>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}