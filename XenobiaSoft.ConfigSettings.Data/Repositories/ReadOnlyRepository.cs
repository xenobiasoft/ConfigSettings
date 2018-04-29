using System.Linq;
using MongoDB.Driver;
using XenobiaSoft.ConfigSettings.Data.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.Repositories
{
	public class ReadOnlyRepository<TModel> : IReadOnlyRepository<TModel>
	{
		private readonly IMongoDatabase _mongoDatabase;

		public ReadOnlyRepository(IMongoDatabase mongoDatabase)
		{
			_mongoDatabase = mongoDatabase;
		}

		public IQueryable<TModel> QueryAll()
		{
			return GetMongoCollection().AsQueryable();
		}

		private IMongoCollection<TModel> GetMongoCollection()
		{
			var mongoCollection = _mongoDatabase.GetCollection<TModel>(typeof(TModel).Name);

			return mongoCollection;
		}
	}
}