using System;
using System.Linq;

namespace XenobiaSoft.ConfigSettings.Data.V2.Interfaces
{
	public interface IDbContext : IDisposable
	{
		IQueryable<TModel> GetCollection<TModel>();
		TModel GetById<TModel, TKey>(TKey id);
		void Add<TModel>(TModel model);
		void Remove<TModel, TKey>(TKey id);
	}
}