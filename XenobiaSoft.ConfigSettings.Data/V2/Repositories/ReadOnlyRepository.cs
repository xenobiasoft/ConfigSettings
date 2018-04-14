using System;
using System.Data.Common;
using System.Linq;
using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.V2.Repositories
{
	public class ReadOnlyRepository<TModel> : IReadOnlyRepository<TModel>
	{
		private readonly IDbContext _dbContext;

		public ReadOnlyRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<TModel> QueryAll()
		{
			return _dbContext.GetCollection<TModel>();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}

		public void UseTransation(DbTransaction transation)
		{
			throw new NotSupportedException();
		}
	}
}