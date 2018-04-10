namespace XenobiaSoft.ConfigSettings.Data.Models
{
	public class AppSetting : BaseEntity
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public int ProjectEnvironmentConfigId { get; set; }
		public ProjectEnvironmentConfig ProjectEnvironmentConfig { get; set; }
		public TransformType TransformType { get; set; }
	}
}