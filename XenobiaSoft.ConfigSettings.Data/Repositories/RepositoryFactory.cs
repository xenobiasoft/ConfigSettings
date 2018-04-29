using MongoDB.Driver;
using XenobiaSoft.ConfigSettings.Data.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.Repositories
{
	public class RepositoryFactory : IRepositoryFactory
	{
		private readonly IMongoDatabase _mongoDatabase;

		public RepositoryFactory(IMongoClient mongoClient)
		{
			_mongoDatabase = mongoClient.GetDatabase("ConfigSettings");
		}

		public IReadOnlyRepository<TModel> CreateReadOnly<TModel>()
		{
			return new ReadOnlyRepository<TModel>(_mongoDatabase);
		}

		public IWriteRepository<TModel, TKey> CreateWrite<TModel, TKey>()
		{
			return new WriteRepository<TModel, TKey>(_mongoDatabase);
		}
	}
}