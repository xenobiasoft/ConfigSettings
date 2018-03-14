using System;
using XenobiaSoft.ConfigSettings.Repository.Interfaces;
using XenobiaSoft.ConfigSettings.Repository.Models;
using Environment = XenobiaSoft.ConfigSettings.Repository.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Repository
{
	public class ConfigSettingsUnitOfWork : IUnitOfWork
	{
		private readonly IConfigSettingsContext _context;

		public ConfigSettingsUnitOfWork(IConfigSettingsContext context)
		{
			_context = context;
			InitializeRepositories();
		}

		public IRepository<AppSetting> AppSettings { get; private set; }
		public IRepository<Environment> Environments { get; private set; }
		public IRepository<ProjectEnvironmentConfig> ProjectEnvironmentConfigs { get; private set; }
		public IRepository<Project> Projects { get; private set; }
		public IRepository<SharedAppSetting> SharedAppSettings { get; private set; }

		public void Commit() => _context.Commit();

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool isDisposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (isDisposing)
			{
				_context.Dispose();
			}

			IsDisposed = true;
		}

		public bool IsDisposed { get; private set; }

		private void InitializeRepositories()
		{
			AppSettings = new EntityRepository<AppSetting>(_context.AppSettings);
			Environments = new EntityRepository<Environment>(_context.Environments);
			ProjectEnvironmentConfigs = new EntityRepository<ProjectEnvironmentConfig>(_context.ProjectEnvironmentConfigs);
			Projects = new EntityRepository<Project>(_context.Projects);
			SharedAppSettings = new EntityRepository<SharedAppSetting>(_context.SharedAppSettings);
		}
	}
}