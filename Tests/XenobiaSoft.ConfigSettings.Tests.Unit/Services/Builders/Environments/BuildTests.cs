using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.Environments
{
	[TestFixture]
	public class BuildTests : AutoMockFixtureInterface<EnvironmentBuilder, IEnvironmentBuilder>
	{
		[Test]
		public void Build_Returns_Environment()
		{
			// Assemble

			// Act
			var environment = Sut.Build();

			// Assert
			environment.ModifiedDate.Should().BeCloseTo(DateTime.Now, 100);
		}

		public override void PostSetup()
		{
			Fixture.Register(() => EnvironmentBuilder.CreateNew() as EnvironmentBuilder);
		}
	}
}