using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces
{
	public interface ICache
	{
		void Add<TType>(string key, TType entity) where TType : BaseEntity;
		void Clear();
		bool Exists<TType>(string key) where TType : BaseEntity;
		TType Get<TType>(string key) where TType : BaseEntity;
		int Count { get; }
	}
}