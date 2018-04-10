using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.SharedAppSettings;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Mocks.Builders
{
	public class MockSharedAppSettingBuilder : ISharedAppSettingBuilder, IKeyHolder, IValueHolder
	{
		public IValueHolder WithKey(string key)
		{
			Key = key;
			return this;
		}

		public ISharedAppSettingBuilder WithValue(string value)
		{
			Value = value;
			return this;
		}

		public SharedAppSetting Build()
		{
			BuildWasCalled = true;
			return new SharedAppSetting();
		}

		public string Key { get; private set; }
		public string Value { get; private set; }
		public bool BuildWasCalled { get; private set; }
	}
}