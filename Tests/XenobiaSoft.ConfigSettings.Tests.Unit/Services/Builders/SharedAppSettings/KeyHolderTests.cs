using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.SharedAppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.SharedAppSettings
{
	[TestFixture]
	public class KeyHolderTests : AutoMockFixtureInterface<SharedAppSettingBuilder, IKeyHolder>
	{
		[Test]
		public void Returns_ValueHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithKey(Create<string>());

			// Assert
			actual.Should().BeAssignableTo<IKeyHolder>();
		}

		[TestCase("")]
		[TestCase(null)]
		public void ThrowsArgumentNullException_WhenKeyIsNullOrEmpty(string key)
		{
			// Assemble

			// Act
			Action withKey = () => Sut.WithKey(key);

			// Assert
			withKey.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => SharedAppSettingBuilder.CreateNew() as SharedAppSettingBuilder);
		}
	}
}