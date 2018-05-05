using System;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class FactoryMethodTests : AutoMockFixtureConcrete<ProjectEnvironmentConfigBuilder>
	{
		[Test]
		public void CreateNew_Returns_ConfigPathHolder()
		{
			// Assemble

			// Act
			var actual = ProjectEnvironmentConfigBuilder.CreateNew();

			// Assert
			actual.Should().BeAssignableTo<IConfigPathHolder>();
		}

		[Test]
		public void CreateExisting_Returns_ConfigPathHolder()
		{
			// Assemble

			// Act
			var actual = ProjectEnvironmentConfigBuilder.CreateExisting(Create<int>());

			// Assert
			actual.Should().BeAssignableTo<IConfigPathHolder>();
		}

		[TestCase(0)]
		[TestCase(-10)]
		public void CreateExisting_ThrowsArgumentException_WhenIdLessThanOrEqualToZero(int id)
		{
			// Assemble

			// Act
			Action createExisting = () => ProjectEnvironmentConfigBuilder.CreateExisting(id);

			// Assert
			createExisting.Should().Throw<ArgumentException>();
		}
	}
}