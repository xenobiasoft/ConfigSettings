using System;
using System.Data.Entity;
using System.Linq;
using XenobiaSoft.ConfigSettings.Data.Interfaces;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Data
{
	public class EntityRepository<TEntityType> : IRepository<TEntityType> where TEntityType : BaseEntity
	{
		private readonly IDbSet<TEntityType> _entities;

		public EntityRepository(IDbSet<TEntityType> entities)
		{
			_entities = entities;
		}

		public void Add(TEntityType entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			if (!entity.IsNew)
			{
				throw new ArgumentException($"Cannot add an existing {typeof(TEntityType).Name} to the collection.");
			}

			_entities.Add(entity);
		}

		public TEntityType GetById(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException($"{nameof(id)} must be greater than 0.");
			}

			var entity = _entities.Find(id);

			if (entity == null)
			{
				throw new ArgumentException($"{typeof(TEntityType).Name} with Id {id} does not exist in the collection.");
			}

			return entity;
		}

		public IQueryable<TEntityType> QueryAll()
		{
			return _entities;
		}

		public void Remove(TEntityType entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_entities.Remove(entity);
		}

		public void RemoveAll()
		{
			foreach (var entity in _entities.ToList())
			{
				_entities.Remove(entity);
			}
		}
	}
}