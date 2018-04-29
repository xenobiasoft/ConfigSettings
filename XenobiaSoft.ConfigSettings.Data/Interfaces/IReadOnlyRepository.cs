using System.Linq;

namespace XenobiaSoft.ConfigSettings.Data.Interfaces
{
	public interface IReadOnlyRepository<out TModel>
	{
		IQueryable<TModel> QueryAll();
	}
}