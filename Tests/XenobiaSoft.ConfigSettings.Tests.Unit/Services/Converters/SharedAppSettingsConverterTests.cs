using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.V2.Models;
using XenobiaSoft.ConfigSettings.Services.Converters;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.SharedAppSettings;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;
using XenobiaSoft.ConfigSettings.Tests.Unit.Mocks.Builders;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Converters
{
	[TestFixture]
	public class SharedAppSettingConverterTests : AutoMockFixtureInterface<SharedAppSettingConverter, ISharedAppSettingConverter>
	{
		private MockSharedAppSettingBuilder _MockSharedAppSettingBuilder;

		[Test]
		public void Convert_CallsWithKey_OnBuilder()
		{
			// Assemble
			var sharedAppSettingModel = Create<AppSetting>();

			// Act
			Sut.Convert(sharedAppSettingModel);

			// Assert
			_MockSharedAppSettingBuilder.Key.Should().Be(sharedAppSettingModel.Key);
		}

		[Test]
		public void Convert_CallsWithValue_OnBuilder()
		{
			// Assemble
			var sharedAppSettingModel = Create<AppSetting>();

			// Act
			Sut.Convert(sharedAppSettingModel);

			// Assert
			_MockSharedAppSettingBuilder.Value.Should().Be(sharedAppSettingModel.Value);
		}

		[Test]
		public void Convert_CallsBuild_OnBuilder()
		{
			// Assemble

			// Act
			Sut.Convert(Create<AppSetting>());

			// Assert
			_MockSharedAppSettingBuilder.BuildWasCalled.Should().BeTrue();
		}

		public override void PostSetup()
		{
			_MockSharedAppSettingBuilder = Create<MockSharedAppSettingBuilder>();

			Fixture.Register<IKeyHolder>(() => _MockSharedAppSettingBuilder);
		}
	}
}