using System.Collections.Generic;

namespace XenobiaSoft.ConfigSettings.Services.Models
{
	public class ProjectEnvironmentConfiguration
	{
		public string ProjectName { get; set; }
		public string EnvironmentName { get; set; }
		public List<AppSettingModel> AppSettings { get; set; }
		public string ConfigPath { get; set; }
	}
}