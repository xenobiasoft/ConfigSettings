using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Builders;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.SharedAppSettings;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Builders.SharedAppSettings
{
	[TestFixture]
	public class BuilderTests : AutoMockFixtureInterface<SharedAppSettingBuilder, ISharedAppSettingBuilder>
	{
		[Test]
		public void Returns_FullyConfiguredSharedAppSetting()
		{
			// Assemble
			var expectedSharedAppSetting = new AppSetting
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
			actualSharedAppSetting.Should().Match<AppSetting>(x =>
				x.Key == expectedSharedAppSetting.Key && 
				x.Value == expectedSharedAppSetting.Value &&
				x.TransformType == expectedSharedAppSetting.TransformType);
		}

		public override void PostSetup()
		{
			Fixture.Register(() => SharedAppSettingBuilder.CreateNew() as SharedAppSettingBuilder);
		}
	}
}