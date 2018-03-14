using System;
using System.Diagnostics.Contracts;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.ProjectEnvironmentConfigs
{
	[ContractClass(typeof(AppSettingHolder))]
	public interface IAppSettingHolder
	{
		IAppSettingHolder Add(AppSetting appSetting);
		IProjectEnvironmentConfigBuilder Done();
	}

	[ContractClassFor(typeof(IAppSettingHolder))]
	public abstract class AppSettingHolder : IAppSettingHolder
	{
		public IAppSettingHolder Add(AppSetting appSetting)
		{
			Contract.Requires<ArgumentNullException>(appSetting != null);

			return null;
		}

		public IProjectEnvironmentConfigBuilder Done()
		{
			return null;
		}
	}
}