using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.V2.Repositories
{
	public class RepositoryFactory : IRepositoryFactory
	{
		private readonly IDbContext _dbContext;

		public RepositoryFactory(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IReadOnlyRepository<TModel> CreateReadOnly<TModel>()
		{
			return new ReadOnlyRepository<TModel>(_dbContext);
		}

		public ISavingRepository<TModel, TKey> CreateSaving<TModel, TKey>()
		{
			return new SavingRepository<TModel, TKey>(_dbContext);
		}
	}
}