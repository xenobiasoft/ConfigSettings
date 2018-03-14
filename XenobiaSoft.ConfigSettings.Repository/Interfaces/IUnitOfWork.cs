using System;
using XenobiaSoft.ConfigSettings.Repository.Models;
using Environment = XenobiaSoft.ConfigSettings.Repository.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Repository.Interfaces
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