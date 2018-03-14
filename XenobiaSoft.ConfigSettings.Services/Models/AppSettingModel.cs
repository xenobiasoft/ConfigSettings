namespace XenobiaSoft.ConfigSettings.Services.Models
{
	public class AppSettingModel
	{
		public AppSettingModel(string key, string value, string transformType)
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