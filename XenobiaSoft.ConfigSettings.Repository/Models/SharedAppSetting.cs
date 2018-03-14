namespace XenobiaSoft.ConfigSettings.Repository.Models
{
	public class SharedAppSetting : BaseEntity
	{
		public string Key { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			return $"Key: {Key}, Value: {Value}";
		}

		public override bool Equals(object obj)
		{
			if (!(obj is SharedAppSetting sharedAppSetting))
			{
				return false;
			}

			return Key == sharedAppSetting.Key && Value == sharedAppSetting.Value;
		}

		public override int GetHashCode()
		{
			return Key.GetHashCode() ^ Value.GetHashCode();
		}
	}
}