namespace XenobiaSoft.ConfigSettings.Repository.V2.Interfaces
{
	public interface ISavingRepository<TModel, in TKey> : IRepository, IPersistable
	{
		TModel GetById(TKey id);
		void Add(TModel model);
		void Remove(TModel model);
	}
}