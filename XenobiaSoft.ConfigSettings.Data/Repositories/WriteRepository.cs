using MongoDB.Driver;
using XenobiaSoft.ConfigSettings.Data.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.Repositories
{
	public class WriteRepository<TModel, TKey> : IWriteRepository<TModel, TKey>
	{
		private readonly IMongoDatabase _mongoDatabase;

		public WriteRepository(IMongoDatabase mongoDatabase)
		{
			_mongoDatabase = mongoDatabase;
		}

		public TModel GetById(TKey id)
		{
			var filter = GetIdFilter(id);

			return GetMongoCollection()
				.FindSync(filter)
				.FirstOrDefault();
		}

		public void Add(TModel model)
		{
			GetMongoCollection().InsertOne(model);
		}

		public void Remove(TKey id)
		{
			var filter = GetIdFilter(id);

			GetMongoCollection().DeleteOne(filter);
		}

		public void RemoveAll()
		{
		}

		private IMongoCollection<TModel> GetMongoCollection()
		{
			return _mongoDatabase.GetCollection<TModel>(typeof(TModel).Name);
		}

		private FilterDefinition<TModel> GetIdFilter(TKey id)
		{
			return Builders<TModel>.Filter.Eq("id", id);
		}
	}
}