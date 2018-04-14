using System;
using System.Data.Common;
using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.V2.Repositories
{
	public class SavingRepository<TModel, TKey> : ISavingRepository<TModel, TKey>
	{
		private readonly IDbContext _dbContext;

		public SavingRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}

		public void Save()
		{
		}

		public void UseTransation(DbTransaction transation)
		{
			throw new NotSupportedException();
		}

		public TModel GetById(TKey id)
		{
			return _dbContext.GetById<TModel, TKey>(id);
		}

		public void Add(TModel model)
		{
			_dbContext.Add(model);
		}

		public void Remove(TModel model)
		{
		}
	}
}