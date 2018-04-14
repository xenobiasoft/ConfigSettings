using System.Linq;
using MongoDB.Driver;
using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;

namespace XenobiaSoft.ConfigSettings.Data.V2.Repositories
{
	public class DbContext : IDbContext
	{
		private IMongoDatabase _mongoDatabase;

		public DbContext()
		{
			var client = new MongoClient();
			_mongoDatabase = client.GetDatabase("ConfigSettings");
		}

		public void Dispose()
		{
			_mongoDatabase = null;
		}

		public IQueryable<TModel> GetCollection<TModel>()
		{
			return GetMongoCollection<TModel>()
				.AsQueryable();
		}

		public TModel GetById<TModel, TKey>(TKey id)
		{
			var filter = GetIdFilter<TModel, TKey>(id);

			return GetMongoCollection<TModel>()
				.FindAsync(filter)
				.Result
				.FirstOrDefault();
		}

		public void Add<TModel>(TModel model)
		{
			GetMongoCollection<TModel>().InsertOne(model);
		}

		public void Remove<TModel, TKey>(TKey id)
		{
			var filter = GetIdFilter<TModel, TKey>(id);

			GetMongoCollection<TModel>().DeleteOne(filter);
		}

		private IMongoCollection<TModel> GetMongoCollection<TModel>()
		{
			return _mongoDatabase
				.GetCollection<TModel>(typeof(TModel).Name);
		}

		private FilterDefinition<TModel> GetIdFilter<TModel, TKey>(TKey id)
		{
			return Builders<TModel>.Filter.Eq("id", id);
		}
	}
}
