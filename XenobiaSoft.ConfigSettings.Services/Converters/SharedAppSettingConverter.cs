using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Converters
{
	public class SharedAppSettingConverter : ISharedAppSettingConverter
	{
		private readonly IBuilderFactory _BuilderFactory;

		public SharedAppSettingConverter(IBuilderFactory builderFactory)
		{
			_BuilderFactory = builderFactory;
		}

		public SharedAppSetting Convert(AppSettingModel sharedAppSettingModel)
		{
			return _BuilderFactory
				.SharedAppSettingsBuilder()
				.WithKey(sharedAppSettingModel.Key)
				.WithValue(sharedAppSettingModel.Value)
				.Build();
		}
	}
}