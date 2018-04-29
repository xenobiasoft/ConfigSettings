using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.SharedAppSettings;
using XenobiaSoft.ConfigSettings.Data.Models;

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

		public AppSetting Build()
		{
			BuildWasCalled = true;
			return new AppSetting();
		}

		public string Key { get; private set; }
		public string Value { get; private set; }
		public bool BuildWasCalled { get; private set; }
	}
}