using System;
using XenobiaSoft.ConfigSettings.Data.Models;
using Environment = XenobiaSoft.ConfigSettings.Data.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Data.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<AppSetting> AppSettings { get; }
		IRepository<Environment> Environments { get; }
		IRepository<Project> Projects { get; }
		IRepository<ProjectEnvironmentConfig> ProjectEnvironmentConfigs { get; }
		IRepository<SharedAppSetting> SharedAppSettings { get; }

		void Commit();
		bool IsDisposed { get; }
	}
}