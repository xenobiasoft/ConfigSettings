namespace XenobiaSoft.ConfigSettings.Data.V2.Models
{
	public class AppSetting
	{
		public AppSetting(string key, string value, string transformType)
		{
			Key = key;
			Value = value;
			TransformType = transformType;
		}

		public string Key { get; }
		public string Value { get; }
		public string TransformType { get; }
	}
}