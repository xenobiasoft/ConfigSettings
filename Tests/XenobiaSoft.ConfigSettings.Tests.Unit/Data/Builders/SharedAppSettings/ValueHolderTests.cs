using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.SharedAppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders.SharedAppSettings
{
	[TestFixture]
	public class ValueHolderTests : AutoMockFixtureInterface<SharedAppSettingBuilder, IValueHolder>
	{
		[Test]
		public void Returns_AppSettingBuilder()
		{
			// Assemble

			// Act
			var actual = Sut.WithValue(Create<string>());

			// Assert
			actual.Should().BeAssignableTo<ISharedAppSettingBuilder>();
		}

		[Test]
		public void CanBeEmptyString()
		{
			// Assemble

			// Act
			Action withValue = () => Sut.WithValue(string.Empty);

			// Assert
			withValue.Should().NotThrow<ArgumentNullException>();
		}

		[Test]
		public void ThrowsArgumentNullException_WhenValueIsNull()
		{
			// Assemble

			// Act
			Action withValue = () => Sut.WithValue(null);

			// Assert
			withValue.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => SharedAppSettingBuilder.CreateNew() as SharedAppSettingBuilder);
		}
	}
}