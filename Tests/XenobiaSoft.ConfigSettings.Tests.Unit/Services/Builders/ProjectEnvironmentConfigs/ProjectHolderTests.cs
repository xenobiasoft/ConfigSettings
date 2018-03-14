using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class ProjectHolderTests : AutoMockFixtureInterface<ProjectEnvironmentConfigBuilder, IProjectHolder>
	{
		[Test]
		public void Returns_EnvironmentHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithProject(Create<Project>());

			// Assert
			actual.Should().BeAssignableTo<IEnvironmentHolder>();
		}

		[Test]
		public void ThrowsArgumentNullException_WhenProjectIsNull()
		{
			// Assemble

			// Act
			Action withProject = () => Sut.WithProject(null);

			// Assert
			withProject.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}