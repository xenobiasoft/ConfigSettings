﻿using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Converters
{
	public class AppSettingConverter : IAppSettingConverter
	{
		private readonly IBuilderFactory _builderFactory;

		public AppSettingConverter(IBuilderFactory builderFactory)
		{
			_builderFactory = builderFactory;
		}

		public AppSetting Convert(AppSettingModel appSettingModel)
		{
			return _builderFactory
				.AppSettingBuilder()
				.WithKey(appSettingModel.Key)
				.WithValue(appSettingModel.Value)
				.WithTransformType(appSettingModel.TransformType)
				.Build();
		}
	}
}