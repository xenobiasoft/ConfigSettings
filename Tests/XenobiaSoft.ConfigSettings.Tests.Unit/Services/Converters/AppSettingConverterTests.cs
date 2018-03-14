using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services.Converters;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;
using XenobiaSoft.ConfigSettings.Tests.Unit.Mocks.Builders;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Converters
{
	[TestFixture]
	public class AppSettingConverterTests : AutoMockFixtureInterface<AppSettingConverter, IAppSettingConverter>
	{
		private MockAppSettingBuilder _MockAppSettingBuilder;

		[Test]
		public void Convert_CallsWithKey_OnAppSettingBuilder()
		{
			// Assemble
			var appSettingModel = Create<AppSettingModel>();

			// Act
			Sut.Convert(appSettingModel);

			// Assert
			_MockAppSettingBuilder.Key.Should().Be(appSettingModel.Key);
		}

		[Test]
		public void Convert_CallsWithValue_OnAppSettingBuilder()
		{
			// Assemble
			var appSettingModel = Create<AppSettingModel>();

			// Act
			Sut.Convert(appSettingModel);

			// Assert
			_MockAppSettingBuilder.Value.Should().Be(appSettingModel.Value);
		}

		[Test]
		public void Convert_CallsWithTransformType_OnAppSettingBuilder()
		{
			var appSettingModel = Create<AppSettingModel>();

			// Act
			Sut.Convert(appSettingModel);

			// Assert
			_MockAppSettingBuilder.TransformType.Should().Be(appSettingModel.TransformType);
		}

		[Test]
		public void Convert_CallsBuild_OnAppSettingBuilder()
		{
			var appSettingModel = Create<AppSettingModel>();

			// Act
			Sut.Convert(appSettingModel);

			// Assert
			_MockAppSettingBuilder.BuildWasCalled.Should().BeTrue();
		}

		public override void PostSetup()
		{
			_MockAppSettingBuilder = Resolve<MockAppSettingBuilder>();

			Fixture.Register<IKeyHolder>(() => _MockAppSettingBuilder);
		}
	}
}