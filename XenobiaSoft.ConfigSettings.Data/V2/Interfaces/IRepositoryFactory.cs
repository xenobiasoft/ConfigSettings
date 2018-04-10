﻿namespace XenobiaSoft.ConfigSettings.Data.V2.Interfaces
{
	public interface IRepositoryFactory
	{
		IReadOnlyRepository<TModel> CreateReadOnly<TModel>();
		ISavingRepository<TModel, TKey> CreateSaving<TModel, TKey>();
	}
}