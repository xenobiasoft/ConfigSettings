using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;
using Environment = XenobiaSoft.ConfigSettings.Repository.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class EnvironmentHolderTests : AutoMockFixtureInterface<ProjectEnvironmentConfigBuilder, IEnvironmentHolder>
	{
		[Test]
		public void Returns_AppSettingHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithEnvironment(Create<Environment>());

			// Assert
			actual.Should().BeAssignableTo<IAppSettingHolder>();
		}

		[Test]
		public void ThrowsArgumentNullException_WhenEnvironmentIsNull()
		{
			// Assemble

			// Act
			Action withEnvironment = () => Sut.WithEnvironment(null);

			// Assert
			withEnvironment.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}