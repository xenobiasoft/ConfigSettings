using System.Collections.Generic;

namespace XenobiaSoft.ConfigSettings.Data.V2.Models
{
	public class ProjectEnvironmentConfiguration
	{
		public string ProjectName { get; set; }
		public string EnvironmentName { get; set; }
		public List<AppSetting> AppSettings { get; set; }
		public string ConfigPath { get; set; }
	}
}