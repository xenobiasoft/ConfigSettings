using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.ProjectEnvironmentConfigs
{
	[TestFixture]
	public class AppSettingHolderTests : AutoMockFixtureInterface<ProjectEnvironmentConfigBuilder, IAppSettingHolder>
	{
		[Test]
		public void Add_Returns_AppSettingHolder()
		{
			// Assemble

			// Act
			var actual = Sut.Add(Create<AppSetting>());

			// Assert
			actual.Should().BeAssignableTo<IAppSettingHolder>();
		}

		[Test]
		public void Add_ThrowsArgumentNullException_WhenAppSettingIsNull()
		{
			// Assemble

			// Act
			Action add = () => Sut.Add(null);

			// Assert
			add.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void Done_ThrowsException_WhenNoAppSettingsWereAdded()
		{
			// Assemble

			// Act
			Action action = () => Sut.Done();

			// Assert
			action.Should().Throw<ApplicationException>().WithMessage("At least 1 AppSetting is required.");
		}

		[Test]
		public void Done_Returns_Builder()
		{
			// Assemble

			// Act
			var actual = Sut
				.Add(Create<AppSetting>())
				.Done();

			// Assert
			actual.Should().BeAssignableTo<IProjectEnvironmentConfigBuilder>();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => ProjectEnvironmentConfigBuilder.CreateNew() as ProjectEnvironmentConfigBuilder);
		}
	}
}