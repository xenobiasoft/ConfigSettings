using System.Collections.Generic;

namespace XenobiaSoft.ConfigSettings.Repository.Models
{
	public class ProjectEnvironmentConfig : BaseEntity
	{
		public string ConfigPath { get; set; }
		public int ProjectId { get; set; }
		public Project Project { get; set; }
		public int EnvironmentId { get; set; }
		public Environment Environment { get; set; }
		public ICollection<AppSetting> AppSettings { get; set; }
	}
}