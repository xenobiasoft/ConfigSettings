using System;
using XenobiaSoft.ConfigSettings.Data;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings;

namespace XenobiaSoft.ConfigSettings.Services.Builders
{
	public class AppSettingBuilder : IAppSettingBuilder, IKeyHolder, IValueHolder, ITransformTypeHolder
	{
		private AppSettingBuilder()
		{}

		public static IKeyHolder CreateNew()
		{
			return new AppSettingBuilder();
		}

		public static IKeyHolder CreateExisting(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException("App Setting Id must be greater than 0.");
			}

			return new AppSettingBuilder
			{
				Id = id
			};
		}

		public IValueHolder WithKey(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentNullException(nameof(key));
			}

			return new AppSettingBuilder
			{
				Id = Id,
				Key = key
			};
		}

		public ITransformTypeHolder WithValue(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			return new AppSettingBuilder
			{
				Id = Id,
				Key = Key,
				Value = value
			};
		}

		public IAppSettingBuilder WithTransformType(string transformType)
		{
			if (string.IsNullOrEmpty(transformType))
			{
				transformType = Data.TransformType.None.ToString();
			}

			if (!Enum.TryParse(transformType, true, out TransformType _))
			{
				throw new ArgumentException(nameof(transformType));
			}

			return new AppSettingBuilder
			{
				Id = Id,
				Key = Key,
				Value = Value,
				TransformType = transformType
			};
		}

		public AppSetting Build()
		{
			Enum.TryParse(TransformType, out TransformType transformType);

			var appSetting = new AppSetting
			{
				Id = Id,
				Key = Key,
				Value = Value,
				TransformType = transformType, 
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			};

			return appSetting;
		}

		public int Id { get; private set; }
		public string Key { get; private set; }
		public string Value { get; private set; }
		public string TransformType { get; private set; }
	}
}