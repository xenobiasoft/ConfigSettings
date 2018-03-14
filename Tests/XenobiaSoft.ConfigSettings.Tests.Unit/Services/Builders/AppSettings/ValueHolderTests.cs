using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.AppSettings
{
	[TestFixture]
	public class ValueHolderTests : AutoMockFixtureInterface<AppSettingBuilder, IValueHolder>
	{
		[Test]
		public void Returns_TransformTypeHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithValue(Create<string>());

			// Assert
			actual.Should().BeAssignableTo<ITransformTypeHolder>();
		}

		[Test]
		public void CanBeEmptyString()
		{
			// Assemble

			// Act
			Action withValue = () => Sut.WithValue(string.Empty);

			// Assert
			withValue.Should().NotThrow<Exception>();
		}

		[Test]
		public void CannotBeNull()
		{
			// Assemble

			// Act
			Action withValue = () => Sut.WithValue(null);

			// Assert
			withValue.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => AppSettingBuilder.CreateNew() as AppSettingBuilder);
		}
	}
}