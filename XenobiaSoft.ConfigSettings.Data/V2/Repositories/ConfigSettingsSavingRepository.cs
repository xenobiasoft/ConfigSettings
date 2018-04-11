using System.Data.Common;
using MongoDB.Bson;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.V2.Repositories
{
	public class ConfigSettingsSavingRepository : ISavingRepository<ProjectEnvironmentConfig, ObjectId>
	{
		public void Dispose()
		{
			throw new System.NotImplementedException();
		}

		public void Save()
		{
			throw new System.NotImplementedException();
		}

		public void UseTransation(DbTransaction transation)
		{
			throw new System.NotImplementedException();
		}

		public ProjectEnvironmentConfig GetById(ObjectId id)
		{
			throw new System.NotImplementedException();
		}

		public void Add(ProjectEnvironmentConfig model)
		{
			throw new System.NotImplementedException();
		}

		public void Remove(ProjectEnvironmentConfig model)
		{
			throw new System.NotImplementedException();
		}
	}
}
