using System;
using XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.SharedAppSettings;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Builders
{
	public class SharedAppSettingBuilder : ISharedAppSettingBuilder, IKeyHolder, IValueHolder
	{
		private SharedAppSettingBuilder()
		{}

		public static IKeyHolder CreateNew()
		{
			return new SharedAppSettingBuilder();
		}

		public static IKeyHolder CreateExisting(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException("Shared App Setting Id must be greater than 0.");
			}

			return new SharedAppSettingBuilder
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

			return new SharedAppSettingBuilder
			{
				Id = Id,
				Key = key
			};
		}

		public ISharedAppSettingBuilder WithValue(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			return new SharedAppSettingBuilder
			{
				Id = Id,
				Key = Key,
				Value = value
			};
		}

		public AppSetting Build()
		{
			return new AppSetting
			{
				Id = Id.GetValueOrDefault(),
				Key = Key,
				Value = Value,
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			};
		}

		private int? Id { get; set; }
		private string Key { get; set; }
		private string Value { get; set; }
	}
}