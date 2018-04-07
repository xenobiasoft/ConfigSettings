using System;
using System.Collections.Generic;
using System.Linq;
using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Exceptions;
using XenobiaSoft.ConfigSettings.Services.Interfaces;

namespace XenobiaSoft.ConfigSettings.Services
{
	public class Cache : ICache
	{
		private readonly Dictionary<Type, Dictionary<string, BaseEntity>> _storage;

		public Cache()
		{
			_storage = new Dictionary<Type, Dictionary<string, BaseEntity>>();
		}

		public void Add<TType>(string key, TType entity) where TType : BaseEntity
		{
			if (Exists<TType>(key))
			{
				throw new ExistsInCacheException(typeof(TType), key);
			}

			var typeStorage = GetTypeStorage(typeof(TType));

			typeStorage.Add(key, entity);
		}

		public void Clear()
		{
			_storage.Clear();
		}

		public bool Exists<TType>(string key) where TType : BaseEntity
		{
			return Exists(typeof(TType), key);
		}

		private bool Exists(Type type, string key)
		{
			var typeStorage = GetTypeStorage(type);

			return typeStorage.ContainsKey(key);
		}

		private Dictionary<string, BaseEntity> GetTypeStorage(Type type)
		{
			if (!_storage.ContainsKey(type))
			{
				CreateTypeStorage(type);
			}

			return _storage[type];
		}

		private void CreateTypeStorage(Type type)
		{
			if (!_storage.ContainsKey(type))
			{
				_storage.Add(type, new Dictionary<string, BaseEntity>());
			}
		}

		public TType Get<TType>(string key) where TType : BaseEntity
		{
			if (!Exists<TType>(key))
			{
				throw new NotFoundException(typeof(TType), key);
			}

			var typeStorage = GetTypeStorage(typeof(TType));

			return (TType) typeStorage[key];
		}

		public int Count => _storage.Sum(x => x.Value.Count);
	}
}