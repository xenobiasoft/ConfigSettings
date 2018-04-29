using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.AppSettings;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Mocks.Builders
{
	public class MockAppSettingBuilder : IAppSettingBuilder, IKeyHolder, IValueHolder, ITransformTypeHolder
	{
		public IValueHolder WithKey(string key)
		{
			Key = key;
			return this;
		}

		public ITransformTypeHolder WithValue(string value)
		{
			Value = value;
			return this;
		}

		public IAppSettingBuilder WithTransformType(string transformType)
		{
			TransformType = transformType;
			return this;
		}

		public AppSetting Build()
		{
			BuildWasCalled = true;
			return new AppSetting();
		}

		public string Key { get; private set; }
		public string Value { get; private set; }
		public string TransformType { get; private set; }
		public bool BuildWasCalled { get; private set; }
	}
}