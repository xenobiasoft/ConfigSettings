using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Builders;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.SharedAppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Builders.SharedAppSettings
{
	[TestFixture]
	public class BuilderTests : AutoMockFixtureInterface<SharedAppSettingBuilder, ISharedAppSettingBuilder>
	{
		[Test]
		public void Returns_FullyConfiguredSharedAppSetting()
		{
			// Assemble
			var expectedSharedAppSetting = new SharedAppSetting
			{
				Key = Create<string>(),
				Value = Create<string>()
			};

			// Act
			var actualSharedAppSetting = SharedAppSettingBuilder
				.CreateNew()
				.WithKey(expectedSharedAppSetting.Key)
				.WithValue(expectedSharedAppSetting.Value)
				.Build();

			// Assert
			actualSharedAppSetting.Should().Be(expectedSharedAppSetting);
		}

		public override void PostSetup()
		{
			Fixture.Register(() => SharedAppSettingBuilder.CreateNew() as SharedAppSettingBuilder);
		}
	}
}