using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.Projects
{
	[TestFixture]
	public class ProjectBuilderTests : AutoMockFixtureInterface<ProjectBuilder, IProjectBuilder>
	{
		[Test]
		public void ReturnsProjectWithModifiedDate()
		{
			// Assemble

			// Act
			var project = Sut.Build();

			// Assert
			project.ModifiedDate.Should().BeCloseTo(DateTime.Now, 100);
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectBuilder.CreateNew() as ProjectBuilder);
		}
	}
}