using System.Data.Entity;
using XenobiaSoft.ConfigSettings.Data.Interfaces;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Context
{
	public class ConfigSettingsContext : DbContext, IConfigSettingsContext
	{
		public ConfigSettingsContext() : base("name=ConfigSettings")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ConfigSettingsContext>());
		}

		public IDbSet<AppSetting> AppSettings { get; set; }
		public IDbSet<Environment> Environments { get; set; }
		public IDbSet<Project> Projects { get; set; }
		public IDbSet<ProjectEnvironmentConfig> ProjectEnvironmentConfigs { get; set; }
		public IDbSet<SharedAppSetting> SharedAppSettings { get; set; }

		public void Commit()
		{
			SaveChanges();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ProjectConfiguration());
			modelBuilder.Configurations.Add(new EnvironmentConfiguration());
			modelBuilder.Configurations.Add(new AppSettingConfiguration());
			modelBuilder.Configurations.Add(new ProjectEnvironmentConfigConfiguration());
			modelBuilder.Configurations.Add(new SharedAppSettingConfiguration());
		}
	}
}