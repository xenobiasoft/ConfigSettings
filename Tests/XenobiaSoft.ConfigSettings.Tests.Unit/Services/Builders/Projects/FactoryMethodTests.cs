using System;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.Projects
{
	public class FactoryMethodTests : AutoMockFixtureConcrete<ProjectBuilder>
	{
		[Test]
		public void CreateNew_Returns_ProjectNameHolder()
		{
			// Assemble

			// Act
			var instance = ProjectBuilder.CreateNew();

			// Assert
			instance.Should().BeAssignableTo<IProjectNameHolder>();
		}

		[Test]
		public void CreateExisting_Returns_ProjectNameHolder()
		{
			// Assemble

			// Act
			var instance = ProjectBuilder.CreateExisting(Create<int>());

			// Assert
			instance.Should().BeAssignableTo<IProjectNameHolder>();
		}

		[TestCase(0)]
		[TestCase(-3)]
		public void ThrowsArgumentException_WhenIdIsLessThanOrEqualToZero(int id)
		{
			// Assemble

			// Act
			Action action = () => ProjectBuilder.CreateExisting(id);

			// Assert
			action.Should().Throw<ArgumentException>();
		}
	}
}