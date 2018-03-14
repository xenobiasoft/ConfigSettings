using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.Environments
{
	[TestFixture]
	public class FactoryMethodTests : AutoMockFixtureConcrete<EnvironmentBuilder>
	{
		[Test]
		public void CreateNew_Returns_EnvironmentNameHolder()
		{
			// Assemble

			// Act
			var instance = EnvironmentBuilder.CreateNew();

			// Assert
			instance.Should().BeAssignableTo<IEnvironmentNameHolder>();
		}

		[Test]
		public void CreateExisting_Returns_EnvironmentNameHolder()
		{
			// Assemble

			// Act
			var instance = EnvironmentBuilder.CreateExisting(Create<int>());

			// Assert
			instance.Should().BeAssignableTo<IEnvironmentNameHolder>();
		}

		[TestCase(0)]
		[TestCase(-7)]
		public void ThrowsArgumentException_WhenIdIsLessThanZero(int id)
		{
			// Assemble

			// Act
			Action createExisting = () => EnvironmentBuilder.CreateExisting(id);

			// Assert
			createExisting.Should().Throw<ArgumentException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => EnvironmentBuilder.CreateNew() as EnvironmentBuilder);
		}
	}
}