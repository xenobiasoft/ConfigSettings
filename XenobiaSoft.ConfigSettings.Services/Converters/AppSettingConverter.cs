using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Converters
{
	public class AppSettingConverter : IAppSettingConverter
	{
		private readonly IBuilderFactory _BuilderFactory;

		public AppSettingConverter(IBuilderFactory builderFactory)
		{
			_BuilderFactory = builderFactory;
		}

		public AppSetting Convert(AppSettingModel appSettingModel)
		{
			return _BuilderFactory
				.AppSettingBuilder()
				.WithKey(appSettingModel.Key)
				.WithValue(appSettingModel.Value)
				.WithTransformType(appSettingModel.TransformType)
				.Build();
		}
	}
}