using System;
using System.Data.Entity;
using XenobiaSoft.ConfigSettings.Repository.Models;
using Environment = XenobiaSoft.ConfigSettings.Repository.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Repository.Interfaces
{
	public interface IConfigSettingsContext : IDisposable
	{
		IDbSet<AppSetting> AppSettings { get; set; }
		IDbSet<Environment> Environments { get; set; }
		IDbSet<ProjectEnvironmentConfig> ProjectEnvironmentConfigs { get; set; }
		IDbSet<Project> Projects { get; set; }
		IDbSet<SharedAppSetting> SharedAppSettings { get; set; }

		void Commit();
	}
}