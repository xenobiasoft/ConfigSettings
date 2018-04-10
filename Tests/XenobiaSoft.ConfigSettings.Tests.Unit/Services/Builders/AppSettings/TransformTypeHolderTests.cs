using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.AppSettings
{
	[TestFixture]
	public class TransformTypeTests : AutoMockFixtureInterface<AppSettingBuilder, ITransformTypeHolder>
	{
		[Test]
		public void Returns_AppSettingsBuilder()
		{
			// Assemble

			// Act
			var actual = Sut.WithTransformType(Create<TransformType>().ToString());

			// Assert
			actual.Should().BeAssignableTo<IAppSettingBuilder>();
		}

		[Test]
		public void ThrowsArgumentException_WhenTransformTypeIsNotAnExpectedValue()
		{
			// Assemble

			// Act
			Action withTransformType = () => Sut.WithTransformType("InvalidValue");

			// Assert
			withTransformType.Should().Throw<ArgumentException>();
		}

		[TestCase("")]
		[TestCase(null)]
		public void NullOrEmptyString_SetsTransformTypeToNone(string transformValue)
		{
			// Assemble
			var transformTypeNone = TransformType.None.ToString();

			// Act
			var newState = Sut.WithTransformType(transformValue) as AppSettingBuilder;

			// Assert
			newState.TransformType.Should().Be(transformTypeNone);
		}

		public override void PostSetup()
		{
			Fixture.Register(() => AppSettingBuilder.CreateNew() as AppSettingBuilder);
		}
	}
}