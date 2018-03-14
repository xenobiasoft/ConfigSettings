using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.Projects
{
	[TestFixture]
	public class ProjectNameHolderTests : AutoMockFixtureInterface<ProjectBuilder, IProjectNameHolder>
	{
		[Test]
		public void ReturnsProjectBuilderInstance()
		{
			// Assemble

			// Act
			var instance = Sut.WithName(Create<string>());

			// Assert
			instance.Should().BeAssignableTo<IProjectBuilder>();
		}

		[TestCase("")]
		[TestCase(null)]
		public void ThrowsArgumentNullException_WhenProjectNameIsNullOrEmpty(string projectName)
		{
			// Assemble

			// Act
			Action withName = () => Sut.WithName(projectName);

			// Assert
			withName.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectBuilder.CreateNew() as ProjectBuilder);
		}
	}
}