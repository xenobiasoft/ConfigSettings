using System.Linq;

namespace XenobiaSoft.ConfigSettings.Repository.V2.Interfaces
{
	public interface IReadOnlyRepository<out TModel> : IRepository
	{
		IQueryable<TModel> QueryAll();
	}
}