﻿using System.Collections.Generic;

namespace XenobiaSoft.ConfigSettings.Repository.Models
{
	public class Environment : BaseEntity
	{
		public string EnvironmentName { get; set; }
		public ICollection<ProjectEnvironmentConfig> ProjectEnvironmentConfigs { get; set; }
	}
}