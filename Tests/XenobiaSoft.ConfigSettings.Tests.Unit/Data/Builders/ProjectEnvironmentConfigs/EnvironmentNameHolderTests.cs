using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class EnvironmentNameHolderTests : AutoMockFixtureInterface<ProjectEnvironmentConfigBuilder, IEnvironmentNameHolder>
	{
		[Test]
		public void Returns_AppSettingHolder()
		{
			// Assemble

			// Act
			var actual = Sut.WithEnvironmentName(Create<string>());

			// Assert
			actual.Should().BeAssignableTo<IAppSettingHolder>();
		}

		[TestCase("")]
		[TestCase((string) null)]
		public void ThrowsArgumentNullException_WhenEnvironmentIsNullOrEmpty(string environmentName)
		{
			// Assemble

			// Act
			Action withEnvironment = () => Sut.WithEnvironmentName(environmentName);

			// Assert
			withEnvironment.Should().Throw<ArgumentNullException>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}