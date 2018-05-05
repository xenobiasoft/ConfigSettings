namespace XenobiaSoft.ConfigSettings.Data.Models
{
	public class AppSetting : BaseModel
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public TransformType TransformType { get; set; }
	}
}