using System.Linq;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data.Interfaces
{
	public interface IRepository<TEntityType> where TEntityType : BaseEntity
	{
		void Add(TEntityType entity);
		TEntityType GetById(int id);
		IQueryable<TEntityType> QueryAll();
		void Remove(TEntityType entity);
		void RemoveAll();
	}
}