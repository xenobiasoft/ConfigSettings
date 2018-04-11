using System.Data.Common;
using System.Linq;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.V2.Repositories
{
	public class ConfigSettingsReadOnlyRepository : IReadOnlyRepository<ProjectEnvironmentConfig>
	{
		public IQueryable<ProjectEnvironmentConfig> QueryAll()
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}

		public void UseTransation(DbTransaction transation)
		{
			throw new System.NotImplementedException();
		}
	}
}