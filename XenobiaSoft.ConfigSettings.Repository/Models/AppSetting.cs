namespace XenobiaSoft.ConfigSettings.Repository.Models
{
	public class AppSetting : BaseEntity
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public int ProjectEnvironmentConfigId { get; set; }
		public ProjectEnvironmentConfig ProjectEnvironmentConfig { get; set; }
		public Enums.TransformType TransformType { get; set; }
	}
}