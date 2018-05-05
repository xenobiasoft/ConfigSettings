using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.AppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders.AppSettings
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