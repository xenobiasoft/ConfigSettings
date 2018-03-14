using System;
using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.SharedAppSettings;

namespace XenobiaSoft.ConfigSettings.Services.Builders
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

		public SharedAppSetting Build()
		{
			return new SharedAppSetting
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