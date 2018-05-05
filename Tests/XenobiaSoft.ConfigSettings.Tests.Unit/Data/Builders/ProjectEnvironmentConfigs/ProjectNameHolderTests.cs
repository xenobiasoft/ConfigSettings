using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class ProjectNameHolderTests : AutoMockFixtureInterface<ProjectEnvironmentConfigBuilder, IProjectNameHolder>
	{
		[Test]
		public void Returns_EnvironmentHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithProjectName(Create<string>());

			// Assert
			actual.Should().BeAssignableTo<IEnvironmentNameHolder>();
		}

		[TestCase("")]
		[TestCase((string) null)]
		public void ThrowsArgumentNullException_WhenProjectIsNullOrEmpty(string projectName)
		{
			// Assemble

			// Act
			Action withProject = () => Sut.WithProjectName(projectName);

			// Assert
			withProject.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}