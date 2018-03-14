using System;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.AppSettings
{
	[TestFixture]
	public class FactoryMethodTests : AutoMockFixtureConcrete<AppSettingBuilder>
	{
		[Test]
		public void CreateNew_ReturnsKeyHolder()
		{
			// Assemble

			// Act
			var actual = AppSettingBuilder.CreateNew();

			// Assert
			actual.Should().BeAssignableTo<IKeyHolder>();
		}

		[Test]
		public void CreateExisting_ReturnsKeyHolder()
		{
			// Assemble

			// Act
			var actual = AppSettingBuilder.CreateExisting(Create<int>());

			// Assert
			actual.Should().BeAssignableTo<IKeyHolder>();
		}

		[TestCase(0)]
		[TestCase(-4)]
		public void CreateExisting_ThrowsArgumentException_WhenNegativeNumberIsPassedIn(int id)
		{
			// Assemble

			// Act
			Action createExisting = () => AppSettingBuilder.CreateExisting(id);

			// Assert
			createExisting.Should().Throw<ArgumentException>().WithMessage("App Setting Id must be greater than 0.");
		}
	}
}