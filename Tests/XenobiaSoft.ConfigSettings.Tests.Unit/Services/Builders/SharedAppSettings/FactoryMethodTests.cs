using System;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.SharedAppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.SharedAppSettings
{
	[TestFixture]
	public class FactoryMethodTests : AutoMockFixtureConcrete<ProjectBuilder>
	{
		[Test]
		public void CreateNew_ReturnsKeyHolder()
		{
			// Assemble

			// Act
			var actual = SharedAppSettingBuilder.CreateNew();

			// Assert
			actual.Should().BeAssignableTo<IKeyHolder>();
		}

		[Test]
		public void CreateExisting_ReturnsKeyHolder()
		{
			// Assemble

			// Act
			var actual = SharedAppSettingBuilder.CreateExisting(Create<int>());

			// Assert
			actual.Should().BeAssignableTo<IKeyHolder>();
		}

		[TestCase(0)]
		[TestCase(-7)]
		public void CreateExisting_ThrowsArgumentException_WhenIdIsLessThanZero(int id)
		{
			// Assemble

			// Act
			Action createExisting = () => SharedAppSettingBuilder.CreateExisting(id);

			// Assert
			createExisting.Should().Throw<ArgumentException>();
		}
	}
}