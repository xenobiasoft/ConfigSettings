﻿using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.AppSettings
{

	[TestFixture]
	public class WithKeyTests : AutoMockFixtureInterface<AppSettingBuilder, IKeyHolder>
	{
		[Test]
		public void WithKey_ReturnsValueHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithKey(Create<string>());

			// Assert
			actual.Should().BeAssignableTo<IValueHolder>();
		}

		[TestCase("")]
		[TestCase(null)]
		public void ThrowsArgumentException_WhenKeyIsNullOrEmpty(string key)
		{
			// Assemble

			// Act
			Action withKey = () => Sut.WithKey(key);

			// Assert
			withKey.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => AppSettingBuilder.CreateNew() as AppSettingBuilder);
		}
	}
}