using System.Collections.Generic;

namespace XenobiaSoft.ConfigSettings.Data.Models
{
	public class Project : BaseEntity
	{
		public string ProjectName { get; set; }
		public ICollection<ProjectEnvironmentConfig> ProjectEnvironmentConfigs { get; set; }
	}
}