namespace XenobiaSoft.ConfigSettings.Data.Interfaces
{
	public interface IWriteRepository<TModel, in TKey>
	{
		TModel GetById(TKey id);
		void Add(TModel model);
		void Remove(TKey id);
		void RemoveAll();
	}
}