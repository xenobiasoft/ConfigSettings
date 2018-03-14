using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.Environments
{
	[TestFixture]
	public class EnvironmentNameHolderTests : AutoMockFixtureInterface<EnvironmentBuilder, IEnvironmentNameHolder>
	{
		[Test]
		public void ReturnsEnvironmentBuilderInstance()
		{
			// Assemble

			// Act
			var instance = Sut.WithName(Create<string>());

			// Assert
			instance.Should().BeAssignableTo<IEnvironmentBuilder>();
		}

		[TestCase("")]
		[TestCase(null)]
		public void ThrowsException_WhenEnvironmentNameIsNullOrEmpty(string environmentName)
		{
			// Assemble

			// Act
			Action withName = () => Sut.WithName(environmentName);

			// Assert
			withName.Should().Throw<ArgumentException>().WithMessage("Environment Name is required.");
		}

		public override void PostSetup()
		{
			Fixture.Register(() => EnvironmentBuilder.CreateNew() as EnvironmentBuilder);
		}
	}
}