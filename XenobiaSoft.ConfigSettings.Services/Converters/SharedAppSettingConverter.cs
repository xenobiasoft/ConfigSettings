﻿using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Data.V2.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Converters;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Converters
{
	public class SharedAppSettingConverter : ISharedAppSettingConverter
	{
		private readonly IBuilderFactory _builderFactory;

		public SharedAppSettingConverter(IBuilderFactory builderFactory)
		{
			_builderFactory = builderFactory;
		}

		public SharedAppSetting Convert(Data.V2.Models.AppSetting sharedAppSettingModel)
		{
			return _builderFactory
				.SharedAppSettingsBuilder()
				.WithKey(sharedAppSettingModel.Key)
				.WithValue(sharedAppSettingModel.Value)
				.Build();
		}
	}
}