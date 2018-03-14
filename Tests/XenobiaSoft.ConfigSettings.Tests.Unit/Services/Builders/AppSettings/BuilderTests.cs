using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.AppSettings
{
	[TestFixture]
	public class BuilderTests : AutoMockFixtureInterface<AppSettingBuilder, IAppSettingBuilder>
	{
		[Test]
		public void Build_Returns_FullyConfiguredAppSetting()
		{
			// Assemble

			// Act
			var appSetting = Sut.Build();

			// Assert
			appSetting.Should().NotBeNull();
		}

		public override void PostSetup()
		{
			Fixture.Register(() => AppSettingBuilder.CreateNew() as AppSettingBuilder);
		}
	}
}