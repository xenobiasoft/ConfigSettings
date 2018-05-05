namespace XenobiaSoft.ConfigSettings.Data.Interfaces
{
	public interface IRepositoryFactory
	{
		IReadOnlyRepository<TModel> CreateReadOnly<TModel>();
		IWriteRepository<TModel, TKey> CreateWrite<TModel, TKey>();
	}
}