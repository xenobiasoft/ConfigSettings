using System.Linq;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Repository.Interfaces
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